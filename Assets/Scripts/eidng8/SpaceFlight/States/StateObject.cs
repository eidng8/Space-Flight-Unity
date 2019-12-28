// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------


namespace eidng8.SpaceFlight.States
{
    /// <summary>
    /// Base class of state data.
    ///
    /// In real time, only state data will be sent over network, between
    /// servers and clients.
    /// </summary>
    public abstract class StateObject
    {
        public abstract void SerializeForTransmission();
    }
}
