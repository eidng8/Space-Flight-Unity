// ---------------------------------------------------------------------------
// <copyright file="AccelerationAutoPilot.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Interactive.Pilot.Ai;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers
{
    public class AccelerationAutoPilot
        : AccelerationController<AccelerationAi, AccelerationAiConfig>,
            IAutoPilot
    {
        protected override void Awake()
        {
            base.Awake();
            this.pilot.Control = this;
        }

        /// <inheritdoc />
        public void SetTarget(Transform target)
        {
            this.pilot.Target = target;
        }
    }
}
