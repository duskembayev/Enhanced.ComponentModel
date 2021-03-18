using System;

namespace Enhanced.ComponentModel.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class EnhanceContainerAttribute : Attribute
    {
        public EnhanceContainerAttribute(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; }
    }
}