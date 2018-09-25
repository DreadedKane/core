/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;

namespace HomewreckersStudio
{
    /**
     * Helper class for list operations.
     */
    public static class ListExtensions
    {
        /**
         * Is the list null or empty?
         */
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }

        /**
         * Gets the index of the last item in the list.
         */
        public static int LastIndex<T>(this List<T> list)
        {
            return list.Count - 1;
        }

        /**
         * Gets the first item in the list or returns null.
         */
        public static T GetFirst<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty())
            {
                return default(T);
            }
            else
            {
                return list[0];
            }
        }

        /**
         * Gets the last item in the list or returns null.
         */
        public static T GetLast<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty())
            {
                return default(T);
            }
            else
            {
                var index = list.LastIndex();

                return list[index];
            }
        }
    }
}
