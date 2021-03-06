namespace CaliburnProto {

using System.ComponentModel.Composition;
using ViewModels;

    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        [Import]
        public DockViewModel DockRegion { get; set; }

        [Import]
        public MenuViewModel MenuRegion { get; set; }

        [Import]
        public ToolBarViewModel ToolBarRegion { get; set; }

    }
}
