// ---------------------------------------------------------------------------
// <copyright file="Newton.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;

namespace eidng8.SpaceFlight.Laws
{
    /// <summary>Calculations related to Newton's Laws.</summary>
    public static class Newton
    {
        /// <summary>
        ///     Estimates the arrival time according to current velocity and
        ///     acceleration.
        /// </summary>
        /// <remarks>
        ///     <a
        ///         href="https://www.math10.com/en/algebra/formulas-for-short-multiplication.html">
        ///         Polynomial Identities
        ///     </a>
        ///     and
        ///     <a
        ///         href="https://opentextbc.ca/physicstestbook2/chapter/motion-equations-for-constant-acceleration-in-one-dimension/">
        ///         Motion
        ///     </a>
        ///     . Ah! Back to physics and maths. The two links provide lectures
        ///     needed for this calculation. Here we have to find out the time
        ///     needed to cover the distance. We use the formula with initial
        ///     speed
        ///     and constant acceleration: <c>d=vt+at²</c>. The formula is then
        ///     transformed as following:
        ///     <code>
        /// => at² + vt = d
        /// 
        /// * Both side divide by `a`
        ///          v      d
        /// => t² + ---t = ---
        ///          a      a
        /// 
        /// * We add the same "thing" to both side of the formula, to make
        /// * it a quadratic formula, so we can use Polynomial Identities.
        /// * Which reads <c>(x + y)² = x² + 2xy + y²</c>
        /// * The tricky bit here is to find that "thing".
        /// 
        ///          v       v       d      v
        /// => t² + ───t + (───)² = ─── + (───)²
        ///          a      2a       a     2a
        /// 
        ///              ^^^^^^^^       ^^^^^^^^
        /// 
        /// * Now we also need to simplify the right side a bit too.
        /// * Multiplying same "thing" to both numerator and denominator
        /// * won't change the faction.
        /// 
        ///          v       v       4ad     v
        /// => t² + ───t + (───)²  = ─── + (───)²
        ///          a      2a       4a²    2a
        ///                          ^^^
        ///                          ×`4a`
        /// 
        /// * Polynomial Identities to the left, and simplified the right
        /// 
        ///          v      4ad + v²
        /// => (t + ───)² = ────────
        ///         2a         4a²
        /// 
        /// * Square root both sides, remember the `±` sign.
        ///                 __________
        ///         v    ± √ 4ad + v²
        /// => t + ─── = ─────────────
        ///        2a         2a
        /// 
        ///           __________
        ///        ± √ 4ad + v²     v
        /// => t = ───────────── − ───
        ///             2a         2a
        /// 
        ///           __________
        ///        ± √ 4ad + v²  − v
        /// => t = ─────────────────
        ///               2a
        /// </code>
        /// </remarks>
        /// <param name="v">Current speed value.</param>
        /// <param name="a">Current acceleration value.</param>
        /// <param name="distance">Distance to be covered.</param>
        /// <returns>
        ///     The estimated time of arrival. In case of deceleration,
        ///     <c>float.PositiveInfinity</c> may be returned if it couldn't
        ///     reach
        ///     the target. The actual unit is not crucial in most
        ///     circumstances.
        ///     One could think it were in seconds.
        /// </returns>
        public static float EstimatedArrival(float v, float a, float distance) {
            //                         __________
            // We first calculate the √ 4ad + v²  part.
            // If we're decelerating, `4ad + v²` could become negative.
            // Which means we'll never reach target if decelerate.
            float n = 4 * a * Mathf.Abs(distance) + v * v;
            if (n <= 0) {
                return float.PositiveInfinity;
            }

            n = Mathf.Sqrt(n);
            float a2 = 2 * a;

            // We first check the positive sign, if it yields a positive
            // value, there is no need to check the negative part.
            float t = (n - v) / a2;
            if (t > 0) {
                return t;
            }

            // Below is actually unreachable.
            // * If `a` is positive, then `n - v` will always be positive.
            //   So the above `if` test will be fulfilled.
            // * If `a` is negative, then both `n - v` and `a2` will be
            //   negative, which will also fulfill the above `if` test.

            // Then we check the negative sign.
            t = (-n - v) / a2;
            if (t > 0) {
                return t;
            }

            // If neither yields position value, we'll just assume we could
            // never make it to the distance.
            return float.PositiveInfinity;
        }

