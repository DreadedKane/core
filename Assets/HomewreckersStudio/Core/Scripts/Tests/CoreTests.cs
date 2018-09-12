/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    /**
     * Performs unit tests on the module.
     */
    public sealed class CoreTests : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to display the downloaded sprite.")]
        private Image m_spriteImage;

        [SerializeField]
        [Tooltip("Used to test transform angles.")]
        private Transform m_transformAngleTest;

        /** Used to test requests. */
        private RequestTests m_requestTests;

        /** Used to test sprite downloading. */
        private SpriteDownload m_spriteDownload;

        /** Used to verify the events were invoked. */
        private bool m_eventInvoked;

        /**
         * Adds the required components.
         */
        private void Awake()
        {
            m_requestTests = new RequestTests();

            m_spriteDownload = gameObject.AddComponent<SpriteDownload>();
        }

        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestEvents();
            TestRequests();
            TestSingleton();
            TestSpriteDownload();
            TestStrings();
            TestPlatformDependent();
            TestMath();

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
         * Defers to the request test object.
         */
        private void TestRequests()
        {
            m_requestTests.Test();
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
         * Verifies string comparison and resolution string.
         */
        private void TestStrings()
        {
            Debug.Log("Testing strings");

            // Tests compare
            bool compareResult = String.CompareInsensitive("Testing", "tEsTiNg");

            Assert.IsTrue(compareResult, "Couldn't compare strings");

            // Tests resolution
            Resolution resolution = new Resolution()
            {
                width = 1024,
                height = 768,
                refreshRate = 60
            };

            string resolutionString = String.FromResolution(resolution);

            bool resolutionResult = resolutionString.Equals("1024x768 60Hz");

            Assert.IsTrue(resolutionResult, "Invalid resolution string");
        }

        /**
         * Tests platform dependent game objects.
         */
        private void TestPlatformDependent()
        {
            Debug.Log("Testing platform dependent objects");

            GameObject windowsOnly = GameObject.FindWithTag("WindowsOnly");
            GameObject androidOnly = GameObject.FindWithTag("AndroidOnly");

#if UNITY_STANDALONE_WIN

            Assert.IsNotNull(windowsOnly, "Platform dependent test failed");
            Assert.IsNull(androidOnly, "Platform dependent test failed");

#elif UNITY_ANDROID

            Assert.IsNotNull(androidOnly, "Platform dependent test failed");
            Assert.IsNull(windowsOnly, "Platform dependent test failed");

#endif // UNITY_STANDALONE_WIN
        }

        /**
         * Tests the math class.
         */
        private void TestMath()
        {
            Debug.Log("Testing math");

            // Tests validity
            float value = 0.1234567f;

            Assert.IsFalse(Math.IsValid(float.NaN), "Validity test failed");
            Assert.IsFalse(Math.IsValid(float.PositiveInfinity), "Validity test failed");
            Assert.IsTrue(Math.IsValid(value), "Validity test failed");

            // Tests equality
            float oneThird = 1f / 3f;

            Assert.IsTrue(Math.Equals(oneThird, .333333f), "Equality test failed");

            // Tests inverse square
            Assert.AreEqual(Math.InverseSquare(.25f), .5f, "Inverse square test failed");

            // Tests angle clamping
            float angle = Math.ClampAngle(1170f);
            float tolerance = 0.001f;

            Assert.AreApproximatelyEqual(angle, 90f, tolerance, "Angle clamping test failed");

            // Tests transform pitch
            float pitch = Math.Pitch(m_transformAngleTest);

            Assert.AreApproximatelyEqual(pitch, 20f, tolerance, "Transform pitch test failed");

            // Tests transform yaw
            float yaw = Math.Yaw(m_transformAngleTest);

            Assert.AreApproximatelyEqual(yaw, 130f, tolerance, "Transform yaw test failed");

            // Tests transform roll
            float roll = Math.Roll(m_transformAngleTest);

            Assert.AreApproximatelyEqual(roll, 60f, tolerance, "Transform roll test failed");
        }
    }
}
