namespace AdventOfCode2021.Tests.Days.Day22
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day22.Factory;

    [TestClass]
    public class Range3DTestsTests
    {
        [TestMethod]
        public void SplitOut_SplitsLeftPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-5, 10), Range(-10, 10), Range(-10, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { X = Range(-10, -6) });
        }

        [TestMethod]
        public void SplitOut_SplitsRightPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-10, -5), Range(-10, 10), Range(-10, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { X = Range(-4, 10) });
        }

        [TestMethod]
        public void SplitOut_SplitsLeftAndRightPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-5, 5), Range(-10, 10), Range(-10, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { X = Range(-10, -6) });
            CollectionAssert.Contains(parts, self with { X = Range(6, 10) });
        }

        [TestMethod]
        public void SplitOut_SplitsTopPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-10, 10), Range(-5, 10), Range(-10, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { Y = Range(-10, -6) });
        }

        [TestMethod]
        public void SplitOut_SplitsBottomPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-10, 10), Range(-10, -5), Range(-10, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { Y = Range(-4, 10) });
        }

        [TestMethod]
        public void SplitOut_SplitsFrontPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-10, 10), Range(-10, 10), Range(-5, 10));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { Z = Range(-10, -6) });
        }

        [TestMethod]
        public void SplitOut_SplitsBackPartOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, -5));

            var (_, parts) = self.SplitOut(other);

            CollectionAssert.Contains(parts, self with { Z = Range(-4, 10) });
        }

        [TestMethod]
        public void SplitOut_SplitsAllPartsOutFromSelf()
        {
            var self = Range3D(Range(-10, 10), Range(-10, 10), Range(-10, 10));
            var other = Range3D(Range(-5, 5), Range(-5, 5), Range(-5, 5));

            var (common, parts) = self.SplitOut(other);

            Assert.AreEqual(Range3D(Range(-5, 5), Range(-5, 5), Range(-5, 5)), common);
            Assert.AreEqual(6, parts.Count);
        }
    }
}
