using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor;

namespace NewBlood
{
    /// <summary>Provides the behaviour of the <see cref="DefaultInitializeOnEnterPlayModeAttribute"/> attribute.</summary>
    internal static class DefaultInitializeOnEnterPlayModeManager
    {
        /// <summary>Default-initializes any fields marked with the <see cref="DefaultInitializeOnEnterPlayModeAttribute"/> attribute.</summary>
        [InitializeOnEnterPlayMode]
        internal static void DefaultInitializeFields(EnterPlayModeOptions options)
        {
            if ((options & EnterPlayModeOptions.DisableDomainReload) == 0)
                return;

            foreach (FieldInfo field in TypeCache.GetFieldsWithAttribute<DefaultInitializeOnEnterPlayModeAttribute>())
            {
                var attribute = field.GetCustomAttribute<DefaultInitializeOnEnterPlayModeAttribute>();

                // Only static fields can be marked with [DefaultInitializeOnEnterPlayModeAttribute]. There is unfortunately no
                // way to specify that the compiler should validate this statically, so should we display an error for usages of
                // the attribute on non-static fields?

                if (!field.IsStatic)
                    continue;

                if (attribute.Value != null)
                {
                    field.SetValue(null, attribute.Value);
                    continue;
                }

                if (attribute.InitializeType == DefaultInitializeType.NewInstance)
                {
                    field.SetValue(null, Activator.CreateInstance(field.FieldType));
                }
                else if (field.FieldType.IsValueType)
                {
                    field.SetValue(null, RuntimeHelpers.GetUninitializedObject(field.FieldType));
                }
                else
                {
                    field.SetValue(null, null);
                }
            }
        }
    }
}
