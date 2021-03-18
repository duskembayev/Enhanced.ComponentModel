using System;
using System.Reflection;
using System.Runtime.Loader;
using Enhanced.ComponentModel.Attributes;

namespace Enhanced.ComponentModel
{
    public static class RegistrationExtensions
    {
        public static T RegisterAssemblyLoadContext<T>(this T @this, AssemblyLoadContext assemblyLoadContext)
            where T : IEnhancedTypeDescriptionProviderRegistry
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (assemblyLoadContext == null) throw new ArgumentNullException(nameof(assemblyLoadContext));

            @this.Register(new EnhancedAssemblyLoadContextContainer(assemblyLoadContext));
            return @this;
        }

        public static T RegisterDefaultAssemblyLoadContext<T>(this T @this)
            where T : IEnhancedTypeDescriptionProviderRegistry
        {
            return @this.RegisterAssemblyLoadContext(AssemblyLoadContext.Default);
        }

        public static T RegisterAssembly<T>(this T @this, Assembly assembly)
            where T : IEnhancedTypeDescriptionProviderRegistry
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));

            var containerAttribute = assembly.GetCustomAttribute<EnhanceContainerAttribute>();

            if (containerAttribute == null)
                return @this;

            var containerType = assembly.GetType(containerAttribute.TypeName)
                                ?? throw new RegistrationException();

            @this.RegisterContainer(containerType);
            return @this;
        }

        public static T RegisterContainer<T, TContainer>(this T @this)
            where T : IEnhancedTypeDescriptionProviderRegistry
            where TContainer : IEnhancedTypeDescriptionContainer
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            @this.RegisterContainer(typeof(TContainer));
            return @this;
        }

        public static T RegisterContainer<T>(this T @this, Type containerType)
            where T : IEnhancedTypeDescriptionProviderRegistry
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (containerType == null) throw new ArgumentNullException(nameof(containerType));

            var container = Activator.CreateInstance(containerType) as IEnhancedTypeDescriptionContainer
                            ?? throw new RegistrationException();

            @this.Register(container);
            return @this;
        }
    }
}