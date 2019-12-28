// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects
{
    /// <summary>
    /// Base class of all space objects. It makes sure all such objects
    /// have their parameters properly set. Such as gravity, drag,
    /// kinematic.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class SpaceObject : MonoBehaviour
    {
        private Rigidbody _body;

        private bool _set;

        /// <summary>
        /// Reference to the attached <c>Rigidbody</c>. This rigid body's
        /// gravity and drags are all zero. And <c>isKinematic</c> is
        /// <c>false</c>.
        /// </summary>
        protected Rigidbody Body {
            get {
                if (this._set) {
                    return this._body;
                }

                this._body = this.GetComponent<Rigidbody>();
                this._body.useGravity = false;
                this._body.drag = 0;
                this._body.angularDrag = 0;
                this._body.isKinematic = false;
                this._set = true;
                return this._body;
            }
        }
    }
}
