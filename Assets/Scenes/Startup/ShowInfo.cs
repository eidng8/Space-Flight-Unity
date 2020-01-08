using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Managers;
using eidng8.SpaceFlight.Objects.Interactive.Automated;
using UnityEngine;
using UnityEngine.UI;

namespace Startup
{
    public class ShowInfo : MonoBehaviour
    {
        private bool _act;

        private bool _arb;
        private IThrottledFlightController _ctl;

        private float _lastSelectTime;
        private Rigidbody _rb;
        public Text info;

        public MonoBehaviour obj;

        private Rigidbody Body
        {
            get
            {
                if (_arb) return _rb;

                _rb = obj.GetComponent<Rigidbody>();
                _arb = true;

                return _rb;
            }
        }

        private IThrottledFlightController Ctl
        {
            get
            {
                if (_act) return _ctl;

                _ctl = obj.GetComponent<IThrottledFlightController>();
                _act = true;

                return _ctl;
            }
        }

        private void OnSelectObject(UserEventArgs arg0)
        {
            _lastSelectTime = Time.time;
        }

        private void Start()
        {
            EventManager.OnUserEvent(UserEvents.Select, OnSelectObject);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!info.enabled) return;

            var vel = Body.velocity;
            info.text = $"Time: {Time.time - _lastSelectTime}\n"
                        + $"Throttle: {Ctl.Throttle}\n"
                        + $"Speed Vector: {vel}\n"
                        + $"Speed Magnitude: {vel.magnitude}";
        }
    }
}