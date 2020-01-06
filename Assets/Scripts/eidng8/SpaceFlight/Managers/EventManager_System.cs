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
        /// <summary>Holds all registered system event listeners.</summary>
        private Dictionary<SystemEvents, Action<SystemEventArgs>> _sysEvents;

        /// <summary>
        /// Removes the specified listener from
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventsName"></param>
        /// <param name="listener"></param>
        public void OffSystemEvent(
            SystemEvents eventName,
            Action<SystemEventArgs> listener
        ) {
            if (this._sysEvents.TryGetValue(eventName, out var evt)) {
                evt -= listener;
                this._sysEvents[eventName] = evt;
            }
        }

        /// <summary>
        /// Listens on the specified event from
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventsName"></param>
        /// <param name="listener"></param>
        public void OnSystemEvent(
            SystemEvents eventName,
            Action<SystemEventArgs> listener
        ) {
            Action<SystemEventArgs> evt;
            if (this._sysEvents.TryGetValue(eventName, out evt)) {
                // Add more event to the existing one
                evt += listener;
                // Update the Dictionary
                this._sysEvents[eventName] = evt;
            } else {
                // Add event to the Dictionary for the first time
                evt += listener;
                this._sysEvents.Add(eventName, evt);
            }
        }

        /// <summary>
        /// Triggers the specified event on the
        /// <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventsName"></param>
        /// <param name="args"></param>
        public void TriggerSystemEvent(
            SystemEvents eventName,
            SystemEventArgs args
        ) {
            if (this._sysEvents.TryGetValue(eventName, out var evt)) {
                evt.Invoke(args);
            }
        }
    }
}
