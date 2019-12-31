using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Managers;
using eidng8.SpaceFlight.Objects.Interactive.Automated;
using UnityEngine;
using UnityEngine.UI;


namespace Samples.eidng8.SpaceFlight.ForceController
{
    public class ShowInfo : MonoBehaviour
    {
        public Text info;

        private float _lastSelectTime;

        public MonoBehaviour obj;

        private bool _arb;
        private Rigidbody _rb;
        private bool _act;
        private IThrottledFlightController _ctl;

        private Rigidbody Body {
            get {
                if (_arb) {
                    return this._rb;
                }

                this._rb = this.obj.GetComponent<Rigidbody>();
                this._arb = true;

                return this._rb;
            }
        }

        private IThrottledFlightController Ctl {
            get {
                if (_act) {
                    return this._ctl;
                }

                this._ctl = this.obj.GetComponent<IThrottledFlightController>();
                this._act = true;

                return this._ctl;
            }
        }

        private void Start()
        {
            EventManager.Em.OnUserEvent(UserEvents.Select, OnSelectObject);
        }

        private void OnSelectObject(ExtendedEventArgs arg0)
        {
            this._lastSelectTime = Time.time;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!this.info.enabled) { return; }

            Vector3 vel = this.Body.velocity;
            this.info.text = $"Time: {Time.time - this._lastSelectTime}\n"
                             + $"Throttle: {this.Ctl.Throttle}\n"
                             + $"Speed Vector: {vel}\n"
                             + $"Speed Magnitude: {vel.magnitude}";
        }
    }
}
