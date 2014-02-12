using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using CaliburnProto.Framework;
using CaliburnProto.Infrastructure;

namespace CaliburnProto.Customer.ViewModels
{
    [Export(typeof(IDockViewModel))]
    [Export(typeof(CustomerModuleViewModel))]
    public class CustomerModuleViewModel : Screen, IDockViewModel
    {

        private IMenuManager _menuManager;
        private IDockWindowManager _windowManager;

        [ImportingConstructor]
        public CustomerModuleViewModel(IMenuManager menuManager, IDockWindowManager windowManager, IToolBarManager toolBarManager)
        {
            DisplayName = "Customers";

            _menuManager = menuManager;
            _windowManager = windowManager;

            toolBarManager.ShowItem(new ActionItem("Customers", SetMenuItems) { IconName = "../Images/Customer.png" });

        }

        private void SetMenuItems()
        {
            //setup the menu
            _menuManager.Clear();
            _menuManager
                .WithParent("Custumer Menu")
                .ShowItem(new ShowCustomerAction(_windowManager))
                .WithScopeOf(this)
                .ShowItem(new AddCustomerAction());
            
        }

        public void ToggleScreen()
        {
            if (IsActive)
            {
                var deactivatable = this as IDeactivate;
                deactivatable.Deactivate(false);
            }
            else
            {
                var activatable = this as IActivate;
                activatable.Activate();
            }
        }


  

    }
}
