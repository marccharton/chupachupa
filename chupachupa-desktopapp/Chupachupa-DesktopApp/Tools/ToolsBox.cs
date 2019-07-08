﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chupachupa_DesktopApp.Tools
{
    class ToolsBox
    {
        public enum TabIndex
        {
            TAB_ACCOUNT,
            TAB_CATEGORY,
            TAB_CHANNEL,
            TAB_ITEMS,
            TAB_VIEWER
        };

        public static string AccountSerializePath = @"account.data";
        public static string CategoriesSerializePath = @"categories.data";
        public static string ChannelsSerializePath = @"channels.data";
        public static string ItemsSerializePath = @"items.data";

        public static TabIndex TabOnApplicationInit = TabIndex.TAB_ITEMS;
        public static int TimeToRefreshDatas = 5; // In Minutes
    }
}
