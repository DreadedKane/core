/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;

namespace HomewreckersStudio
{
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
    }
}
