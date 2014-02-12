using System;
using System.Windows;
using Caliburn.Micro;

namespace SimpleMDI
{
    public class PageOneViewModel : Screen
    {

        public PageOneViewModel()
        {
            DisplayName = "Page One";
        }



        public override void CanClose(Action<bool> callback)
        {
            callback.Invoke(MessageBox.Show(string.Format("Do you want close Page One?"),
                "Confirmation",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes);
        }
    }
}