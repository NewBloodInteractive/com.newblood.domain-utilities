#nullable enable

using System;

namespace NewBlood
{
    /// <summary>Marks a static field for default-initialization on entering play mode.</summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DefaultInitializeOnEnterPlayModeAttribute : Attribute
    {
        /// <summary>The initialization type to use when <see cref="Value"/> is <see langword="null"/>.</summary>
        public DefaultInitializeType InitializeType { get; }

        /// <summary>The default value that the field will be initialized to, if any.</summary>
        public object? Value { get; }

        /// <summary>Default-initializes the marked field.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(DefaultInitializeType type = DefaultInitializeType.Default) => InitializeType = type;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(bool value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(byte value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(sbyte value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(ushort value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(short value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(uint value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(int value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(ulong value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(long value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(float value) => Value = value;

        /// <summary>Initializes the marked field with the provided default value.</summary>
        public DefaultInitializeOnEnterPlayModeAttribute(double value) => Value = value;
    }
}
