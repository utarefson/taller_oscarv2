using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace LastPassProject.Helpers
{
    public class UserPasswordList:IUserPasswordList
    {
        GoogleDriveCRUD googleDriveCRUD = new GoogleDriveCRUD();
        SerializeDeserialize serializeDeserialize = new SerializeDeserialize();
        List<UserPassword> userPasswords = new List<UserPassword>();
        EncryptionHelper encryptDecrypt = new EncryptionHelper();
        public List<UserPassword> SetData()
        {
            int incrementedId = 0;
            userPasswords = serializeDeserialize.DeserializeJson(googleDriveCRUD.ReadFile());
            foreach (var item in userPasswords)
            {
                //item.Password = encryptDecrypt.Decrypt(item.Password);
                item.Id = incrementedId;
                incrementedId++;
            }
            return userPasswords;
        }

        public void UpdateData()
        {
            serializeDeserialize.CreateUpdateJson(userPasswords);
            googleDriveCRUD.UploadFileToDrive();
        }
        public void Edit(UserPassword userPassword)
        {
            userPasswords = SetData();
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).URL=userPassword.URL;
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).Name=userPassword.Name;
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).Folder=userPassword.Folder;
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).Username=userPassword.Username;
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).Password=userPassword.Password;
            userPasswords.FirstOrDefault(u => u.Id == userPassword.Id).Notes=userPassword.Notes;
            UpdateData();
        }
        public void Delete( int Id)
        {
            userPasswords = SetData();
            if(userPasswords == null)
            {
                return;
            }
            else {
                var item =userPasswords.FirstOrDefault(u => u.Id==Id);
                userPasswords.Remove(item);
                UpdateData();
            }
        }
        public string Encrypt(string password)
        {
           return encryptDecrypt.Encrypt(password);
        }
        public string Decrypt(string password)
        {
           return encryptDecrypt.Decrypt(password);
        }
    }
}
