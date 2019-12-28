// ---------------------------------------------------------------------------
// <copyright file="Force4x.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using eidng8.SpaceFlight.Objects.Dynamic.Motors;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot.Player
{
    /// <inheritdoc />
    /// <remarks>A crude 4 axis pilot control.</remarks>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Force4X : Pilot<Force4XConfig, ForceMotor4X>
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBePrivate.Global
        protected float _lastKeyboardTime;

        protected virtual void HandleKeyboard()
        {
            if (Time.unscaledTime - this._lastKeyboardTime
                < this.config.sensitivity) {
                return;
            }

            this._lastKeyboardTime = Time.unscaledTime;

            if (Input.GetKey(this.config.keys.accelerate)) {
                this.Accelerate();
            }

            if (Input.GetKey(this.config.keys.decelerate)) {
                this.Decelerate();
            }

            if (Input.GetKey(this.config.keys.pitchUp)) {
                this.PitchUp();
            }

            if (Input.GetKey(this.config.keys.pitchDown)) {
                this.PitchDown();
            }

            if (Input.GetKey(this.config.keys.yawC)) {
                this.YawC();
            }

            if (Input.GetKey(this.config.keys.yawCc)) {
                this.YawCc();
            }

            if (Input.GetKey(this.config.keys.rollC)) {
                this.RollC();
            }

            if (Input.GetKey(this.config.keys.rollCc)) {
                this.RollCc();
            }

            if (Input.GetKey(this.config.keys.panLeft)) {
                this.PanLeft();
            }

            if (Input.GetKey(this.config.keys.panRight)) {
                this.PanRight();
            }

            if (Input.GetKey(this.config.keys.panUp)) {
                this.PanUp();
            }

            if (Input.GetKey(this.config.keys.panDown)) {
                this.PanDown();
            }
        }

        protected virtual void PanLeft()
        {
            throw new NotImplementedException();
        }

        protected virtual void PanRight()
        {
            throw new NotImplementedException();
        }

        protected virtual void PanUp()
        {
            throw new NotImplementedException();
        }

        protected virtual void PanDown()
        {
            throw new NotImplementedException();
        }

        protected virtual void RollC()
        {
            throw new NotImplementedException();
        }

        protected virtual void RollCc()
        {
            throw new NotImplementedException();
        }

        protected virtual void YawC()
        {
            throw new NotImplementedException();
        }

        protected virtual void YawCc()
        {
            throw new NotImplementedException();
        }

        protected virtual void PitchDown()
        {
            throw new NotImplementedException();
        }

        protected virtual void PitchUp()
        {
            throw new NotImplementedException();
        }

        protected virtual void Decelerate()
        {
            float throttle = this.motor.Throttle;
            throttle -= this.config.incrementStep;

            // if it's just going from forward to backward, stop it once.
            if (throttle < 0 && throttle > -this.config.incrementStep) {
                this.motor.FullStop();
            }

            this.motor.Throttle = throttle;
        }

        protected virtual void Accelerate()
        {
            float throttle = this.motor.Throttle;
            throttle += this.config.incrementStep;

            // if it's just going from backward to forward, stop it once.
            if (throttle > 0 && throttle < this.config.incrementStep) {
                this.motor.FullStop();
            }

            this.motor.Throttle = throttle;
        }

        /// <inheritdoc />
        public override void FixedUpdate()
        {
            this.HandleKeyboard();
        }
    }
}
