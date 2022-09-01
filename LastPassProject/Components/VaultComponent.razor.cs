using LastPassProject.Helpers;
using System.Collections.Generic;

namespace LastPassProject.Components
{
    public partial class VaultComponent
    {
        GoogleDriveCRUD googleDriveCRUD = new GoogleDriveCRUD();
        SerializeDeserialize deserialize = new SerializeDeserialize();
        List<UserPassword> userPasswords = new List<UserPassword>();
        public VaultComponent()
        {
            userPasswords = deserialize.DeserializeJson(googleDriveCRUD.ReadFile());
        }
    }
}
