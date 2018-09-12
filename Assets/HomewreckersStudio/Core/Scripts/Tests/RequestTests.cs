/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;

namespace HomewreckersStudio
{
    /**
     * Performs unit tests on the request class.
     */
    public sealed class RequestTests
    {
        /** Used to invoke callbacks. */
        private Request m_request;

        /** Used to verify success. */
        private bool m_success;

        /** Used to verify failure. */
        private bool m_failure;

        /**
         * Creates the request object.
         */
        public RequestTests()
        {
            m_request = new Request();
        }

        /**
         * Runs the unit tests.
         */
        public void Test()
        {
            TestRequests();
        }

        /**
         * Tests request success and failure.
         */
        private void TestRequests()
        {
            Debug.Log("Testing requests");

            // Tests request success
            Setup();

            m_request.SetListeners(OnSuccess, OnFailure);

            m_request.OnSuccess();

            VerifySuccess();

            // Tests request failure
            Setup();

            m_request.SetListeners(OnSuccess, OnFailure);

            m_request.OnFailure();

            VerifyFailure();
        }

        /**
         * Resets the flags.
         */
        private void Setup()
        {
            m_success = false;
            m_failure = false;
        }

        /**
         * Sets the success flag.
         */
        private void OnSuccess()
        {
            m_success = true;
        }

        /**
         * Sets the failure flag.
         */
        private void OnFailure()
        {
            m_failure = true;
        }

        /**
         * Verifies the success event was invoked.
         */
        private void VerifySuccess()
        {
            Assert.IsTrue(m_success, "Request success failed");
            Assert.IsFalse(m_failure, "Request success failed");
        }

        /**
         * Verifies the failure event was invoked.
         */
        private void VerifyFailure()
        {
            Assert.IsFalse(m_success, "Request failure failed");
            Assert.IsTrue(m_failure, "Request failure failed");
        }
    }
}
