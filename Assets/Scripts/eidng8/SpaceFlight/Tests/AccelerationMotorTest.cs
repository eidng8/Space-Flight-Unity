// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections;
using eidng8.SpaceFlight.Objects.Dynamic.Motors;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace eidng8.SpaceFlight.Tests
{
    public class AccelerationMotorTest
    {
        private readonly float _maxTurn = 1;
        private readonly Quaternion _roll = Quaternion.identity;
        private AccelerationMotor _motor;

        [SetUp]
        public void Setup()
        {
            AccelerationMotorConfig config = new AccelerationMotorConfig {
                maxSpeed = 100f,
                maxTurn = this._maxTurn,
                maxAcceleration = 10f,
                maxDeceleration = 10f,
                rotation = this._roll
            };
            this._motor = new AccelerationMotor();
            this._motor.Configure(config);
        }

        [Test]
        public void TestFullReverseShouldDecreaseThrust()
        {
            this._motor.FullReverse();
            Assert.AreEqual(-10, this._motor.GenerateThrust());
        }

        [Test]
        public void TestFullStopShouldNotChangeThrust()
        {
            this._motor.FullStop();
            Assert.AreEqual(0, this._motor.GenerateThrust());
        }

        [Test]
        public void TestFullThrottleShouldIncreaseThrust()
        {
            this._motor.FullForward();
            Assert.AreEqual(10, this._motor.GenerateThrust());
        }

        [Test]
        public void TestThrottleShouldAffectThrust()
        {
            this._motor.Throttle = .8f;
            Assert.AreEqual(8, this._motor.GenerateThrust());
        }

        [Test]
        public void TestThrustIsAcceleration()
        {
            this._motor.Throttle = .8f;
            Assert.AreEqual(16, this._motor.GetVelocity(2));
        }

        [UnityTest]
        public IEnumerator TestTurnIsClamped()
        {
            this._motor.TurnTo(Vector3.back);
            float turn = Quaternion.Angle(
                this._motor.GetRoll(.1f),
                this._roll
            );

            Assert.Less(turn, 90);

            yield return null;
        }

        [Test]
        public void TestTurnIsNotThrottled()
        {
            this._motor.Throttle = .8f;
            Assert.AreEqual(
                this._maxTurn,
                this._motor.GenerateTorque(1)
            );
        }

        [Test]
        public void TestTurnIsTimed()
        {
            const float time = 2;
            Assert.AreEqual(
                this._maxTurn * time,
                this._motor.GenerateTorque(time)
            );
        }
    }
}
