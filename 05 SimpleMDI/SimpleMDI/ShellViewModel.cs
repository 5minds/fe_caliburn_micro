using Caliburn.Micro;

namespace SimpleMDI
{
    //public class ShellViewModel : Conductor<IScreen>.Collection.OneActive 
    public class ShellViewModel : Conductor<IScreen>
    {
        private Screen _pageOne = new PageOneViewModel();
        private Screen _pageTwo = new PageTwoViewModel();
        private Screen _pageThree = new PageThreeViewModel();
        private Screen _pageFour = new PageFourViewModel();

        public void OpenPageOne()
        {
            ActivateItem(_pageOne);
        }

        public void OpenPageTwo()
        {
            ActivateItem(_pageTwo);
        }

        public void OpenPageThree()
        {
            ActivateItem(_pageThree);
        }

        public void OpenPageFour()
        {
            ActivateItem(_pageFour);
        }


    }
}