// ---------------------------------------------------------------------------
// <copyright file="EventManager_Input.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using UnityEngine;


// ReSharper disable file MemberCanBePrivate.Global
// ReSharper disable file UnusedMemberHierarchy.Global
namespace eidng8.SpaceFlight.Managers
{
    public sealed partial class EventManager
    {
        /// <summary>
        /// Handles the raw input event from the
        /// <see cref="InputEventManager" /> and converts it to the
        /// <see cref="UserEvents.Select" /> event. This event binding is
        /// performed in the <see cref="InputEventManager" /> inspector UI at
        /// design time.
        /// </summary>
        public void RawInput_OnUserAccelerate(float delta) {
            this.TriggerUserEvent(
                UserEvents.Accelerate,
                new UserEventArgs {acceleration = delta}
            );
        }

        /// <summary>
        /// Handles the raw input event from the
        /// <see cref="InputEventManager" /> and converts it to the
        /// <see cref="UserEvents.Context" /> event. This event binding is
        /// performed in the <see cref="InputEventManager" /> inspector UI at
        /// design time.
        /// </summary>
        public void RawInput_OnUserContext() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target = hit.transform;
            }

            this.TriggerUserEvent(UserEvents.Context, args);
        }

        /// <summary>
        /// Handles the raw input event from the
        /// <see cref="InputEventManager" /> and converts it to the
        /// <see cref="UserEvents.Extension" /> event. This event binding is
        /// performed in the <see cref="InputEventManager" /> inspector UI at
        /// design time.
        /// </summary>
        public void RawInput_OnUserExtension() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target = hit.transform;
            }

            this.TriggerUserEvent(UserEvents.Extension, args);
        }

        /// <summary>
        /// Handles the raw input event from the
        /// <see cref="InputEventManager" /> and converts it to the
        /// <see cref="UserEvents.Select" /> event. This event binding is
        /// performed in the <see cref="InputEventManager" /> inspector UI at
        /// design time.
        /// </summary>
        public void RawInput_OnUserSelect() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target = hit.transform;
            }

            this.TriggerUserEvent(UserEvents.Select, args);
        }
    }
}
