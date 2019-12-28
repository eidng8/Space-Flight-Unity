// ---------------------------------------------------------------------------
// <copyright file="ManagedEvent.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine.Events;

namespace eidng8.SpaceFlight.Events
{
    [Serializable]
    public class ManagedEvent : UnityEvent<ExtendedEventArgs>
    {
    }
}
