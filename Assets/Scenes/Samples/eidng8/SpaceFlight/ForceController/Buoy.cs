// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Objects.Interactive;


namespace Samples.eidng8.SpaceFlight.ForceController
{
    public class Buoy : StationaryObject
    {
        public void OnClick()
        {
            EventManager.Mgr.TriggerEvent(
                EventChannels.User,
                UserEvents.Select,
                new ExtendedEventArgs()
                {
                    source = this.gameObject
                });
        }
    }
}
