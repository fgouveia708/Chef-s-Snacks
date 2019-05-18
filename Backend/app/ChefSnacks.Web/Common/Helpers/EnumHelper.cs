using ChefSnacks.Core.Attributes;
using ChefSnacks.Web.Common.Extensions;
using System;
using System.Collections.Generic;

namespace ChefSnacks.Web.Common.Helpers
{
    public class EnumHelper
    {
        public static IList<TEnum> Read<TEnum>()
        {
            var result = new List<TEnum>();

            foreach (var en in Enum.GetValues(typeof(TEnum)))
                result.Add((TEnum)en);

            return result;
        }

        public static IList<TAttr> Read<TEnum, TAttr>()
            where TAttr : EnumAttribute
        {
            var result = new List<TAttr>();

            foreach (Enum en in Enum.GetValues(typeof(TEnum)))
            {
                var attr = en.GetAttribute<TAttr>();

                attr.Value = Convert.ToInt32(en);
                result.Add(attr);
            }

            return result;
        }
    }
}