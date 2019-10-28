using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_04._07
{
    [TestFixture]
    public class Tests
    {

        private StringTools tools;
        private bool shouldStop;

        private const int RandStrMinSize = 5;
        private const int RandStrMaxSize = 20;
        private const int RandSeed = 407407407;
        private const int RandTestCasesCount = 97;

        [OneTimeSetUp]
        public void Init()
        {
            tools = new StringTools();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase("Hello World", "dlroW olleH")]
        [TestCase("The quick brown fox.", ".xof nworb kciuq ehT")]
        [TestCase("Edabit is really helpful!", "!lufpleh yllaer si tibadE")]
        public void ReverseTest(string str, string expected) =>
            Assert.That(tools.Reverse(str), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void ReverseTestRandom(string str, string expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            Assert.That(tools.Reverse(str), Is.EqualTo(expected));
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var arr = new char[rand.Next(RandStrMinSize, RandStrMaxSize + 1)];

                for (var j = 0; j < arr.Length; j++)
                    arr[j] = (char) rand.Next(' ', 'z' + 1);

                yield return new TestCaseData(new string(arr), new string(arr.Reverse().ToArray()));
            }
        }

    }
}
