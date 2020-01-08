using UnityEngine;

namespace eidng8.SpaceFlight.Mechanics.Nav
{
    [RequireComponent(typeof(Rigidbody))]
    public class Follower : MonoBehaviour, IFollower
    {
        private Rigidbody _target;

        [Tooltip("Keep this distance away from target.")]
        public float keepDistance = 20;

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
            Vector3 pos = this.Target.position;
            this.Rig.transform.LookAt(pos);
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
