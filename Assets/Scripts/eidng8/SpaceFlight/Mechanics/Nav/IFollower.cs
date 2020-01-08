using UnityEngine;

namespace eidng8.SpaceFlight.Mechanics.Nav
{
    public interface IFollower
    {
        bool HasTarget { get; }

        Rigidbody Target { get; set; }

        void ClearTarget();

        void Follow(Rigidbody target);
    }
}
