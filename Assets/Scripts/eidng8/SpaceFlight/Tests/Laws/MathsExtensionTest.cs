// ---------------------------------------------------------------------------
// <copyright file="MathsExtensionTest.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Globalization;
using eidng8.SpaceFlight.Laws;
using NUnit.Framework;
using UnityEngine;
using Random = System.Random;


namespace eidng8.SpaceFlight.Tests.Laws
{
    public class MathsExtensionTest
    {
        [Test]
        public void TestAboutEqualDealsWithTolerance() {
            const float a = .1f, b = .2f;
            Assert.True(a.AboutEqual(b, .2f));
            Assert.False(a.AboutEqual(b, .05f));
        }

        [Test]
        public void TestAboutEqualIsCommutative() {
            const float a = .1f, b = .2f;
            Assert.True(a.AboutEqual(b, .2f));
            Assert.True(b.AboutEqual(a, .2f));
        }

        [Test]
        public void TestAboutZeroDealsWithTolerance() {
            const float a = .1f;
            Assert.True(a.AboutZero(.2f));
            Assert.False(a.AboutZero(.05f));
        }

        [Test]
        public void TestIsFacingDealsWithCommutative() {
            Vector3 v1 = Vector3.up, v2 = Vector3.one;
            Assert.True(v1.IsFacing(v2, 55));
            Assert.True(v2.IsFacing(v1, 55));
        }

        [Test]
        public void TestIsFacingDealsWithTolerance() {
            Vector3 v1 = Vector3.up, v2 = Vector3.one;
            Assert.True(v1.IsFacing(v2, 55));
            Assert.False(v1.IsFacing(v2, 30));
        }

        [Test]
        public void TestValidateNegativeValueShouldInvokeProperCallbacks() {
            bool tt = false, tf = false;
            Random rand = new Random();
            string sub = rand.Next().ToString(CultureInfo.InvariantCulture);
            string ret = (-.1f).ValidateNegativeValue(
                sub,
                () => tt = true,
                () => tf = true
            );
            Assert.IsEmpty(ret);
            Assert.True(tt);
            Assert.False(tf);

            tt = false;
            tf = false;
            sub = rand.Next().ToString(CultureInfo.InvariantCulture);
            ret = .1f.ValidateNegativeValue(
                sub,
                () => tt = true,
                () => tf = true
            );
            StringAssert.Contains(sub, ret);
            Assert.False(tt);
            Assert.True(tf);
        }

        [Test]
        public void TestValidatePositiveValueShouldInvokeProperCallbacks() {
            bool tt = false, tf = false;
            Random rand = new Random();
            string sub = rand.Next().ToString(CultureInfo.InvariantCulture);
            string ret = .1f.ValidatePositiveValue(
                sub,
                () => tt = true,
                () => tf = true
            );
            Assert.IsEmpty(ret);
            Assert.True(tt);
            Assert.False(tf);

            tt = false;
            tf = false;
            sub = rand.Next().ToString(CultureInfo.InvariantCulture);
            ret = (-.1f).ValidatePositiveValue(
                sub,
                () => tt = true,
                () => tf = true
            );
            StringAssert.Contains(sub, ret);
            Assert.False(tt);
            Assert.True(tf);
        }
    }
}
