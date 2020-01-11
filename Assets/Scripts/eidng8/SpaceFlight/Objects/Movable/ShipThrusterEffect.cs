using System;
using System.Collections.Generic;
using UnityEngine;

namespace eidng8.SpaceFlight.Objects.Movable
{
    [RequireComponent(typeof(Ship))]
    public class ShipThrusterEffect : MonoBehaviour
    {
        [Tooltip("Maximum start speed of particle system.")]
        public float maxSpeed = 5;

        public List<ParticleSystem> forward;

        public List<ParticleSystem> backward;

        public List<ParticleSystem> panLeft;

        public List<ParticleSystem> panRight;

        public List<ParticleSystem> panUp;

        public List<ParticleSystem> panDown;

        public List<ParticleSystem> pitchUp;

        public List<ParticleSystem> pitchDown;

        public List<ParticleSystem> rollClockwise;

        public List<ParticleSystem> rollCounterClockwise;

        public List<ParticleSystem> yawStarboard;

        public List<ParticleSystem> yawPort;

        protected Ship mShip;

        protected virtual void OnEnable() {
            this.mShip = this.GetComponent<Ship>();
        }

        protected virtual void Update() {
            this.ResetEffects();
            this.AdjustForwardEffect();
            this.AdjustBackwardEffect();
            this.AdjustPanLeftEffect();
            this.AdjustPanRightEffect();
            this.AdjustPanUpEffect();
            this.AdjustPanDownEffect();
            this.AdjustRollClockwiseEffect();
            this.AdjustRollCounterClockwiseEffect();
            this.AdjustPanUpEffect();
            this.AdjustPitchUpEffect();
            this.AdjustPitchDownEffect();
            this.AdjustYawStarboardEffect();
            this.AdjustYawPortEffect();
        }

        protected virtual void AdjustForwardEffect() {
            if (this.mShip.Acceleration.z <= 0) { return; }

            if (this.forward != null && this.forward.Count > 0) {
                this.forward.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.Acceleration.z,
                        this.mShip.MaxAcceleration.z,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustBackwardEffect() {
            if (this.mShip.Acceleration.z >= 0) { return; }

            if (this.backward != null && this.backward.Count > 0) {
                this.backward.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.Acceleration.z,
                        this.mShip.MaxAcceleration.w,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPanLeftEffect() {
            if (this.mShip.Acceleration.x >= 0) { return; }

            if (this.panLeft != null && this.panLeft.Count > 0) {
                this.panLeft.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.Acceleration.x,
                        this.mShip.MaxAcceleration.x,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPanRightEffect() {
            if (this.mShip.Acceleration.x <= 0) { return; }

            if (this.panRight != null && this.panRight.Count > 0) {
                this.panRight.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.Acceleration.x,
                        this.mShip.MaxAcceleration.x,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPanUpEffect() {
            if (this.mShip.Acceleration.y <= 0) { return; }

            if (this.panUp != null && this.panUp.Count > 0) {
                this.panUp.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.Acceleration.y,
                        this.mShip.MaxAcceleration.y,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPanDownEffect() {
            if (this.mShip.Acceleration.y >= 0) { return; }

            if (this.panDown != null && this.panDown.Count > 0) {
                this.panDown.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.Acceleration.y,
                        this.mShip.MaxAcceleration.y,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustRollClockwiseEffect() {
            if (this.mShip.AngularAcceleration.z >= 0) { return; }

            if (this.rollClockwise != null && this.rollClockwise.Count > 0) {
                this.rollClockwise.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.AngularAcceleration.z,
                        this.mShip.MaxAngularAcceleration.z,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustRollCounterClockwiseEffect() {
            if (this.mShip.AngularAcceleration.z <= 0) { return; }

            if (this.rollCounterClockwise != null
                && this.rollCounterClockwise.Count > 0) {
                this.rollCounterClockwise.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.AngularAcceleration.z,
                        this.mShip.MaxAngularAcceleration.z,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPitchUpEffect() {
            if (this.mShip.AngularAcceleration.x >= 0) { return; }

            if (this.pitchUp != null && this.pitchUp.Count > 0) {
                this.pitchUp.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.AngularAcceleration.x,
                        this.mShip.MaxAngularAcceleration.x,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustPitchDownEffect() {
            if (this.mShip.AngularAcceleration.x <= 0) { return; }

            if (this.pitchDown != null && this.pitchDown.Count > 0) {
                this.pitchDown.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.AngularAcceleration.x,
                        this.mShip.MaxAngularAcceleration.x,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustYawStarboardEffect() {
            if (this.mShip.AngularAcceleration.y <= 0) { return; }

            if (this.yawStarboard != null && this.yawStarboard.Count > 0) {
                this.yawStarboard.ForEach(
                    ps => this.AdjustEffect(
                        this.mShip.AngularAcceleration.y,
                        this.mShip.MaxAngularAcceleration.y,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustYawPortEffect() {
            if (this.mShip.AngularAcceleration.y >= 0) { return; }

            if (this.yawPort != null && this.yawPort.Count > 0) {
                this.yawPort.ForEach(
                    ps => this.AdjustEffect(
                        -this.mShip.AngularAcceleration.y,
                        this.mShip.MaxAngularAcceleration.y,
                        ps
                    )
                );
            }
        }

        protected virtual void AdjustEffect(
            float v,
            float max,
            ParticleSystem ps
        ) {
            float t = v / max;
            float f = Mathf.Lerp(0, 5, t);
            ParticleSystem.MainModule main = ps.main;
            main.startSpeed = f;
        }

        protected virtual void ResetEffects() {
            this.forward?.ForEach(this.ResetEffect);
            this.backward?.ForEach(this.ResetEffect);
            this.panLeft?.ForEach(this.ResetEffect);
            this.panRight?.ForEach(this.ResetEffect);
            this.panUp?.ForEach(this.ResetEffect);
            this.panDown?.ForEach(this.ResetEffect);
            this.pitchUp?.ForEach(this.ResetEffect);
            this.pitchDown?.ForEach(this.ResetEffect);
            this.yawStarboard?.ForEach(this.ResetEffect);
            this.yawPort?.ForEach(this.ResetEffect);
            this.rollClockwise?.ForEach(this.ResetEffect);
            this.rollCounterClockwise?.ForEach(this.ResetEffect);
        }

        protected virtual void ResetEffect(ParticleSystem ps) {
            ParticleSystem.MainModule main = ps.main;
            main.startSpeed = 0;
        }
    }
}
