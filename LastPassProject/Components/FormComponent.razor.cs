using Blazored.Modal;
using Blazored.Modal.Services;
using LastPassProject.Helpers;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace LastPassProject.Components
{
    public partial class FormComponent
    {
        [Inject]
        IUserPasswordList userPasswordList { get; set; }
        [CascadingParameter] 
        BlazoredModalInstance BlazoredModal { get; set; } = default!;
        [Parameter] public UserPassword userPassword { get; set; }
        private UserPassword UserPassword = new UserPassword();
        private async Task SubmitForm()
        {
             await BlazoredModal.Close(ModalResult.Ok(UserPassword));
        }
        private async Task EditPassword()
        {
            userPasswordList.Edit(userPassword);
            await BlazoredModal.Close(ModalResult.Ok("ok"));
        }
        
        private async Task Cancel() => await BlazoredModal.Cancel();
    }
}
