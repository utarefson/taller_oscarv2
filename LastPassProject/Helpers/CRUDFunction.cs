using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace LastPassProject.Helpers
{
    public class CRUDFunction
    {
        GoogleDriveCRUD googleDriveCRUD = new GoogleDriveCRUD();
        SerializeDeserialize serializeDeserialize = new SerializeDeserialize();
        UserPassword userPassword = new UserPassword();
        List<UserPassword> userPasswords = new List<UserPassword>();
        EncryptionHelper encryptDecrypt = new EncryptionHelper();
        public List<UserPassword> SetData()
        {
            int x = 0;
            userPasswords = serializeDeserialize.DeserializeJson(googleDriveCRUD.ReadFile());
            foreach (var item in userPasswords)
            {
                item.Id = x;
                x++;
            }
            return userPasswords;
        }
        
        public void UpdateData()
        {
            serializeDeserialize.CreateUpdateJson(userPasswords);
            googleDriveCRUD.UploadFileToDrive();
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
    }
}
