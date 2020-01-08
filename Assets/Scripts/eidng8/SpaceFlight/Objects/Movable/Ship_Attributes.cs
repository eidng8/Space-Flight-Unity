// ---------------------------------------------------------------------------
// <copyright file="Ship.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;

namespace eidng8.SpaceFlight.Objects.Movable
{
    public partial class Ship
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected float mAcceleration;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mArmor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mCapacitor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mEnergy;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mLastSpeed;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxArmor;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxForward;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxPan;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxReverse;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxShield;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mMaxTorque;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mPower;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mRechargeRate;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mShield;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float mSpeed;

        /// <summary>Current armor value.</summary>
        public float Armor => this.mArmor;

        /// <summary>Maximum energy value.</summary>
        public float Capacitor => this.mCapacitor;

        /// <summary>Current energy value.</summary>
        public float Energy => this.mEnergy;

        /// <summary>Ship's mass.</summary>
        public float Mass => this.Body.mass;

        /// <summary>Maximum armor value.</summary>
        public float MaxArmor => this.mMaxArmor;

        /// <summary>Maximum shield value.</summary>
        public float MaxShield => this.mMaxShield;

        /// <summary>Excessive power value.</summary>
        public float Power => this.mPower;

        /// <summary>Energy recharge value per second.</summary>
        public float RechargeRate => this.mRechargeRate;

        /// <summary>Current shield value.</summary>
        public float Shield => this.mShield;

        /// <inheritdoc />
        public float Acceleration => this.mAcceleration;

        /// <inheritdoc />
        public float MaxForward => this.mMaxForward;

        /// <inheritdoc />
        public float MaxPan => this.mMaxPan;

        /// <inheritdoc />
        public float MaxReverse => this.mMaxReverse;

        /// <inheritdoc />
        public float MaxTorque => this.mMaxTorque;

        /// <inheritdoc />
        public float Speed => this.mSpeed;

        /// <inheritdoc />
        public Vector3 Velocity => this.Body.velocity;
    }
}
