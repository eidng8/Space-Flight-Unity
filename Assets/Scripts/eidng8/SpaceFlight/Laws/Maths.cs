// ---------------------------------------------------------------------------
// <copyright file="Maths.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Laws
{
    public static class MathsExtension
    {
        public static bool AboutEqual(
            this float a,
            float b,
            float tolerance = float.Epsilon
        ) =>
            (a - b).AboutZero(tolerance);

        public static bool AboutZero(
            this float a,
            float tolerance = float.Epsilon
        ) {
            tolerance = Mathf.Abs(tolerance);
            return a >= -tolerance && a <= tolerance;
        }

        public static bool IsFacing(
            this Vector3 a,
            Vector3 b,
            float tolerance
        ) {
            float ang = Mathf.Abs(Vector3.Angle(a, b));
            tolerance = Mathf.Abs(tolerance);
            tolerance = Mathf.Clamp(tolerance, 0, 360);
            return ang <= tolerance;
        }

        /// <summary>
        /// Validate that the given value is negative and call the
        /// corresponding delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        /// Delegate to be called when the validation
        /// passes.
        /// </param>
        /// <param name="falseFunc">
        /// Delegate to be called when the validation
        /// fails.
        /// </param>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        public static string ValidateNegativeValue(
            this float v,
            string subject,
            Action trueFunc = null,
            Action falseFunc = null
        ) {
            if (v < 0) {
                trueFunc?.Invoke();
                return "";
            }

            falseFunc?.Invoke();
            return $"{subject} must be negative!";
        }


        /// <summary>
        /// Validate that the given value is positive and call the
        /// corresponding delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        /// Delegate to be called when the validation
        /// passes.
        /// </param>
        /// <param name="falseFunc">
        /// Delegate to be called when the validation
        /// fails.
        /// </param>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        public static string ValidatePositiveValue(
            this float v,
            string subject,
            Action trueFunc = null,
            Action falseFunc = null
        ) {
            if (v > 0) {
                trueFunc?.Invoke();
                return "";
            }

            falseFunc?.Invoke();
            return $"{subject} must be greater than zero!";
        }
    }
}
