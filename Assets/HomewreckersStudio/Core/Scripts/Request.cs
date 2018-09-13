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
         * Is the request currently active?
         */
        public bool Active { get; private set; }

        /**
         * Adds listeners to the callback delegates.
         */
        public void SetListeners(Action success, Action failure)
        {
            if (Active)
            {
                m_success += success;
                m_failure += failure;
            }
            else
            {
                Active = true;

                m_success = success;
                m_failure = failure;
            }
        }

        /**
         * Invokes the success event.
         */
        public void OnSuccess()
        {
            if (Active)
            {
                Active = false;

                Event.Invoke(m_success);
            }
        }

        /**
         * Invokes the failure event.
         */
        public void OnFailure()
        {
            if (Active)
            {
                Active = false;

                Event.Invoke(m_failure);
            }
        }

        /**
         * Flags the request as inactive.
         */
        public void Cancel()
        {
            Active = false;
        }
    }
}
