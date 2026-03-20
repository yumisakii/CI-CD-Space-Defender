using NUnit.Framework;
using SpaceDefender.Core;

namespace SpaceDefender.Tests
{
    [TestFixture]
    public class ScoreCalculatorTests
    {
        private ScoreCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new ScoreCalculator();
        }

        [Test]
        public void Calculate_WithZeroKills_ReturnsZero()
        {
            // Act: 0 kills, 60 seconds elapsed
            int score = _calculator.Calculate(0, 60);

            // Assert
            Assert.AreEqual(0, score);
        }

        [Test]
        public void ApplyCombo_With3Kills_IncreasesMultiplier()
        {
            // Arrange
            float initialMultiplier = _calculator.Multiplier;

            // Act
            _calculator.ApplyCombo(3);

            // Assert
            Assert.Greater(_calculator.Multiplier, initialMultiplier);
        }

        [Test]
        public void ResetMultiplier_AfterCombo_SetsMultiplierToOne()
        {
            // Arrange: Change the multiplier first
            _calculator.ApplyCombo(5);

            // Act
            _calculator.ResetMultiplier();

            // Assert
            Assert.AreEqual(1.0f, _calculator.Multiplier); // Should be exactly 1.0f after reset
        }

        [Test]
        public void Calculate_AfterComboAndReset_UsesBaseMultiplier()
        {
            // Arrange
            _calculator.ApplyCombo(3); // Increase multiplier
            _calculator.ResetMultiplier(); // Reset it back to 1.0f
            int expectedScore = 5 * _calculator.BaseScore; // 5 kills at a 1.0x multiplier

            // Act
            int actualScore = _calculator.Calculate(5, 60);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}