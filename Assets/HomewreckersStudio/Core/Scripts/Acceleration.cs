/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Accelerates and decelerates a float value.
     */
    public sealed class Acceleration : MonoBehaviour
    {
        /** The current speed value. */
        private float m_speed;

        /** The rate of acceleration. */
        private float m_rate;

        /** The strength of the acceleration. */
        private float m_input;

        /** The maximum allowed speed. */
        private float m_maxSpeed;

        /**
         * Gets the current velocity.
         */
        public float Speed
        {
            get
            {
                return m_speed;
            }
        }

        /**
         * Sets the rate of acceleration and deceleration.
         */
        public float Rate
        {
            set
            {
                m_rate = value;
            }
        }

        /**
         * Sets the strength of the acceleration.
         */
        public float Input
        {
            set
            {
                m_input = value;
            }
        }

        /**
         * Sets the maximum allowed velocity.
         */
        public float MaxSpeed
        {
            set
            {
                m_maxSpeed = value;
            }
        }

        /**
         * Accelerates or decelerates the speed value.
         */
        private void Update()
        {
            float maxSpeed = Mathf.Abs(m_input * m_maxSpeed);

            if (Mathf.Abs(m_speed) > maxSpeed)
            {
                Decelerate();
            }
            else
            {
                Accelerate(maxSpeed);
            }
        }

        /**
         * Applies acceleration to the speed value.
         */
        private void Accelerate(float maxSpeed)
        {
            m_speed += m_rate * m_input * Time.deltaTime;

            m_speed = Mathf.Clamp(m_speed, -maxSpeed, maxSpeed);
        }

        /**
         * Applies deceleration to the speed value.
         */
        private void Decelerate()
        {
            if (m_speed > 0f)
            {
                m_speed -= m_rate * Time.deltaTime;

                if (m_speed < 0f)
                {
                    m_speed = 0f;
                }
            }
            else if (m_speed < 0f)
            {
                m_speed += m_rate * Time.deltaTime;

                if (m_speed > 0f)
                {
                    m_speed = 0f;
                }
            }
        }
    }
}
