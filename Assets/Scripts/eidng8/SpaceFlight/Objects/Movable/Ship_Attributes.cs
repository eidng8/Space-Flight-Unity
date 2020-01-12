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

        protected Vector3 mAngularAcceleration;

        protected float mArmor;

        protected bool mAutoLeveling;

        protected float mCapacitor;

        protected float mEnergy;

        protected Vector3 mLastVelocity;

        protected Vector3 mLastAngularVelocity;

        protected float mMaxArmor;

        protected float mMaxForward;

        protected float mMaxPan;

        protected float mMaxReverse;

        protected float mMaxShield;

        protected float mMaxTorque;

        protected float mPower;

        protected readonly Vector3[] mPropellant = new Vector3[2];

        protected float mRechargeRate;

        protected float mShield;

        protected float mSpeed;

        protected bool mStabilizing;

        protected bool mStopping;

        protected Vector3 mVelocity;

        protected Vector4 mMaxAcceleration;

        protected Vector3 mMaxAngularAcceleration;

        protected Vector3 mAppliedForces;

        protected Vector3 mAppliedTorque;
        

        /// <summary>Current armor value.</summary>
        public float Armor => this.mArmor;

        public Vector3 AppliedForces => this.mAppliedForces;

        public Vector3 AppliedTorque => this.mAppliedTorque;
        
        /// <summary>Maximum energy value.</summary>
        public float Capacitor => this.mCapacitor;

        /// <summary>Current energy value.</summary>
        public float Energy => this.mEnergy;

        /// <summary>Ship's mass.</summary>
        public float Mass => this.Body.mass;

        /// <summary>Max acceleration in 4 directions.</summary>
        /// <remarks>
        /// The extra <c>w</c> component represents the reverse thruster.
        /// </remarks>
        public Vector4 MaxAcceleration => this.mMaxAcceleration;

        public Vector3 MaxAngularAcceleration => this.mMaxAngularAcceleration;

        public Vector3 AngularAcceleration => this.mAngularAcceleration;

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
        
        public bool AutoLeveling=> this.mAutoLeveling;

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
