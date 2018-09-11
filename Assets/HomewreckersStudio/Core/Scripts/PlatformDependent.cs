/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Destroys itself on incompatible platforms.
     */
    public sealed class PlatformDependent : MonoBehaviour
    {
        /**
         * Supported platforms.
         */
        public enum Platform
        {
            None,
            Android,
            Windows
        }

        [Header("Properties")]

        [SerializeField]
        [Tooltip("The platform this object is compatible with.")]
        private Platform m_platform;

        /**
         * Destroys the game object on incompatible platforms.
         */
        private void Awake()
        {
#if UNITY_STANDALONE_WIN

            if (m_platform != Platform.Windows)
            {
                DestroyImmediate(gameObject);
            }

#elif UNITY_ANDROID

            if (m_platform != Platform.Android)
            {
                DestroyImmediate(gameObject);
            }

#endif
        }
    }
}
