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
            var branchList = new List<Branch>();

            var result = _calculator.Counter(branchList);

            result.Should().Be(1);
        }

        [TestMethod]
        public void CalculateDepth_TwoLevels_ReturnsTwo()
        {
            var branchList = new List<Branch>
            {
                new Branch(new List<Branch>())
            };

            var branchListNull = new List<Branch>
            {
                new Branch()
            };

            var result = _calculator.Counter(branchList);
            var resultNull = _calculator.Counter(branchListNull);

            result.Should().Be(2);
            resultNull.Should().Be(2);
        }

        [TestMethod]
        public void CalculateDepth_LargeDepth_ReturnsDepth()
        {
            var thirdDegreeList = new List<Branch>
            {
                new Branch(new List<Branch>
                {
                    new Branch()
                })
            };

            var seventhDegreeList = new List<Branch>
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
            };

            var thirdDegreeResult = _calculator.Counter(thirdDegreeList);
            var seventhDegreeResult = _calculator.Counter(seventhDegreeList);

            thirdDegreeResult.Should().Be(3);
            seventhDegreeResult.Should().Be(7);
        }

        [TestMethod]
        public void CalculateDepth_MixedLevels_ReturnsDepth()
        {
            var branchList = new List<Branch>
            {
                new Branch(),
                new Branch(new List<Branch>
                {
                    new Branch()
                })
            };

            var result = _calculator.Counter(branchList);

            result.Should().Be(3);
        }
    }
}
