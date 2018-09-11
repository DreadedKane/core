/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;

namespace HomewreckersStudio
{
    /**
     * Helper class for invoking events.
     */
    public static class Event
    {
        /**
         * Invokes an action if it's valid.
         */
        public static void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        /**
         * Invokes an action with one parameter if it's valid.
         */
        public static void Invoke<T>(Action<T> action, T parameter)
        {
            if (action != null)
            {
                action(parameter);
            }
        }

        /**
         * Invokes an action with two parameters if it's valid.
         */
        public static void Invoke<T1, T2>(Action<T1, T2> action, T1 parameter1, T2 parameter2)
        {
            if (action != null)
            {
                action(parameter1, parameter2);
            }
        }
    }
}
