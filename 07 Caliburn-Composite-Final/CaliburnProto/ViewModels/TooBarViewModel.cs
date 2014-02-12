using System.Collections.Generic;
using System.ComponentModel.Composition;
using CaliburnProto.Framework;
using CaliburnProto.Infrastructure;

namespace CaliburnProto.ViewModels
{
    [Export(typeof(IToolBarManager))]
    [Export(typeof(ToolBarViewModel))]
    public class ToolBarViewModel : ActionItemManager, IToolBarManager
    {
        [ImportingConstructor]
        public ToolBarViewModel([ImportMany] IEnumerable<IActionItem> actionItems)
        {
            foreach (var toolBarViewModel in actionItems)
                Items.Add(toolBarViewModel);
        }
    }
}
