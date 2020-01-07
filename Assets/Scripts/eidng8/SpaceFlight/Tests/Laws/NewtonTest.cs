// ---------------------------------------------------------------------------
// <copyright file="NewtonTest.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Laws;
using NUnit.Framework;
using UnityEngine;


namespace eidng8.SpaceFlight.Tests.Laws
{
    public class NewtonTest
    {
        [Test]
        public void TestEstimatedArrivalDecelerateCanNotMakeIt() {
            const float v = 10, a = -10, d = 20;
            Assert.AreEqual(
                float.PositiveInfinity,
                Newton.EstimatedArrival(v, a, d)
            );
        }

        [Test]
        public void TestEstimatedArrivalWithDeceleration() {
            const float v = 40, a = -5, d = 60;
            Assert.AreEqual(
                2,
                Newton.EstimatedArrival(v, a, d)
            );
        }

        [Test]
        public void TestEstimatedArrivalWithInitialSpeed() {
            const float v = 10, a = 10, d = 60;
            Assert.AreEqual(2, Newton.EstimatedArrival(v, a, d));
        }

        [Test]
        public void TestEstimatedArrivalWithoutInitialSpeed() {
            const float v = 0, a = 10, d = 40;
            Assert.AreEqual(2, Newton.EstimatedArrival(v, a, d));
        }

        [Test]
        public void TestShouldBrakeDealsWithBuffer() {
            Vector3 pa = Vector3.zero;
            Vector3 pb = Vector3.up * 65;
            Vector3 va = Vector3.up * 25;
            Vector3 vb = Vector3.zero;
            const float a = -5;
            Assert.True(Newton.ShouldBrake(pa, pb, va, vb, a, 5));
            Assert.False(Newton.ShouldBrake(pa, pb, va, vb, a, 0));
        }

        [Test]
        public void TestShouldBrakeReturnsFalseIfCantCatchUp() {
            Vector3 pa = Vector3.zero;
            Vector3 pb = Vector3.up * 65;
            Vector3 va = Vector3.up * 5;
            Vector3 vb = Vector3.up * 10;
            const float a = -5;
            Assert.False(Newton.ShouldBrake(pa, pb, va, vb, a, 5));
        }

        [Test]
        public void TestTerminalSpeed() {
            const float v0 = 10, a = 10, t = 2;
            Assert.AreEqual(30, Newton.TerminalSpeed(v0, a, t));
        }
    }
}
