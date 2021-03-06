﻿namespace CaliburnProto.Infrastructure
{
    public interface IActionItemManager
    {
        IActionItemManager WithScopeOf(object model);
        /// <summary>
        /// Allows for nesting the <see cref="IActionItem"/>
        /// </summary>
        /// <param name="parentName">The anme of the parent action item.</param>
        /// <returns></returns>
        IActionItemManager WithParent(string parentName);
        IActionItemManager ShowItem(IActionItem item);
        void Clear();
    }

    public interface IMenuManager : IActionItemManager
    {
    }

    public interface IToolBarManager : IActionItemManager
    {
    }
}
