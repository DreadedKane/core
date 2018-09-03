/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;

namespace HomewreckersStudio
{
    public sealed class RequestTest : Request
    {
        /**
         * Invokes the success event.
         */
        public void TestSuccess(Action success, Action failure)
        {
            SetEvents(success, failure);

            OnSuccess();
        }

        /**
         * Invokes the failure event.
         */
        public void TestFailure(Action success, Action failure)
        {
            SetEvents(success, failure);

            OnFailure();
        }
    }
}
