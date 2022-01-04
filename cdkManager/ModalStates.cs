using cdkManager.Models;

namespace cdkManager
{
    public interface IModals
    {
        Modal<Models.Bucket> BucketModal { get; set; }
        Modal<Models.Stack> StackModal { get; set; }
        Modal<Models.Vpc> VpcModal { get; set; }
    }

    public class Modals : IModals
    {
        public Modal<Bucket> BucketModal { get; set; } = new();
        public Modal<Stack> StackModal { get; set; } = new();
        public Modal<Vpc> VpcModal { get; set; } = new();
    }

    public class Modal<T> where T : new()
    {
        public bool Visible { get; set; }
        public T Data { get; set; } = new();

        public void Toggle()
        {
            Visible = !Visible;
            CallRequestRefresh();
        }

        public event Action? RefreshRequested;

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }


    }


}