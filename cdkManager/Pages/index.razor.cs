using cdkManager.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace cdkManager.Pages
{
    public partial class Index 
    {
        [Inject]
        private IStackRepository? StackRepository { get; set; }

        [Inject]
        private IModals? Modals { get; set; }

        protected override void OnInitialized()
        {
            Stacks = StackRepository?.GetAll()?.ToList() ?? new List<Models.Stack>();
        }

        [Parameter]
        public IList<Models.Stack>? Stacks { get; set; }

        public async void SaveNewStack(Modal<Models.Stack> stackModal)
        {
            if (StackRepository == null)
            {
                //TODO: Warn user something is broke... Log this...
                return;
            }

            Stacks.Add(stackModal.Data);
            stackModal.Toggle();
            await StackRepository.AddAsync(stackModal.Data);
            stackModal.Data = new Models.Stack();
        } 


    }
}
