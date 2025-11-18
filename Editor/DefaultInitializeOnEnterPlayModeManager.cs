using System;
using System.Reflection;
using UnityEditor;

namespace NewBlood
{
    /// <summary>Provides the behaviour of the <see cref="DefaultInitializeOnEnterPlayModeAttribute"/> attribute.</summary>
    internal static class DefaultInitializeOnEnterPlayModeManager
    {
        /// <summary>Default-initializes any fields marked with the <see cref="DefaultInitializeOnEnterPlayModeAttribute"/> attribute.</summary>
        [InitializeOnEnterPlayMode]
        internal static void DefaultInitializeFields()
        {
            foreach (FieldInfo field in TypeCache.GetFieldsWithAttribute<DefaultInitializeOnEnterPlayModeAttribute>())
            {
                var attribute = field.GetCustomAttribute<DefaultInitializeOnEnterPlayModeAttribute>();

                // Only static fields can be marked with [DefaultInitializeOnEnterPlayModeAttribute]. There is unfortunately no
                // way to specify that the compiler should validate this statically, so should we display an error for usages of
                // the attribute on non-static fields?

                if (field.IsStatic)
                {
                    if (field.FieldType.IsValueType)
                    {
                        field.SetValue(null, attribute.Value ?? Activator.CreateInstance(field.FieldType));
                    }
                    else
                    {
                        field.SetValue(null, attribute.Value);
                    }
                }
            }
        }
    }
}
