using System.Collections.Generic;

namespace LastPassProject.Helpers
{
    public interface IUserPasswordList
    {
        public List<UserPassword> SetData();
        public void UpdateData();
        public void Edit(UserPassword userPassword);
        public void Delete(int Id);
        public string Encrypt(string password);
        public string Decrypt(string password);

    }
}
