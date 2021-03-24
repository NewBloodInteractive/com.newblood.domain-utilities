using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace NewBlood
{
    /// <summary>Provides the behaviour of the <see cref="DefaultInitializeOnLoadAttribute"/> attribute at load time.</summary>
    static class DefaultInitializeOnLoadManager
    {
        /// <summary>Default-initializes any fields marked with the <see cref="DefaultInitializeOnLoadAttribute"/> attribute.</summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void OnSubsystemRegistration()
        {
            foreach (FieldInfo field in TypeCache.GetFieldsWithAttribute<DefaultInitializeOnLoadAttribute>())
            {
                // Only static fields can be marked with [DefaultInitializeOnLoad]. There is unfortunately no way to
                // specify that the compiler should validate this statically, so should we display an error for usages
                // of the attribute on non-static fields?

                if (field.IsStatic)
                {
                    if (field.FieldType.IsValueType)
                        field.SetValue(null, Activator.CreateInstance(field.FieldType));
                    else
                        field.SetValue(null, null);
                }
            }
        }
    }
}
