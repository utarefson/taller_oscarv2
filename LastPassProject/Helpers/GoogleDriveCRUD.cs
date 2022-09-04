using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace LastPassProject.Helpers
{
    
    public class GoogleDriveCRUD
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Drive API .NET Quickstart";
        public  DriveService GetService()
        {
            UserCredential credential;
            using (var stream =
                   new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        public  string CreateFile(string Name)
        {
            var service = GetService();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Name;
            fileMetadata.MimeType = "application/json";
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        }
        public  string UploadFileToDrive()
        {
            string contentType="application / json";
            DriveService service = GetService();
            var updatedFileMetadata = new Google.Apis.Drive.v3.Data.File();
            updatedFileMetadata.Name = "test";
            FilesResource.UpdateMediaUpload updateRequest;
            string fileId = "1qaEhQk2QtcOWmTuFwubM1AOp70KD-N7S";
            using (var stream = new FileStream(@"D:\C#Test\Examples\LastPassProject\passwords.json", FileMode.OpenOrCreate))
            {
                updateRequest = service.Files.Update(updatedFileMetadata, fileId, stream, contentType);
                updateRequest.Upload();
                var file = updateRequest.ResponseBody;
                return file.Id;
            };
        }
        public string ReadFile()
        {
                string fileId = "1qaEhQk2QtcOWmTuFwubM1AOp70KD-N7S";
                var service = GetService();
                var request = service.Files.Get(fileId);
                var stream = new MemoryStream();
                request.Download(stream);
                string decoded = Encoding.UTF8.GetString(stream.ToArray());
                return decoded;
        }
    }
}
