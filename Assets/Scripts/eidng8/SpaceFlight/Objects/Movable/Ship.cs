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
using UnityEngine;

namespace eidng8.SpaceFlight.Objects.Movable
{
    public partial class Ship : SpaceObject, IMovableObject
    {
        public virtual void Pan(Vector3 force) {
            // Make sure there will be no force applied to forward/backward
            // direction.
            // We first project the given vector on to the forward vector
            // to find out how much force is applied in that direction.
            // Then subtract it.
            Vector3 vp = Vector3.Project(force, this.transform.forward);
            force -= vp;
            this.Body.AddForce(force);
        }

        public virtual void PanThrottle(Vector3 throttle) {
            this.Pan(this.MaxPan * throttle);
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Please note that <see cref="Speed" /> and
        ///     <see cref="Acceleration" /> will change after this method is
        ///     called.
        /// </remarks>
        public virtual void Propel(float force) {
            this.mLastSpeed = this.mSpeed;
            force = Mathf.Clamp(force, -this.MaxReverse, this.mMaxForward);
            this.Body.AddRelativeForce(Vector3.forward * force);
            this.mSpeed = this.Velocity.magnitude;
            this.mAcceleration =
                (this.mSpeed - this.mLastSpeed) / Time.fixedDeltaTime;
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
            this.Body.AddRelativeTorque(torque);
        }

        public virtual void RotateThrottle(Vector3 throttle) {
            this.Rotate(this.MaxTorque * throttle);
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
    }
}
