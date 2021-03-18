using System;

namespace Enhanced.ComponentModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Event | AttributeTargets.Class)]
    public class EnhanceIgnoreAttribute : Attribute
    {
    }
}