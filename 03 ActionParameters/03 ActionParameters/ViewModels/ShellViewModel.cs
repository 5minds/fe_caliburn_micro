using Caliburn.Micro;

namespace _03_ActionParameters.ViewModels
{
    public class ShellViewModel: PropertyChangedBase
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

        public void IncrementCount(int delta)
        {
            Count += delta;
        }

        public bool CanIncrementCount
        {
            get { return Count < 100; }
        }

        //Special Parameter sind sinnvoll z.B.: in Listen
        public void TestSpecialParameter(object eventArgs, object dataContext, object source, object view, object executionContext, object this_)
        {

        }

    }
}