using Microsoft.AspNetCore.Components;

namespace cdkManager.Shared
{
    public partial class StackComponent : ComponentBase
    {
        [Parameter]
        public Models.Stack? SelectedStack { get; set; }


        [Parameter]
        public EventCallback<Models.Stack> SelectedStackChanged { get; set; }

        private Task OnSelectedStackChanged(ChangeEventArgs e)
        {
            SelectedStack = (Models.Stack)e.Value!;
            return SelectedStackChanged.InvokeAsync(SelectedStack);
        }
    }
}
