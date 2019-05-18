using System;
using System.Reflection;

namespace ChefSnacks.Web.Common.Extensions
{
    public static class EnumExtensions
    {
        public static TAttr GetAttribute<TAttr>(this Enum value)
            where TAttr : Attribute
        {
            if (value == null)
                return null;

            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            if (fieldInfo == null)
                return null;

            var atts = (TAttr[])fieldInfo.GetCustomAttributes(typeof(TAttr), false);
            return atts.Length > 0 ? atts[0] : null;
        }
    }
}