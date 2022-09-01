using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LastPassProject.Helpers
{
    public class SerializeDeserialize
    {
        public void CreateUpdateJson(List<UserPassword> userPasswords)
        {

            string jsonString = JsonSerializer.Serialize(userPasswords);
            File.WriteAllText(@"D:\C#Test\Examples\LastPassProject\passwords.json", jsonString.ToString());
        }

        public List<UserPassword> DeserializeJson(string jsonString)
        {
            List<UserPassword>? userPasswords = JsonSerializer.Deserialize<List<UserPassword>>(jsonString);
            return userPasswords;
        }
    }
}