        /// <summary>
        ///     Determines whether the object <c>a</c> should start slowing
        ///     down in
        ///     order to stop at the position of object <c>b</c>, considering
        ///     velocity of both objects.
        /// </summary>
        /// <param name="pa">Current position of object a</param>
        /// <param name="pb">Current position of object b</param>
        /// <param name="va">Current velocity of object a</param>
        /// <param name="vb">Current velocity of object b</param>
        /// <param name="a">Maximum deceleration of object a</param>
        /// <param name="buffer">Distance to keep away from object b</param>
        /// <returns>Returns <c>True</c> if <c>a</c> should slow down.</returns>
        public static bool ShouldBrake(
            Vector3 pa,
            Vector3 pb,
            Vector3 va,
            Vector3 vb,
            float a,
            float buffer
        ) {
            // Check velocity vectors first. If object b is moving away faster
            // than object a, object a can never catch up. So there's no need to
            // slow down.
            // Calculating square root is expensive. We don't need to be precise
            // here. Just take the square is sufficient.
            Vector3 vp = Vector3.Project(vb, va);
            float v = va.magnitude - vp.magnitude;
            if (v < 0) {
                return false;
            }

            // We calculate how much time is needed for the speed to reach `v`
            // with acceleration `a`. From deceleration point of view, this
            // means how much time is needed to stop completely.
            // Can't wrap around?
            // The formula of terminal speed `V` (big V), is the initial speed
            // (small v) plus `t` times constant acceleration `a`.
            // => V = v + at
            //
            // If `a` is positive, meaning accelerating. If initial speed `v`
            // (small v) is zero, then:
            // => v = 0
            // => V = at
            // => t = V ÷ a
            //
            // If `a` is negative, meaning decelerating. If terminal speed `V`
            // (big V) is zero, then:
            // => V = 0
            // => v + at = 0
            // => at = v
            // => t = |v ÷ a|
            float t = Mathf.Abs(v / a);

            // Remember to take buffer distance into account.
            float d = Vector3.Distance(pa, pb) - buffer;

            // Why:
            // => vt = D
            // => at² = D
            // Meaning if we keep current speed `v` or use the acceleration `a`
            // we can cover the distance `D` in the same period of time `t`.
            // So if we just combine both cases, we can express something like:
            // => at² + vt = 2D
            //
            // We just replace `2D` with a letter `d`. It doesn't mean that `d`
            // is same as `2D`. It's just that the distance we are discussing
            // is not important. So it doesn't matter what letter we use to
            // denote that "some distance or same distance" is traversed.
            // Deceleration is same as acceleration applied in reverse.
            // From acceleration point of view, the above means that we
            // keep accelerating the object in time `t`, and then keep the
            // terminal speed and traveling `t` time more. We end up cover
            // total distance `d`.
            // Reverse the acceleration to deceleration. Then it means at speed
            // `v` we've traveled a part of distance `d` in time `t`, then
            // decelerate in time `t`, and eventually arrived at the full
            // distance `d`.
            // Can you see when we start decelerating now? Yes, right in the
            // middle.
            return v * t / 2 >= d;
        }

        /// <summary>
        ///     Calculates the terminal speed in time <see cref="t" />
        /// </summary>
        /// <param name="v0">Initial speed value</param>
        /// <param name="a">Constant acceleration value</param>
        /// <param name="t">Duration of time</param>
        /// <returns>The terminal speed</returns>
        public static float TerminalSpeed(float v0, float a, float t) {
            return v0 + a * Mathf.Abs(t);
        }

