/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    [RequireComponent(typeof(SpriteDownload))]
    public sealed class CoreTests : MonoBehaviour
    {
        /** Used to test requests. */
        [SerializeField]
        private RequestTest m_requestTest;

        /** Used to display the downloaded sprite. */
        [SerializeField]
        private Image m_spriteImage;

        /** Used to test sprite downloading. */
        private SpriteDownload m_spriteDownload;

        /** Used to verify the events were invoked. */
        private bool m_eventInvoked;

        /** Used to test request success. */
        private bool m_requestSuccess;

        /** Used to test request failure. */
        private bool m_requestFailure;

        /**
         * Gets the required components.
         */
        private void Awake()
        {
            m_spriteDownload = GetComponent<SpriteDownload>();
        }

        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestEvents();
            TestRequest();
            TestSingleton();
            TestSpriteDownload();
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
         * Tests request success and failure.
         */
        private void TestRequest()
        {
            Debug.Log("Testing request");

            // Tests request success
            m_requestSuccess = false;
            m_requestFailure = false;

            m_requestTest.TestSuccess(OnRequestSuccess, OnRequestFailure);

            Assert.IsTrue(m_requestSuccess, "Request success failed");
            Assert.IsFalse(m_requestFailure, "Request success failed");

            // Tests request failure
            m_requestSuccess = false;
            m_requestFailure = false;

            m_requestTest.TestFailure(OnRequestSuccess, OnRequestFailure);

            Assert.IsFalse(m_requestSuccess, "Request failure failed");
            Assert.IsTrue(m_requestFailure, "Request failure failed");
        }

        /**
         * Sets the request success flag.
         */
        private void OnRequestSuccess()
        {
            m_requestSuccess = true;
        }

        /**
         * Sets the request failure flag.
         */
        private void OnRequestFailure()
        {
            m_requestFailure = true;
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
         * Starts downloading a test image.
         */
        private void TestSpriteDownload()
        {
            Debug.Log("Testing sprite download");

            string url = "https://via.placeholder.com/128x128";

            m_spriteDownload.Download(url, OnSpriteDownloadSuccess, OnSpriteDownloadFailure);
        }

        /**
         * Verifies the download and sets the image sprite.
         */
        private void OnSpriteDownloadSuccess()
        {
            Assert.IsNotNull(m_spriteDownload.Sprite, "Sprite is null");

            m_spriteImage.sprite = m_spriteDownload.Sprite;
        }

        /**
         * Logs an error.
         */
        private void OnSpriteDownloadFailure()
        {
            Debug.LogError("Sprite download failed");
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
