using UnityEngine;

namespace eidng8.SpaceFlight.Mechanics.Nav
{
    [RequireComponent(typeof(Rigidbody))]
    public class Follower : MonoBehaviour, IFollower
    {
        [Tooltip("Keep this distance away from target.")]
        public float keepDistance = 20;

        public bool alignY;

        private Rigidbody _target;

        protected Rigidbody Rig { get; private set; }

        public bool HasTarget { get; private set; }

        public Rigidbody Target {
            get => this._target;
            set {
                this._target = value;
                this.HasTarget = true;
            }
        }

        public void ClearTarget() {
            this._target = null;
            this.HasTarget = false;
        }

        public void Follow(Rigidbody target) {
            this.Target = target;
        }

        private void FixedUpdate() {
            if (!this.HasTarget) {
                return;
            }

            Transform me = this.transform;
            Transform target = this.Target.transform;
            Vector3 pos = target.position;
            if (this.alignY) {
                this.Rig.transform.LookAt(pos);
                var ang = me.localEulerAngles;
                ang.z = target.localEulerAngles.z;
                me.localEulerAngles = ang;
            }

            if (Vector3.Distance(pos, me.position) > this.keepDistance) {
                float v = Mathf.Lerp(
                    this.Rig.velocity.magnitude,
                    this.Target.velocity.magnitude,
                    Time.fixedDeltaTime
                );
                this.Rig.velocity = me.forward * v;
            } else {
                this.Rig.velocity = Vector3.zero;
            }
        }

        private void OnEnable() {
            this.Rig = this.GetComponent<Rigidbody>();
        }
    }
}
