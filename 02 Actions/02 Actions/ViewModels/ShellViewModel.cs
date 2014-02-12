using Caliburn.Micro;

namespace _02_Actions.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private int _count = 50;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
                NotifyOfPropertyChange(() => CanIncrementCount);
            }
        }

        public bool CanIncrementCount
        {
            get { return Count < 100; }
        }

        public void IncrementCount()
        {
            Count++;
        }
    }
}