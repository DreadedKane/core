/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;

namespace HomewreckersStudio
{
    public sealed class CoreTests : MonoBehaviour
    {
        /** Used to verify the events were invoked. */
        private bool m_eventInvoked;

        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestEvents();
            TestSingleton();
            TestStrings();

            Debug.Log("Unit tests complete");
        }

        /**
         * Verifies events can be invoked properly.
         */
        private void TestEvents()
        {
            Debug.Log("Testing events");

            // Tests event with no parameters
            m_eventInvoked = false;

            Event.Invoke(OnEvent);

            Assert.IsTrue(m_eventInvoked, "Couldn't invoke event");

            // Tests event with one parameter
            m_eventInvoked = false;

            Event.Invoke(OnEvent, true);

            Assert.IsTrue(m_eventInvoked, "Couldn't invoke event with one parameter");

            // Tests event with two parameters
            m_eventInvoked = false;

            Event.Invoke(OnEvent, true, true);

            Assert.IsTrue(m_eventInvoked, "Couldn't invoke event with two parameters");
        }

        /**
         * Sets the event invoked flag.
         */
        private void OnEvent()
        {
            m_eventInvoked = true;
        }

        /**
         * Verifies the parameter and sets the event invoked flag.
         */
        private void OnEvent(bool parameter)
        {
            Assert.IsTrue(parameter);

            m_eventInvoked = true;
        }

        /**
         * Verifies the parameters and sets the event invoked flag.
         */
        private void OnEvent(bool parameter1, bool parameter2)
        {
            Assert.IsTrue(parameter1 && parameter2);

            m_eventInvoked = true;
        }

        /**
         * Verifies the singleton is not null and the property is valid.
         */
        private void TestSingleton()
        {
            Debug.Log("Testing singleton");

            Assert.IsNotNull(SingletonTest.Instance, "Couldn't get singleton");

            Assert.IsTrue(SingletonTest.Instance.Test, "Invalid response");
        }

        /**
         * Verifies we can compare two strings ignoring case.
         */
        private void TestStrings()
        {
            Debug.Log("Testing strings");

            bool equals = String.CompareInsensitive("Testing", "tEsTiNg");

            Assert.IsTrue(equals, "Couldn't compare strings");
        }
    }
}
