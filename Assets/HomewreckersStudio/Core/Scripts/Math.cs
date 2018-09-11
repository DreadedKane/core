/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Helper class for math calculations.
     */
    public static class Math
    {
        /**
         * Clamps the angle between -180 and 180 degrees.
         */
        public static float ClampAngle(float angle)
        {
            while (angle > 180f)
            {
                angle -= 360f;
            }

            while (angle < -180f)
            {
                angle += 360f;
            }

            return angle;
        }

        /**
         * Gets the pitch angle of the transform.
         */
        public static float Pitch(Transform transform)
        {
            return ClampAngle(transform.eulerAngles.x);
        }

        /**
         * Gets the yaw angle of the transform.
         */
        public static float Yaw(Transform transform)
        {
            return ClampAngle(transform.eulerAngles.y);
        }

        /**
         * Gets the roll angle of the transform.
         */
        public static float Roll(Transform transform)
        {
            return ClampAngle(transform.eulerAngles.z);
        }
    }
}
