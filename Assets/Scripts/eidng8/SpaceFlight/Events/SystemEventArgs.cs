// ---------------------------------------------------------------------------
// <copyright file="SystemEventArgs.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;

namespace eidng8.SpaceFlight.Events
{
    [Serializable]
    public class SystemEventArgs : ExtendedEventArgs
    {
        public object source;
    }
}
