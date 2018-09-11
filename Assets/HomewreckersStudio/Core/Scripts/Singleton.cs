/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Base class for singleton game objects.
     */
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /** Used to access the object from any class. */
        private static T m_instance;

        /**
         * Gets the singleton instance.
         */
        public static T Instance
        {
            get
            {
                return m_instance;
            }
        }

        /**
         * Assigns the singleton instance or destroys the object.
         */
        protected virtual void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