        /// <summary>
        ///     Calculates the force needed to stop the object.
        /// </summary>
        /// <remarks>
        ///     Let's revert the thinking again. To stop an moving object is
        ///     same as
        ///     pushing the object at rest. Just revert the applied force's
        ///     direction. So to stop an moving object in time <c>t</c> is same
        ///     as
        ///     making an object at rest to the targeted speed <c>v</c>.
        ///     According to Newton's 2nd law, <c>f=ma</c>. To speed up the
        ///     object
        ///     from <c>0</c> speed, to targeted speed <c>v</c>, in time frame
        ///     <c>t</c>:
        ///     <para>
        ///         => v = at
        ///         => a = v ÷ t
        ///     </para>
        ///     Plug to Newton's 2nd law formula:
        ///     <para>
        ///         => f = mv ÷ t
        ///     </para>
        ///     And reverse the direction:
        ///     <para>
        ///         => f = -mv ÷ t
        ///     </para>
        /// </remarks>
        /// <param name="v">Current velocity</param>
        /// <param name="m">Mass</param>
        /// <param name="t">
        ///     Time to fully stopped. Please be careful not to set this lower
        ///     than
        ///     Unity's update interval, namely
        ///     <see cref="Time.fixedDeltaTime" />.
        ///     Otherwise it'll bounce around zero and can never fully stop.
        /// </param>
        /// <returns>Force needed</returns>
        public static Vector3 FullStopForce(Vector3 v, float m, float t = .1f) {
            return -m / Mathf.Abs(t) * v;
        }

        /// <summary>
        ///     Calculates the force needed to stop the object from rotating.
        /// </summary>
        /// <remarks>
        ///     Similar to <see cref="FullStopForce" />, we reverse the
        ///     thinking.
        ///     From angular motion formula:
        ///     <para>
        ///         => a = rω²
        ///         => F = mrω²
        ///     </para>
        ///     We've already have the <c>a</c>, the
        ///     <see cref="Rigidbody.angularVelocity" />, which in turn, passed
        ///     in as
        ///     the parameter <c>v</c>.
        /// </remarks>
        /// <param name="v">Current velocity</param>
        /// <param name="m">Mass</param>
        /// <param name="r">Radius of the object</param>
        /// <param name="t">
        ///     Time to fully stopped. Please be careful not to set this lower
        ///     than Unity's update interval, namely
        ///     <see cref="Time.fixedDeltaTime" />.
        ///     Otherwise it'll bounce around zero and can never fully stop.
        /// </param>
        /// <returns>Force needed</returns>
        public static Vector3 FullStopTorque(
            Vector3 v,
            float m,
            float r = 1,
            float t = .1f
        ) {
            return -m / Mathf.Abs(t) * r * v;
        }

        public static Vector3 AccelerationFromTorque(
            float torque,
            Vector3 inertia
        ) {
            return torque.InverseScale(inertia);
        }

        /// <summary>
        /// Calculate angular acceleration of a solid sphere (ball). There can
        /// be other shapes in the future if necessary.
        /// </summary>
        /// <remarks>
        /// <code>
        /// => τ = Iα
        /// => α = τ ÷ I
        /// </code>
        /// </remarks>
        /// <param name="t">torque</param>
        /// <param name="m">mass</param>
        /// <param name="r">radius</param>
        /// <returns></returns>
        public static float AccelerationFromTorque(
            float t,
            float m,
            float r = 1
        ) {
            return t / Newton.MomentInertia(m, r);
        }

        /// <summary>
        /// Calculates the moment of inertia of a solid sphere (ball).
        /// </summary>
        /// <remarks>
        /// <code>
        /// => I = 2mr² ÷ 5
        /// </code>
        /// </remarks>
        /// <param name="m"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static float MomentInertia(float m, float r = 1) {
            return .4f * m * (r.AboutEqual(1) ? 1 : Mathf.Pow(r, 2));
        }
    }
}
