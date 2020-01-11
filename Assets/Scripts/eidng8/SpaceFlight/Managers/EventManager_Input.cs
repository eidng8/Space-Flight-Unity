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
        ///     <see cref="Events.UserEvents.Horizontal" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnHorizontal(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Horizontal,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Vertical" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnVertical(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Vertical,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Pitch" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnPitch(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Pitch,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Roll" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnRoll(float delta) {
            // Rotation around Z axis is inverted.
            // Positive value makes it counter-clockwise.
            EventManager.TriggerUserEvent(
                Events.UserEvents.Roll,
                new UserEventArgs {delta = -delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Yaw" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnYaw(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Yaw,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Stabilize" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnStabilize() {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Stabilize,
                new UserEventArgs()
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.FullStop" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnFullStop() {
            EventManager.TriggerUserEvent(
                Events.UserEvents.FullStop,
                new UserEventArgs()
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.FullStop" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnAutoLevel() {
            EventManager.TriggerUserEvent(
                Events.UserEvents.AutoLevel,
                new UserEventArgs()
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Roll" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnLookHorizontal(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.LookHorizontal,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Yaw" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnLookVertical(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.LookVertical,
                new UserEventArgs {delta = delta}
            );
        }

        /// <summary>
        ///     Handles the raw input event from the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> and
        ///     converts it to the
        ///     <see cref="Events.UserEvents.Jump" /> event. This event
        ///     binding is
        ///     performed in the
        ///     <see cref="Luminosity.IO.Events.InputEventManager" /> inspector
        ///     UI at design time.
        /// </summary>
        public void RawInput_OnJump() {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Jump,
                new UserEventArgs()
            );
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
        public void RawInput_OnAccelerate(float delta) {
            EventManager.TriggerUserEvent(
                Events.UserEvents.Accelerate,
                new UserEventArgs {delta = delta}
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
