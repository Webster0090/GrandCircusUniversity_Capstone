﻿using System.Web;
using System.Web.Mvc;

namespace GrandCircusUniversity_Capstone
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
