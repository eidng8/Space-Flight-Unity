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

        protected Camera mCamera;

        protected bool mCameraReady;

        protected Ship mPlayerShip;

        protected bool mPlayerShipReady;

        public Text velocity;

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

            this.velocity.text = $"{this.mPlayerShip.Velocity} m/s\n"
                                 + $"{this.mPlayerShip.Velocity.Ms2Kmh()} km/h\n"
                                 + $"{this.mPlayerShip.Velocity.Ms2Knot()} knot\n"
                                 + $"{this.mPlayerShip.AngularVelocity} θ/s\n"
                                 + $"{this.mPlayerShip.AngularVelocity.Rad2Deg()} ⁰/s";
            // this.velocity.text = $"{this.mPlayerShip.transform.localEulerAngles}\n"
            //                      + $"{this.mCamera.transform.parent.localEulerAngles}";
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
        }
    }
}
