/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using UnityEngine;

namespace HomewreckersStudio
{
    public class Request : MonoBehaviour
    {
        /** Invoked when the request succeeds. */
        private event Action m_success;

        /** Invoked when the request fails. */
        private event Action m_failure;

        /**
         * Sets the callback events.
         */
        protected void SetEvents(Action success, Action failure)
        {
            m_success = success;
            m_failure = failure;
        }

        /**
         * Invokes the success event.
         */
        protected void OnSuccess()
        {
            Event.Invoke(m_success);

            m_success = null;
            m_failure = null;
        }

        /**
         * Invokes the failure event.
         */
        protected void OnFailure()
        {
            Event.Invoke(m_failure);

            m_success = null;
            m_failure = null;
        }
    }
}
