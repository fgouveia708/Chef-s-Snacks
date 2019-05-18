using System;

namespace ChefSnacks.Core.Attributes
{
    public class EnumAttribute : Attribute
    {
        public int Value { get; set; }
    }
}