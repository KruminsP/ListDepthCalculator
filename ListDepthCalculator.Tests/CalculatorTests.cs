using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ListDepthCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void CalculateDepth_OneLevel_ReturnsOne()
        {
            var branch = new Branch();

            var result = _calculator.Counter(branch);

            result.Should().Be(1);
        }

        [TestMethod]
        public void CalculateDepth_TwoLevels_ReturnsTwo()
        {
            var branch = new Branch(
                new List<Branch>
                {
                    new Branch()
                });


            var result = _calculator.Counter(branch);

            result.Should().Be(2);
        }

        [TestMethod]
        public void CalculateDepth_LargeDepth_ReturnsDepth()
        {
            var thirdDegreeBranch = new Branch(new List<Branch>
            {
                new Branch(new List<Branch>
                {
                    new Branch()
                })
            });

            var seventhDegreeBranch = new Branch(new List<Branch>
            {
                new Branch(new List<Branch>
                {
                    new Branch(new List<Branch>
                    {
                        new Branch(new List<Branch>
                        {
                            new Branch(new List<Branch>
                            {
                                new Branch(new List<Branch>
                                {
                                    new Branch()
                                })
                            })
                        })
                    })
                })
            });

            var thirdDegreeResult = _calculator.Counter(thirdDegreeBranch);
            var seventhDegreeResult = _calculator.Counter(seventhDegreeBranch);

            thirdDegreeResult.Should().Be(3);
            seventhDegreeResult.Should().Be(7);
        }

        [TestMethod]
        public void CalculateDepth_MixedLevels_ReturnsDepth()
        {
            var branch = new Branch(new List<Branch>
            {
                new Branch(),
                new Branch(new List<Branch>
                {
                    new Branch()
                })
            });

            var result = _calculator.Counter(branch);

            result.Should().Be(3);
        }
    }
}
