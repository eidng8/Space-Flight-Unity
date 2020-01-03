﻿// ---------------------------------------------------------------------------
// <copyright file="Maths.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;


namespace eidng8.SpaceFlight.Laws
{
    public static class Maths
    {
        public static bool AboutZero(float a) =>
            a >= -float.Epsilon && a <= float.Epsilon;


        /// <summary>
        /// Validate that the given value is positive and call the corresponding
        /// delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        /// Delegate to be called when the validation passes.
        /// </param>
        /// <param name="falseFunc">
        /// Delegate to be called when the validation fails.
        /// </param>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        public static string ValidatePositiveValue(
            float v,
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

        /// <summary>
        /// Validate that the given value is negative and call the corresponding
        /// delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        /// Delegate to be called when the validation passes.
        /// </param>
        /// <param name="falseFunc">
        /// Delegate to be called when the validation fails.
        /// </param>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        public static string ValidateNegativeValue(
            float v,
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
    }
}