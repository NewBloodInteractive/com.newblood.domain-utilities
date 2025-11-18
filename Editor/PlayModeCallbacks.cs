#nullable enable
using System;
using UnityEditor;

namespace NewBlood
{
    /// <summary>Provides editor play mode callbacks.</summary>
    public static class PlayModeCallbacks
    {
        /// <summary>Callback invoked for the <see cref="InitializeOnEnterPlayModeAttribute"/> event.</summary>
        /// <remarks>This can be used to support configurable enter play mode in generic types by subscribing in the static constructor.</remarks>
        public static Action<EnterPlayModeOptions>? EnterPlayMode;

        [InitializeOnEnterPlayMode]
        internal static void OnEnterPlayMode(EnterPlayModeOptions options)
        {
            StaticFieldInitializer.OnEnterPlayMode(options);
            EnterPlayMode?.Invoke(options);
        }
    }
}
