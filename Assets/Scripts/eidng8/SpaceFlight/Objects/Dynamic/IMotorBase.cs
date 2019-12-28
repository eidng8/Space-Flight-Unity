// ---------------------------------------------------------------------------
// <copyright file="IMotorBase.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Objects.Dynamic
{
    public interface IMotorBase
    {
        /// <summary>Current acceleration value.</summary>
        float Acceleration { get; }

        /// <summary>
        /// Configures the motor. Different types of motors have different
        /// configuration attributes. Please consult documentation of the motor
        /// you are using.
        /// </summary>
        /// <param name="config">
        /// A <c>Dictionary</c> of configuration
        /// attributes.
        /// </param>
        void Configure(IMotorConfig config);

        /// <summary>Convenient method to apply maximum reverse thrust.</summary>
        void FullReverse();

        /// <summary>Convenient method to apply zero thrust.</summary>
        void FullStop();

        /// <summary>Convenient method to apply maximum forward thrust.</summary>
        void FullForward();

        /// <summary>Current forward thrust value.</summary>
        float GenerateThrust();
    }
}
