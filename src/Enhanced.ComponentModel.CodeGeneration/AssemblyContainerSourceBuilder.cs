﻿using System;
using System.Text;

namespace Enhanced.ComponentModel.CodeGeneration
{
    internal class AssemblyContainerSourceBuilder
    {
        private const string BeginSourceText = @"
// <auto-generated>
//     This code was generated by the Enhanced.ComponentModel package.
// </auto-generated>

using Enhanced.ComponentModel;
using Enhanced.ComponentModel.Builders;

namespace {0} {{
    internal sealed class {1} : EnhancedTypeDescriptionContainer
    {{
        protected override void OnRegister()
        {{";

        private const string CloseSourceText = @"
        }
    }
}";

        private const string RegisterTypeText =
            "            Register<{0}>(\"{0}\")";

        private const string RegisterPropertyText =
            "                .AddProperty<{0}>(\"{1}\", getter: t => t.{1}, setter: (t, v) => t.{1} = v)";

        private const string RegisterPropertyWithGetterOnlyText =
            "                .AddProperty<{0}>(\"{1}\", getter: t => t.{1})";

        private const string RegisterPropertyWithSetterOnlyText =
            "                .AddProperty<{0}>(\"{1}\", setter: (t, v) => t.{1} = v)";

        private readonly StringBuilder _builder;

        public AssemblyContainerSourceBuilder()
        {
            RegisteredClassCount = 0;

            _builder = new StringBuilder();
            _builder.AppendFormat(
                BeginSourceText,
                AssemblyContainerConstants.ContainerNamespace,
                AssemblyContainerConstants.ContainerTypeName);
        }

        public int RegisteredClassCount { get; private set; }

        public void RegisterType(string typeName)
        {
            if (RegisteredClassCount++ > 0)
                CloseType();

            _builder.AppendLine();
            _builder.AppendFormat(RegisterTypeText, typeName);
        }

        public void RegisterProperty(string propertyName, string propertyTypeName, bool hasGetter, bool hasSetter)
        {
            _builder.AppendLine();

            if (hasGetter && hasSetter)
                _builder.AppendFormat(RegisterPropertyText, propertyTypeName, propertyName);
            else if (hasGetter)
                _builder.AppendFormat(RegisterPropertyWithGetterOnlyText, propertyTypeName, propertyName);
            else if (hasSetter)
                _builder.AppendFormat(RegisterPropertyWithSetterOnlyText, propertyTypeName, propertyName);
            else
                throw new InvalidOperationException();
        }

        public string Build()
        {
            if (RegisteredClassCount > 0)
                CloseType();

            _builder.Append(CloseSourceText);
            return _builder.ToString();
        }

        private void CloseType()
        {
            _builder.Append(";");
        }
    }

    public static class AssemblyContainerConstants
    {
        public const string ContainerNamespace = "Enhanced.G";
        public const string ContainerTypeName = "EnhancedContainer";
        public const string ContainerTypeFullName = ContainerNamespace + "." + ContainerTypeName;
    }
}