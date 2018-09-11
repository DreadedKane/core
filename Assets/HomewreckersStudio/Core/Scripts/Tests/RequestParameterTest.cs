/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;

namespace HomewreckersStudio
{
    /**
     * Used by the unit tests to test requests with parameters.
     */
    public sealed class RequestParameterTest : Request<bool>
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
         * Invokes the success event with one parameter.
         */
        public void TestSuccess(Action<bool> success, Action failure)
        {
            SetEvents(success, failure);

            OnSuccess(true);
        }

        /**
         * Invokes the success event with one parameter.
         */
        public void TestSuccess(Action<bool> success, Action<bool> failure)
        {
            SetEvents(success, failure);

            OnSuccess(true);
        }

        /**
         * Invokes the failure event.
         */
        public void TestFailure(Action success, Action failure)
        {
            SetEvents(success, failure);

            OnFailure();
        }

        /**
         * Invokes the failure event with one parameter.
         */
        public void TestFailure(Action success, Action<bool> failure)
        {
            SetEvents(success, failure);

            OnFailure(true);
        }

        /**
         * Invokes the failure event with one parameter.
         */
        public void TestFailure(Action<bool> success, Action<bool> failure)
        {
            SetEvents(success, failure);

            OnFailure(true);
        }
    }
}
