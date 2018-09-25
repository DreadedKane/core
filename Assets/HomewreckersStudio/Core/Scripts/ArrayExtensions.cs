/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

namespace HomewreckersStudio
{
    /**
     * Helper class for array operations.
     */
    public static class ArrayExtensions
    {
        /**
         * Is the array null or empty?
         */
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }

        /**
         * Does the array contain this index?
         */
        public static bool HasIndex<T>(this T[] array, int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * Gets the first element of the array or returns null.
         */
        public static T GetFirst<T>(this T[] array)
        {
            if (array.IsNullOrEmpty())
            {
                return default(T);
            }
            else
            {
                return array[0];
            }
        }

        /**
         * Gets the last element of the array or returns null.
         */
        public static T GetLast<T>(this T[] array)
        {
            if (array.IsNullOrEmpty())
            {
                return default(T);
            }
            else
            {
                return array[array.Length - 1];
            }
        }
    }
}
