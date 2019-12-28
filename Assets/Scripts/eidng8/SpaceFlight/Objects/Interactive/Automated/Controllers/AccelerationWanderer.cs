// ---------------------------------------------------------------------------
// <copyright file="AccelerationWanderer.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Dynamic.Motors;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers
{
    public class AccelerationWanderer : AccelerationAutoPilot
    {
        private float _lastChoiceTime;

        private GameObject _waypoint;

        private bool _shouldDestroyWaypoint;

        /// <inheritdoc />
        protected override void Awake()
        {
            this.pilotConfig.playerShip = false;
            base.Awake();
        }

        /// <inheritdoc />
        protected override void FixedUpdate()
        {
            this.Wander();
            base.FixedUpdate();
        }

        private void Wander()
        {
            // don't change decision within 5s
            float t = Time.fixedTime - this._lastChoiceTime - Random.value * 10;
            if (t < 5) {
                return;
            }

            this.RandomThrottle();
            this.RandomWaypoint();

            this._lastChoiceTime = Time.fixedTime;
        }

        /// <summary>Randomly pick a point far away from current position.</summary>
        private void RandomWaypoint()
        {
            // This point should need 10s for it to get to with max speed.
            AccelerationMotorConfig mc = this.motorConfig;
            float range = Random.Range(mc.maxSpeed, mc.maxSpeed * 10);

            // Randomly choose a direction of the waypoint
            Vector3 dir = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            );

            // Pilot requires their targets to be Transform type.
            // So we have to create a dummy object.
            var dummy = GameObject.CreatePrimitive(PrimitiveType.Cube);

            // Just to be sure the object won't be visible.
            dummy.transform.localScale = Vector3.zero;

            // Set the position using previously chosen direction and range.
            dummy.transform.position = dir * range;

            // Save current waypoint before setting a new one.
            GameObject wp = this._waypoint;
            this.pilot.Target = dummy.transform;
            this._waypoint = dummy;

            // Destroy previous waypoint if there's one.
            if (this._shouldDestroyWaypoint) {
                Object.DestroyImmediate(wp);
            }

            this._shouldDestroyWaypoint = true;
        }

        private void RandomThrottle()
        {
            this.Throttle = Random.value;
        }
    }
}
