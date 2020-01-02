// ---------------------------------------------------------------------------
// <copyright file="Force4XPlayerController.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable;
using eidng8.SpaceFlight.Objects.Interactive.Pilot.Player;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers
{
    /// <inheritdoc />
    /// <remarks>A crude 4 axis flight control without AI.</remarks>
    public class Force4XPlayerController
        : Force4XController<Force4X, Force4XConfig> {
        /// <inheritdoc />
        public override void Configure(IConfigurable config) { throw new System.NotImplementedException(); }
    }
}
