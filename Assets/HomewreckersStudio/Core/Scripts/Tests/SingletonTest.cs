﻿/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

namespace HomewreckersStudio
{
    public sealed class SingletonTest : Singleton<SingletonTest>
    {
        /**
         * Returns true for the unit test.
         */
        public bool Test
        {
            get
            {
                return true;
            }
        }
    }
}
