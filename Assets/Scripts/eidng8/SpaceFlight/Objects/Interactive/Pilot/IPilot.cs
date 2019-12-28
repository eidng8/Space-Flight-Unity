// ---------------------------------------------------------------------------
// <copyright file="IPilot.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Dynamic;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot
{
    public interface IPilot
    {
        /// <summary>Whether a target has been chosen.</summary>
        /// <remarks>
        /// Directly check the <see cref="Target" /> against <c>null</c> is an
        /// expensive operation. So we have to use this field to track the
        /// status of target selection.
        /// </remarks>
        bool HasTarget { get; }

        /// <summary>Reference to the selected target object.</summary>
        Transform Target { get; set; }

        /// <summary>For use with Unity's <c>Awake</c> event.</summary>
        void Awake();

        /// <summary>
        /// Configures the pilot. Different types of pilots have different
        /// configuration attributes. Please consult documentation of the pilot
        /// you are using.
        /// </summary>
        /// <param name="config">
        /// A <see cref="IPilotConfig" /> of configuration
        /// attributes.
        /// </param>
        void Configure(IPilotConfig config);

        /// <summary>For use with Unity's <c>FixedUpdate</c> event.</summary>
        void FixedUpdate();

        /// <summary>
        /// Stores the motor reference for later use. Implementations of this
        /// interface directly interact with this motor instance.
        /// </summary>
        /// <param name="motor"></param>
        void TakeControlOfMotor(IMotorBase motor);
    }
}
