// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using eidng8.SpaceFlight.Events;
using UO = UnityEngine.Object;


namespace eidng8.SpaceFlight.Managers
{
    public sealed partial class EventManager
    {
        /// <summary>Holds all registered user event listeners.</summary>
        private Dictionary<UserEvents, Action<UserEventArgs>> _userEvents;

        /// <summary>
        /// Removes the specified listener from
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OffUserEvent(
            UserEvents eventName,
            Action<UserEventArgs> listener
        ) {
            if (this._userEvents.TryGetValue(eventName, out var evt)) {
                evt -= listener;
                this._userEvents[eventName] = evt;
            }
        }

        /// <summary>
        /// Listens on the specified event from
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OnUserEvent(
            UserEvents eventName,
            Action<UserEventArgs> listener
        ) {
            Action<UserEventArgs> evt;
            if (this._userEvents.TryGetValue(eventName, out evt)) {
                // Add more event to the existing one
                evt += listener;
                // Update the Dictionary
                this._userEvents[eventName] = evt;
            } else {
                // Add event to the Dictionary for the first time
                evt += listener;
                this._userEvents.Add(eventName, evt);
            }
        }

        /// <summary>
        /// Triggers the specified event on the
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public void TriggerUserEvent(
            UserEvents eventName,
            UserEventArgs args
        ) {
            if (this._userEvents.TryGetValue(eventName, out var evt)) {
                evt.Invoke(args);
            }
        }
    }
}
