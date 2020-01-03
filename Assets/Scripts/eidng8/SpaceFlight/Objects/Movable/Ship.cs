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
    public class Ship : SpaceObject, IMovableObject
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected float mArmor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mAcceleration;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxArmor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mCapacitor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mEnergy;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mLastSpeed;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxForward;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxPan;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxReverse;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxTorque;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mPower;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxShield;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mSpeed;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mRechargeRate;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mShield;

        /// <inheritdoc />
        public float Acceleration => this.mAcceleration;

        /// <summary>
        /// Current armor value.
        /// </summary>
        public float Armor => this.mArmor;

        /// <summary>
        /// Maximum armor value.
        /// </summary>
        public float MaxArmor => this.mMaxArmor;

        /// <summary>
        /// Maximum energy value.
        /// </summary>
        public float Capacitor => this.mCapacitor;

        /// <summary>
        /// Current energy value.
        /// </summary>
        public float Energy => this.mEnergy;

        /// <summary>
        /// Ship's mass.
        /// </summary>
        public float Mass => this.Body.mass;

        /// <inheritdoc />
        public float MaxForward => this.mMaxForward;

        /// <inheritdoc />
        public float MaxPan => this.mMaxPan;

        /// <inheritdoc />
        public float MaxReverse => this.mMaxReverse;

        /// <inheritdoc />
        public float MaxTorque => this.mMaxTorque;

        /// <summary>
        /// Excessive power value.
        /// </summary>
        public float Power => this.mPower;

        /// <summary>
        /// Energy recharge value per second.
        /// </summary>
        public float RechargeRate => this.mRechargeRate;

        /// <summary>
        /// Maximum shield value.
        /// </summary>
        public float MaxShield => this.mMaxShield;

        /// <summary>
        /// Current shield value.
        /// </summary>
        public float Shield => this.mShield;

        /// <inheritdoc />
        public float Speed => this.mSpeed;

        /// <inheritdoc />
        public Vector3 Velocity => this.Body.velocity;

        /// <inheritdoc />
        /// <remarks>
        /// It is tempting to use <c>ExtendoObject</c>. But I prefer saving
        /// runtime processing time.
        /// </remarks>
        public override void Configure(IConfigurable config) {
            float v;
            Dictionary<string, float> dict = config.Aggregate();
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

        /// <inheritdoc />
        /// <remarks>
        /// Please note that <see cref="Speed" /> and
        /// <see cref="Acceleration" /> will change after this method is
        /// called.
        /// </remarks>
        public void Move(Vector3 force, Vector3 torque) {
            this.mLastSpeed = this.mSpeed;
            this.Body.AddForce(force);
            this.Body.AddTorque(torque);
            this.mSpeed = this.Velocity.magnitude;
            this.mAcceleration =
                (this.mSpeed - this.mLastSpeed) / Time.fixedDeltaTime;
        }

        private void FixedUpdate() { }
    }
}
