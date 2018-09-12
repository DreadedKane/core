/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;

namespace HomewreckersStudio
{
    /**
     * Helper class for asynchronous requests.
     */
    public sealed class Request
    {
        /** Invoked when the request succeeds. */
        private event Action m_success;

        /** Invoked when the request fails. */
        private event Action m_failure;

        /**
         * Adds listeners to the callback delegates.
         */
        public void SetListeners(Action success, Action failure)
        {
            m_success = success;
            m_failure = failure;
        }

        /**
         * Invokes the success event.
         */
        public void OnSuccess()
        {
            Event.Invoke(m_success);
        }

        /**
         * Invokes the failure event.
         */
        public void OnFailure()
        {
            Event.Invoke(m_failure);
        }
    }
}
