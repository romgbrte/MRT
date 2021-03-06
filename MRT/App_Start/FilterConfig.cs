﻿using System.Web;
using System.Web.Mvc;

namespace MRT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute(true));
        }
    }
}
