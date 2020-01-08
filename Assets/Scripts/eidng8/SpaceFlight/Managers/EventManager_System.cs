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
        private static readonly
            Dictionary<SystemEvents, Action<SystemEventArgs>>
            SysEvents
                = new Dictionary<SystemEvents, Action<SystemEventArgs>>(16);

        /// <summary>
        ///     Removes the specified listener from
        ///     <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void OffSystemEvent(
            SystemEvents eventName,
            Action<SystemEventArgs> listener
        ) {
            Action<SystemEventArgs> evt;
            if (!EventManager.SysEvents.TryGetValue(eventName, out evt)) {
                return;
            }

            evt -= listener;
            EventManager.SysEvents[eventName] = evt;
        }

        /// <summary>
        ///     Listens on the specified event from
        ///     <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void OnSystemEvent(
            SystemEvents eventName,
            Action<SystemEventArgs> listener
        ) {
            Action<SystemEventArgs> evt;
            if (EventManager.SysEvents.TryGetValue(eventName, out evt)) {
                // Add more event to the existing one
                evt += listener;
                // Update the Dictionary
                EventManager.SysEvents[eventName] = evt;
            } else {
                // Add event to the Dictionary for the first time
                evt += listener;
                EventManager.SysEvents.Add(eventName, evt);
            }
        }

        /// <summary>
        ///     Triggers the specified event on the
        ///     <see cref="EventChannels.System" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public static void TriggerSystemEvent(
            SystemEvents eventName,
            SystemEventArgs args
        ) {
            Action<SystemEventArgs> evt;
            if (EventManager.SysEvents.TryGetValue(eventName, out evt)) {
                evt.Invoke(args);
            }
        }
    }
}
