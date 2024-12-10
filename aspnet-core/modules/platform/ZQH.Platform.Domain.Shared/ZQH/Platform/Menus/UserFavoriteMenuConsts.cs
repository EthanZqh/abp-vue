﻿using ZQH.Platform.Routes;

namespace ZQH.Platform.Menus;
public class UserFavoriteMenuConsts
{
    public static int MaxIconLength { get; set; } = 512;
    public static int MaxColorLength { get; set; } = 30;
    public static int MaxAliasNameLength { get; set; } = RouteConsts.MaxDisplayNameLength;
}
