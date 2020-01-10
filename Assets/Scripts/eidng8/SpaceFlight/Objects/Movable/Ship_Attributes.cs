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
        protected Vector3 mAcceleration;

        protected Vector3 mAngularVelocity;

        protected float mArmor;

        protected float mCapacitor;

        protected float mEnergy;

        protected Vector3 mLastVelocity;

        protected float mMaxArmor;

        protected float mMaxForward;

        protected float mMaxPan;

        protected float mMaxReverse;

        protected float mMaxShield;

        protected float mMaxTorque;

        protected float mPower;

        protected Vector3[] mPropellant = new Vector3[2];

        protected float mRechargeRate;

        protected float mShield;

        protected float mSpeed;

        protected bool mStabilizing;

        protected bool mStopping;

        protected Vector3 mVelocity;

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

        public bool Stabilizing => this.mStabilizing;

        public bool Stopping => this.mStopping;

        public Vector3 AngularVelocity => this.mAngularVelocity;

        /// <inheritdoc />
        public Vector3 Acceleration => this.mAcceleration;

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
        public Vector3 Velocity => this.mVelocity;
    }
}
