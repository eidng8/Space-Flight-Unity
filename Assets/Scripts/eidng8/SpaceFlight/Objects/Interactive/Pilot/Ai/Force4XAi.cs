// ---------------------------------------------------------------------------
// <copyright file="Force4XAi.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using eidng8.SpaceFlight.Objects.Dynamic.Motors;
using eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot.Ai
{
    /// <inheritdoc />
    /// <remarkes>
    /// This component works with
    /// <see cref="Force4XController{TPilot,TPilotConfig}" />.
    /// </remarkes>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Force4XAi
        : PilotAi<Force4XAiConfig, ForceMotor4X, Force4XController<Force4XAi,
            Force4XAiConfig>>
    {
        /// <inheritdoc />
        protected override void DetermineThrottle()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void TurnToTarget()
        {
            throw new NotImplementedException();
        }
    }
}
