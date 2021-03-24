using System;

namespace NewBlood
{
    /// <summary>Marks a static field for default-initialization at load time.</summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DefaultInitializeOnLoadAttribute : Attribute
    {
    }
}
