/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;

namespace HomewreckersStudio
{
    [RequireComponent(typeof(RequestTest))]
    [RequireComponent(typeof(RequestParameterTest))]
    public sealed class RequestTests : MonoBehaviour
    {
        /** Used to test requests. */
        private RequestTest m_requestTest;

        /** Used to test requests with one parameter. */
        private RequestParameterTest m_requestParameterTest;

        /** Used to verify success. */
        private bool m_success;

        /** Used to verify failure. */
        private bool m_failure;

        /**
         * Runs the unit tests.
         */
        public void Test()
        {
            TestRequests();
            TestParameters();
        }

        /**
         * Gets the required components.
         */
        private void Awake()
        {
            m_requestTest = GetComponent<RequestTest>();
            m_requestParameterTest = GetComponent<RequestParameterTest>();
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

        /**
         * Tests request success and failure.
         */
        private void TestRequests()
        {
            Debug.Log("Testing requests");

            // Tests request success
            Setup();

            m_requestTest.TestSuccess(OnSuccess, OnFailure);

            VerifySuccess();

            // Tests request failure
            Setup();

            m_requestTest.TestFailure(OnSuccess, OnFailure);

            VerifyFailure();
        }

        /**
         * Tests request success and failure with one parameter.
         */
        private void TestParameters()
        {
            Debug.Log("Testing request parameters");

            // Tests request success
            Setup();

            m_requestParameterTest.TestSuccess(OnSuccess, OnFailure);

            VerifySuccess();

            // Tests request success with one parameter
            Setup();

            m_requestParameterTest.TestSuccess(OnParameterSuccess, OnFailure);

            VerifySuccess();

            // Tests request success with one parameter
            Setup();

            m_requestParameterTest.TestSuccess(OnParameterSuccess, OnParameterFailure);

            VerifySuccess();

            // Tests request failure
            Setup();

            m_requestParameterTest.TestFailure(OnSuccess, OnFailure);

            VerifyFailure();

            // Tests request failure with one parameter
            Setup();

            m_requestParameterTest.TestFailure(OnSuccess, OnParameterFailure);

            VerifyFailure();

            // Tests request failure with one parameter
            Setup();

            m_requestParameterTest.TestFailure(OnParameterSuccess, OnParameterFailure);

            VerifyFailure();
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
         * Sets the success flag.
         */
        private void OnParameterSuccess(bool parameter)
        {
            m_success = parameter;
        }

        /**
         * Sets the failure flag.
         */
        private void OnParameterFailure(bool parameter)
        {
            m_failure = parameter;
        }
    }
}
