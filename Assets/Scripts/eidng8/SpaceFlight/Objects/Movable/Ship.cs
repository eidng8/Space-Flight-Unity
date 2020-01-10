// ---------------------------------------------------------------------------
// <copyright file="Ship.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using eidng8.SpaceFlight.Configurable;
using eidng8.SpaceFlight.Laws;
using UnityEngine;

namespace eidng8.SpaceFlight.Objects.Movable
{
    public partial class Ship : SpaceObject, IMovableObject
    {
        public virtual void Pan(Vector2 force) {
            // Make sure there will be no force applied to forward/backward
            // direction.
            // We first project the given vector on to the forward vector
            // to find out how much force is applied in that direction.
            // Then subtract it.
            this.Propel(new Vector3(force.x, force.y));
        }

        public virtual void PanThrottle(Vector2 throttle) {
            this.Pan(this.MaxPan * throttle);
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Please note that <see cref="Speed" /> and
        ///     <see cref="Acceleration" /> will change after this method is
        ///     called.
        /// </remarks>
        public virtual void Propel(float force) {
            this.Propel(Vector3.forward * force);
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Please note that <see cref="Speed" /> and
        ///     <see cref="Acceleration" /> will change after this method is
        ///     called.
        /// </remarks>
        public virtual void PropelThrottle(float throttle) {
            float force = throttle < 0 ? this.MaxReverse : this.MaxForward;
            this.Propel(force * throttle);
        }

        public virtual void Rotate(Vector3 torque) {
            if (torque.AboutZero()) {
                return;
            }

            this.mStabilizing = false;
            this.mPropellant[1] += torque;
        }

        public virtual void RotateThrottle(Vector3 throttle) {
            this.Rotate(this.MaxTorque * throttle);
        }

        public virtual void Stabilize() {
            this.mStabilizing = true;
        }

        public virtual void FullStop() {
            this.mStopping = true;
        }

        public virtual void Propel(Vector3 forces) {
            if (forces.AboutZero()) {
                return;
            }

            this.mStopping = false;
            this.mPropellant[0] += forces;
        }

        public virtual void Stabilize(float deltaTime) {
            Vector3 av = this.AngularVelocity;
            if (av.AboutZero()) { return; }

            Vector3 f = Newton.FullStopAngularForce(av, this.Mass);
            this.Rotate(f);
            this.mStabilizing = true;
        }

        public virtual void FullStop(float deltaTime) {
            if (this.mVelocity.AboutZero()) { return; }

            Vector3 f = Newton.FullStopForce(this.mVelocity, this.Mass);
            this.Propel(f);
            this.mStopping = true;
        }

        /// <inheritdoc />
        /// <remarks>
        ///     It is tempting to use <c>ExtendoObject</c>. But I prefer saving
        ///     runtime processing time.
        /// </remarks>
        public override void Configure(IConfigurable config) {
            float v;
            Dictionary<string, float> dict = config.Aggregate();
            if (dict.TryGetValue("mass", out v)) {
                this.Body.mass = v;
            }

            this.mMaxForward = 0;
            if (dict.TryGetValue("maxForward", out v)) {
                this.mMaxForward = v;
            }

            this.mMaxReverse = 0;
            if (dict.TryGetValue("maxReverse", out v)) {
                this.mMaxReverse = v;
            }

            this.mMaxPan = 0;
            if (dict.TryGetValue("maxPan", out v)) {
                this.mMaxPan = v;
            }

            this.mMaxTorque = 0;
            if (dict.TryGetValue("maxTorque", out v)) {
                this.mMaxTorque = v;
            }

            this.mArmor = 0;
            this.mMaxArmor = 0;
            if (dict.TryGetValue("armor", out v)) {
                this.mArmor = v;
                this.mMaxArmor = v;
            }

            this.mShield = 0;
            this.mMaxShield = 0;
            if (dict.TryGetValue("shield", out v)) {
                this.mShield = v;
                this.mMaxShield = v;
            }

            this.mPower = 0;
            if (dict.TryGetValue("power", out v)) {
                this.mPower = v;
            }

            this.mEnergy = 0;
            this.mCapacitor = 0;
            if (dict.TryGetValue("capacitor", out v)) {
                this.mCapacitor = v;
            }

            this.mRechargeRate = 0;
            if (dict.TryGetValue("recharge", out v)) {
                this.mRechargeRate = v;
            }
        }

        public virtual void Use(int component) { }

        protected virtual void FixedUpdate() {
            if (this.mStabilizing) {
                this.Stabilize(Time.fixedDeltaTime);
            }

            if (this.mStopping) {
                this.FullStop(Time.fixedDeltaTime);
            }

            this.ApplyTorque();
            this.ApplyForce();
            this.UpdateVelocity();
        }

        protected virtual void ApplyForce() {
            Vector3 forces = this.mPropellant[0];
            if (forces.AboutZero()) {
                if (this.mStopping && this.mVelocity.AboutZero()) {
                    // it ok to snap it to zero now
                    this.Body.velocity = Vector3.zero;
                    this.mStopping = false;
                }

                return;
            }

            float min = -this.MaxPan;
            Vector3 f = new Vector3(
                Mathf.Clamp(forces.x, min, this.MaxPan),
                Mathf.Clamp(forces.y, min, this.MaxPan),
                Mathf.Clamp(forces.z, -this.MaxReverse, this.MaxForward)
            );
            this.Body.AddRelativeForce(f);
            this.mPropellant[0] = Vector3.zero;
        }

        protected virtual void ApplyTorque() {
            Vector3 torque = this.mPropellant[1];
            if (torque.AboutZero()) {
                if (this.mStabilizing && this.AngularVelocity.AboutZero()) {
                    // it ok to snap it to zero now
                    this.Body.angularVelocity = Vector3.zero;
                    this.mStabilizing = false;
                }

                return;
            }

            this.Body.AddRelativeTorque(torque.ClampAxis(this.MaxTorque));
            this.mPropellant[1] = Vector3.zero;
        }

        protected virtual void UpdateVelocity() {
            this.mLastVelocity = this.mVelocity;
            this.mAngularVelocity = this.transform.InverseTransformVector(
                this.Body.angularVelocity
            );
            this.mSpeed = this.mVelocity.magnitude;
            this.mVelocity =
                this.transform.InverseTransformVector(this.Body.velocity);
            this.mAcceleration =
                (this.mVelocity - this.mLastVelocity) / Time.fixedDeltaTime;
        }
    }
}
