/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Base class for asynchronous components.
     */
    public abstract class Request : MonoBehaviour
    {
        /** Invoked when the request succeeds. */
        private event Action m_success;

        /** Invoked when the request fails. */
        private event Action m_failure;

        /** Is the request active? */
        protected bool m_active;

        /**
         * Adds a listener to the success delegate.
         */
        protected void AddSuccessListener(Action listener)
        {
            m_success += listener;
        }

        /**
         * Adds a listener to the failure delegate.
         */
        protected void AddFailureListener(Action listener)
        {
            m_failure += listener;
        }

        /**
         * Adds listeners to the callback delegates.
         */
        protected void SetEvents(Action success, Action failure)
        {
            AddSuccessListener(success);
            AddFailureListener(failure);
        }

        /**
         * Invokes the success event.
         */
        protected void OnSuccess()
        {
            Event.Invoke(m_success);

            ClearEvents();
        }

        /**
         * Invokes the failure event.
         */
        protected void OnFailure()
        {
            Event.Invoke(m_failure);

            ClearEvents();
        }

        /**
         * Clears all the delegates and marks the request inactive.
         */
        protected virtual void ClearEvents()
        {
            m_success = null;
            m_failure = null;

            m_active = false;
        }
    }

    /**
     * Base class for asynchronous components with one parameter.
     */
    public abstract class Request<T> : Request
    {
        /** Invoked when the request succeeds with one parameter. */
        private event Action<T> m_success;

        /** Invoked when the request fails with one parameter. */
        private event Action<T> m_failure;

        /**
         * Adds listeners to the callback delegates.
         */
        protected void SetEvents(Action<T> success, Action failure)
        {
            AddFailureListener(failure);

            m_success += success;
        }

        /**
         * Adds listeners to the callback delegates.
         */
        protected void SetEvents(Action success, Action<T> failure)
        {
            AddSuccessListener(success);

            m_failure += failure;
        }

        /**
         * Adds listeners to the callback delegates.
         */
        protected void SetEvents(Action<T> success, Action<T> failure)
        {
            m_success += success;
            m_failure += failure;
        }

        /**
         * Invokes the success event with one parameter.
         */
        protected void OnSuccess(T parameter)
        {
            Event.Invoke(m_success, parameter);

            ClearEvents();
        }

        /**
         * Invokes the failure event with one parameter.
         */
        protected void OnFailure(T parameter)
        {
            Event.Invoke(m_failure, parameter);

            ClearEvents();
        }

        /**
         * Clears all the delegates.
         */
        protected override void ClearEvents()
        {
            base.ClearEvents();

            m_success = null;
            m_failure = null;
        }
    }
}
