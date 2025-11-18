using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace NewBlood
{
    internal static class StaticFieldInitializer
    {
        /// <summary>Default-initializes any fields marked with the <see cref="DefaultInitializeOnEnterPlayModeAttribute"/> attribute.</summary>
        public static void OnEnterPlayMode(EnterPlayModeOptions options)
        {
            if ((options & EnterPlayModeOptions.DisableDomainReload) == 0)
                return;

            foreach (FieldInfo field in TypeCache.GetFieldsWithAttribute<DefaultInitializeOnEnterPlayModeAttribute>())
            {
                var attribute = field.GetCustomAttribute<DefaultInitializeOnEnterPlayModeAttribute>();

                if (!field.IsStatic)
                {
                    Debug.LogError($"{nameof(DefaultInitializeOnEnterPlayModeAttribute)} applied to non-static field '{field.DeclaringType?.FullName}.{field.Name}'");
                    continue;
                }

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
