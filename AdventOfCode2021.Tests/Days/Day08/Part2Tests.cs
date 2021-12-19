namespace AdventOfCode2021.Tests.Days.Day08
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day08.Part2;

    [TestClass]
    public class Part2Tests
    {
        [TestMethod]
        public void SumOutputValues_ForExample_Returns61229()
        {
            var input = Example.Lines;

            var result = SumOutputValues(input);

            Assert.AreEqual(61229, result);
        }
    }
}
