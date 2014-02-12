using Caliburn.Micro;
using _01_Initialization.ViewModels;

namespace _01_Initialization
{

    // 1. MainWidow.xaml löschen
    // 2. StartupUri im App.xaml löschen
    // 3. AppBootstrapper im App.xaml initialisieren
    public class AppBootstrapper: Bootstrapper<ShellViewModel>
    {
    }
}