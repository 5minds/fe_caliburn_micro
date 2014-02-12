using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using CaliburnProto.Framework;
using CaliburnProto.Infrastructure;

namespace CaliburnProto.Company.ViewModels
{
    [Export(typeof(IDockViewModel))]
    [Export(typeof(CompanyModuleViewModel))]
    public sealed class CompanyModuleViewModel : Conductor<CompanyViewModel>.Collection.OneActive, IDockViewModel
    {
        private CompanyRepository _repository;
        private IMenuManager _menuManager;

        [ImportingConstructor]
        public CompanyModuleViewModel(CompanyRepository repository, IMenuManager menuManager, IToolBarManager toolBarManager)
        {
            DisplayName = "Companies";
            _repository = repository;
            _menuManager = menuManager;



            toolBarManager.ShowItem(new ActionItem("Componies", SetMenuItems) { IconName = "../Images/Company.png" });
        }

        private void SetMenuItems()
        {
            //setup the menu
            _menuManager.Clear();
            foreach (var company in _repository)
            {
                this.ActivateItem(new CompanyViewModel(company));
            }

            _menuManager.WithParent("Show Companies")
                .ShowItem(new ShowCompaniesAction())
                .ShowItem(new ShowCompaniesAction());

        }


   
    }
}
