namespace AdventOfCode2021.Tests.Days.Day08
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static AdventOfCode2021.Days.Day08.Part1;

    [TestClass]
    public class Part1Tests
    {
        [TestMethod]
        public void CountRecognizedNumbers_ForExample_Returns26()
        {
            var input = Example.Input;

            var result = CountRecognizedNumbers(input);

            Assert.AreEqual(26, result);
        }
    }
}
