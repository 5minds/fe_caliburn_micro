using System;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using Action = System.Action;

namespace CaliburnProto.Infrastructure
{
    /// <summary>
    /// View model for an action item.
    /// </summary>
    public class ActionItem : PropertyChangedBase, IActionItem
    {
        protected ActionItem(string displayName)
        {
            DisplayName = displayName;
            DisplayNameShort = displayName;
            Name = displayName;
            IconName = "";
            _execute =  (() => { });
            _canExecute = (() => IsActive);
        }

        /// <summary>
        /// Initializes a new instance of ActionItem class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public ActionItem(string displayName, Action execute, Func<bool> canExecute = null)
            :this(displayName)
        {
            _execute = execute ?? (()=>{});
            _canExecute = canExecute ?? (() => IsActive);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyOfPropertyChange(() => Name); }
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; NotifyOfPropertyChange(()=> DisplayName); }
        }

        private string _iconName;
        public string IconName
        {
            get { return _iconName; }
            set { _iconName = value; NotifyOfPropertyChange(() => IconName); }
        }



        private string _displayNameShort;
        public string DisplayNameShort
        {
            get { return _displayNameShort; }
            set { _displayNameShort = value; NotifyOfPropertyChange(() => DisplayNameShort); }
        }

        private string _toolTip;
        public string ToolTip
        {
            get { return _toolTip; }
            set { _toolTip = value; NotifyOfPropertyChange(() => ToolTip); }
        }

        private readonly ObservableCollection<IActionItem> _items = new ObservableCollection<IActionItem>();
        public ObservableCollection<IActionItem> Items
        {
            get { return _items; }
        }

        #region Execution
        private readonly Action _execute;
        /// <summary>
        /// The action associated to the ActionItem
        /// </summary>
        public virtual void Execute()
        {
            _execute();
        }

        private readonly Func<bool> _canExecute;
        /// <summary>
        /// Calls the underlying canExecute function.
        /// </summary>
        public virtual bool CanExecute
        {
            get { return _canExecute(); }
        }
        #endregion

        #region Activation & Deactivation
        public event EventHandler<ActivationEventArgs> Activated;
        public event EventHandler<DeactivationEventArgs> AttemptingDeactivation;
        public event EventHandler<DeactivationEventArgs> Deactivated;

        private bool _isActive = true;
        public bool IsActive
        {
            get { return _isActive; }
        }

        public void Activate()
        {
            if (IsActive)
                return;

            _isActive = true;
            OnActivate();
            if(Activated != null)
                Activated(this, new ActivationEventArgs {WasInitialized = false});
            NotifyOfPropertyChange(() => CanExecute);
        }
        protected virtual void OnActivate(){}

        public virtual void Deactivate(bool close)
        {
            if(!IsActive)
                return;

            if (AttemptingDeactivation != null)
                AttemptingDeactivation(this, new DeactivationEventArgs{WasClosed = close});

            _isActive = false;
            OnDeactivate(close);
            NotifyOfPropertyChange(() => CanExecute);
            if (Deactivated != null)
                Deactivated(this, new DeactivationEventArgs{WasClosed = close});
        }
        protected virtual void OnDeactivate(bool close) { }
        #endregion
    }
}
