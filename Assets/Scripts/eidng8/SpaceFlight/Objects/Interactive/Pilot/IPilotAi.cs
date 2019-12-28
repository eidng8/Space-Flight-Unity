// ---------------------------------------------------------------------------
// <copyright file="IPilotAi.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Interactive.Automated;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot
{
    /// <summary>
    /// Logic that makes objects move. Sub-class of this interface are
    /// supposed to work with concrete implementation of
    /// <see cref="IFlightController" />. To concrete sub-classes of this
    /// interface, you'll likely want to add the attribute
    /// <c>[RequireComponent(typeof(...))]</c> to a concrete class that
    /// implements the <see cref="IFlightController" />.
    /// </summary>
    public interface IPilotAi : IPilot { }
}
