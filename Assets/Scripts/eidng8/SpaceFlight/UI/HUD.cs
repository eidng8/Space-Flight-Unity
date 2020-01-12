using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Laws;
using eidng8.SpaceFlight.Managers;
using eidng8.SpaceFlight.Mechanics.Nav;
using eidng8.SpaceFlight.Objects.Movable;
using UnityEngine;
using UnityEngine.UI;

namespace eidng8.SpaceFlight.UI
{
    // ReSharper disable once InconsistentNaming
    [RequireComponent(typeof(Canvas))]
    public class HUD : MonoBehaviour
    {
        public Text indicatorStabilizing;
        public Text indicatorStopping;
        public Text indicatorLeveling;
        public Text velocity;
        public Text details;
        public Text dynamics;

        protected Camera mCamera;

        protected bool mCameraReady;

        protected Ship mPlayerShip;

        protected bool mPlayerShipReady;


        protected virtual void OnEnable() {
            this.mCameraReady = false;
            this.mPlayerShipReady = false;
            EventManager.OnSystemEvent(
                SystemEvents.PlayerShipCreated,
                this.GetPlayerShip
            );
            EventManager.OnSystemEvent(
                SystemEvents.MainCameraCreated,
                this.GetMainCamera
            );
        }

        protected virtual void GetMainCamera(SystemEventArgs args) {
            this.mCamera = (Camera)args.source;
            this.mCameraReady = true;
            Canvas canvas = this.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = this.mCamera;
            this.CameraFollow();
        }

        protected virtual void GetPlayerShip(SystemEventArgs args) {
            this.mPlayerShip = (Ship)args.source;
            this.mPlayerShipReady = true;
            this.CameraFollow();
        }

        protected virtual void CameraFollow() {
            if (!this.mCameraReady || !this.mPlayerShipReady) { return; }

            this.mCamera.transform.parent.GetComponent<Follower>()
                .Follow(this.mPlayerShip.GetComponent<Rigidbody>());
            Debug.Log("Main camera has been attached to player ship.");
        }

        protected virtual void Update() {
            if (!this.mCameraReady || !this.mPlayerShipReady) { return; }

            this.UpdateVelocity();
            this.UpdateIndicators();
            this.UpdateDetails();
            this.UpdateDynamics();
        }

        protected virtual void UpdateVelocity() {
            this.velocity.text =
                $"{this.mPlayerShip.Velocity} m/s\n"
                + $"{this.mPlayerShip.Velocity.Ms2Kmh()} km/h\n"
                + $"{this.mPlayerShip.Velocity.Ms2Knot()} knot\n"
                + $"{this.mPlayerShip.AngularVelocity} θ/s\n"
                + $"{this.mPlayerShip.AngularVelocity.Rad2Deg()} ⁰/s";
        }

        protected virtual void UpdateIndicators() {
            Color c = this.indicatorStabilizing.color;
            c.a = this.mPlayerShip.Stabilizing
                ? Mathf.PingPong(Time.time * 2, 1)
                : 0;
            this.indicatorStabilizing.color = c;

            c = this.indicatorStopping.color;
            c.a = this.mPlayerShip.Stopping
                ? Mathf.PingPong(Time.time * 2, 1)
                : 0;
            this.indicatorStopping.color = c;

            c = this.indicatorLeveling.color;
            c.a = this.mPlayerShip.AutoLeveling
                ? Mathf.PingPong(Time.time * 2, 1)
                : 0;
            this.indicatorLeveling.color = c;
        }

        protected virtual void UpdateDetails() {
            Vector4 forces = new Vector4(
                this.mPlayerShip.MaxPan,
                this.mPlayerShip.MaxPan,
                this.mPlayerShip.MaxForward,
                this.mPlayerShip.MaxReverse
            );
            Vector3 torque = new Vector3(
                this.mPlayerShip.MaxTorque,
                this.mPlayerShip.MaxTorque,
                this.mPlayerShip.MaxTorque
            );
            this.details.text =
                $"Mass: {this.mPlayerShip.Mass}\n"
                + $"Max Forces: {forces}\n"
                + $"Max Accel.: {this.mPlayerShip.MaxAcceleration}\n"
                + $"Max Torque: {torque}\n"
                + $"Max Angular Accel.: {this.mPlayerShip.MaxAngularAcceleration}";
        }

        protected virtual void UpdateDynamics() {
            this.dynamics.text =
                $"Euler: {this.mPlayerShip.transform.localEulerAngles}\n"
                + $"Forces: {this.mPlayerShip.AppliedForces}\n"
                + $"Accel.: {this.mPlayerShip.Acceleration}\n"
                + $"Torque: {this.mPlayerShip.AppliedTorque}\n"
                + $"Angular Accel.: {this.mPlayerShip.AngularAcceleration}";
        }
    }
}
