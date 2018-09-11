/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using System.Text;
using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Helper class for string operations.
     */
    public static class String
    {
        /**
         * Compares two strings ignoring the case.
         */
        public static bool CompareInsensitive(string a, string b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            return a.Equals(b, StringComparison.InvariantCultureIgnoreCase);
        }

        /**
         * Gets a string representation of a screen resolution.
         */
        public static string FromResolution(Resolution resolution)
        {
            return string.Format("{0}x{1} {2}Hz", resolution.width, resolution.height, resolution.refreshRate);
        }

        /**
         * Gets a hexadecimal string from a byte array.
         */
        public static string FromByteArray(byte[] array, int length)
        {
            var hex = new StringBuilder(array.Length * 2);

            for (int i = 0; i < length; i++)
            {
                hex.AppendFormat("{0:x2}", array[i]);
            }

            return hex.ToString();
        }
    }
}
