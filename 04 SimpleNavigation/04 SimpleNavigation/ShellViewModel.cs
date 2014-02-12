﻿using Caliburn.Micro;

namespace _04_SimpleNavigation
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ShowPageOne();
        }

        public void ShowPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }
    }
}