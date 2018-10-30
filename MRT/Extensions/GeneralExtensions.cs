using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsNull(this object obj)
        {
            bool result = (obj == null) ? true : false;

            return result;
        }

        public static bool IsNotNull(this object obj)
        {
            bool result = (obj != null) ? true : false;

            return result;
        }
    }
}