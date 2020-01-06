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
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OffUserEvent(
            Enum eventName,
            Action<UserEventArgs> listener
        ) =>
            this.StopListening(
                EventChannels.User,
                eventName,
                (Action<ExtendedEventArgs>)listener
            );

        /// <summary>
        /// Listens on the specified event from
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OnUserEvent(
            Enum eventName,
            Action<UserEventArgs> listener
        ) =>
            this.ListenOn(
                EventChannels.User,
                eventName,
                (Action<ExtendedEventArgs>)listener
            );

        /// <summary>
        /// Triggers the specified event on the
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public void TriggerUserEvent(Enum eventName, UserEventArgs args) =>
            this.TriggerEvent(EventChannels.User, eventName, args);
    }
}
