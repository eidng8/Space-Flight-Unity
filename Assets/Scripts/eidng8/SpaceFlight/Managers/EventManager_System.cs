// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using eidng8.SpaceFlight.Events;
using UO = UnityEngine.Object;


namespace eidng8.SpaceFlight.Managers
{
    public sealed partial class EventManager
    {
        /// <summary>
        /// Removes the specified listener from
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OffSystemEvent(
            Enum eventName,
            Action<SystemEventArgs> listener
        ) =>
            this.StopListening(
                EventChannels.System,
                eventName,
                (Action<ExtendedEventArgs>)listener
            );

        /// <summary>
        /// Listens on the specified event from
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OnSystemEvent(
            Enum eventName,
            Action<SystemEventArgs> listener
        ) =>
            this.ListenOn(
                EventChannels.System,
                eventName,
                (Action<ExtendedEventArgs>)listener
            );

        /// <summary>
        /// Triggers the specified event on the
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public void
            TriggerSystemEvent(Enum eventName, SystemEventArgs args) =>
            this.TriggerEvent(EventChannels.System, eventName, args);
    }
}
