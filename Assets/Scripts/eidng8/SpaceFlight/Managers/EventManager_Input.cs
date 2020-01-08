// ---------------------------------------------------------------------------
// <copyright file="EventManager_Input.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Objects;
using UnityEngine;


// ReSharper disable file MemberCanBePrivate.Global
// ReSharper disable file UnusedMemberHierarchy.Global
namespace eidng8.SpaceFlight.Managers
{
    public sealed partial class EventManager
    {
        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Select" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnAccelerate(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Accelerate,
                new UserEventArgs {acceleration = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Context" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnContext() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target =
                    hit.collider.gameObject.GetComponent<SpaceObject>();
            }

            EventManager.TriggerUserEvent(Events.UserEvents.Context, args);
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Extension" /> event. This event
        ///     binding
        ///     is performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnExtension() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target =
                    hit.collider.gameObject.GetComponent<SpaceObject>();
            }

            EventManager.TriggerUserEvent(Events.UserEvents.Extension, args);
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Select" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnSelect() {
            UserEventArgs args = new UserEventArgs();
            if (this.CameraRaycast(out RaycastHit hit)) {
                args.hasTarget = true;
                args.target =
                    hit.collider.gameObject.GetComponent<SpaceObject>();
            }

            EventManager.TriggerUserEvent(Events.UserEvents.Select, args);
        }
    }
}
