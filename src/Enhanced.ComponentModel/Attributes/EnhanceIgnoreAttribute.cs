using System;

namespace Enhanced.ComponentModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Event)]
    public class EnhanceIgnoreAttribute : Attribute
    {
    }
}