﻿namespace ZQH.Abp.UI.Navigation;

public interface IHasMenuItems
{
    /// <summary>
    /// Menu items.
    /// </summary>
    ApplicationMenuList Items { get; }
}
