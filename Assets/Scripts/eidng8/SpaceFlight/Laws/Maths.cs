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
    public static class Maths
    {
        public static float epsilon = .0001f;
    }

    public static class FloatExtensions
    {
        public static bool AboutEqual(this float a, float b) {
            return (a - b).AboutEqual(b, Maths.epsilon);
        }

        public static bool AboutEqual(this float a, float b, float tolerance) {
            return (a - b).AboutZero(tolerance);
        }

        public static bool AboutZero(this float a) {
            return a.AboutZero(Maths.epsilon);
        }

        public static bool AboutZero(this float a, float tolerance) {
            tolerance = Mathf.Abs(tolerance);
            return a >= -tolerance && a <= tolerance;
        }

        /// <summary>
        ///     Validate that the given value is negative and call the
        ///     corresponding delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        ///     Delegate to be called when the validation
        ///     passes.
        /// </param>
        /// <param name="falseFunc">
        ///     Delegate to be called when the validation
        ///     fails.
        /// </param>
        /// <returns>
        ///     An error message if the validation doesn't pass, otherwise an
        ///     empty
        ///     string.
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
        ///     Validate that the given value is positive and call the
        ///     corresponding delegate if provided.
        /// </summary>
        /// <param name="v">Value to be validated.</param>
        /// <param name="subject">Subject to the error message.</param>
        /// <param name="trueFunc">
        ///     Delegate to be called when the validation
        ///     passes.
        /// </param>
        /// <param name="falseFunc">
        ///     Delegate to be called when the validation
        ///     fails.
        /// </param>
        /// <returns>
        ///     An error message if the validation doesn't pass, otherwise an
        ///     empty
        ///     string.
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

        /// <summary>
        ///     Converts meters per second to kilometers per second.
        /// </summary>
        /// <returns></returns>
        public static float Ms2Kmh(this float ms) {
            return ms * 3.6f;
        }

        /// <summary>
        ///     Converts meters per second to knot.
        /// </summary>
        /// <returns></returns>
        public static float Ms2Knot(this float ms) {
            return ms * 1.944f;
        }

        /// <summary>
        ///     Converts radian to degree.
        /// </summary>
        /// <returns></returns>
        public static float Rad2Deg(this float ms) {
            return ms * 180 / Mathf.PI;
        }

        public static Vector3 InverseScale(this float s, Vector3 v) {
            return new Vector3(s, s, s).InverseScale(v);
        }
    }

    public static class Vector3Extensions
    {
        public static bool AboutZero(this Vector3 v) {
            return v.AboutZero(Maths.epsilon);
        }

        public static bool AboutZero(this Vector3 v, float tolerance) {
            return v.x.AboutZero(tolerance)
                   && v.y.AboutZero(tolerance)
                   && v.z.AboutZero(tolerance);
        }

        public static bool IsFacing(
            this Vector3 a,
            Vector3 b,
            float tolerance = 45
        ) {
            float ang = Mathf.Abs(Vector3.Angle(a, b));
            tolerance = Mathf.Abs(tolerance);
            tolerance = Mathf.Clamp(tolerance, 0, 180);
            return ang <= tolerance;
        }

        /// <summary>
        ///     Converts meters per second to kilometers per second.
        /// </summary>
        /// <returns></returns>
        public static Vector3 Ms2Kmh(this Vector3 ms) {
            return ms * 3.6f;
        }

        /// <summary>
        ///     Converts meters per second to knot.
        /// </summary>
        /// <returns></returns>
        public static Vector3 Ms2Knot(this Vector3 ms) {
            return ms * 1.944f;
        }

        /// <summary>
        ///     Converts radian to degree.
        /// </summary>
        /// <returns></returns>
        public static Vector3 Rad2Deg(this Vector3 ms) {
            return ms * 180 / Mathf.PI;
        }

        public static Vector3 ClampAxis(
            this Vector3 v,
            Vector3 min,
            Vector3 max
        ) {
            return new Vector3(
                Mathf.Clamp(v.x, min.x, max.x),
                Mathf.Clamp(v.y, min.y, max.y),
                Mathf.Clamp(v.z, min.z, max.z)
            );
        }

        public static Vector3 ClampAxis(this Vector3 v, float min, float max) {
            return new Vector3(
                Mathf.Clamp(v.x, min, max),
                Mathf.Clamp(v.y, min, max),
                Mathf.Clamp(v.z, min, max)
            );
        }

        public static Vector3 ClampAxis(this Vector3 v, float abs) {
            float min = -abs;
            return new Vector3(
                Mathf.Clamp(v.x, min, abs),
                Mathf.Clamp(v.y, min, abs),
                Mathf.Clamp(v.z, min, abs)
            );
        }

        public static Vector3 InverseScale(this Vector3 a, Vector3 b) {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
    }
}
