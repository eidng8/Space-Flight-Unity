// ---------------------------------------------------------------------------
// <copyright file="IThrottledFlightController.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Objects.Interactive.Automated
{
    /// <summary>A flight controller that facilitates motor throttling.</summary>
    public interface IThrottledFlightController : IFlightController
    {
        /// <summary>Current throttle value.</summary>
        float Throttle { get; set; }
    }
}
