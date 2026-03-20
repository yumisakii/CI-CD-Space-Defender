using NUnit.Framework;
using SpaceDefender.Core;

namespace SpaceDefender.Tests
{
    [TestFixture]
    public class EnemyTests
    {
        private Enemy _enemy;

        [SetUp]
        public void Setup()
        {
            // Arrange: Initialize an enemy with 50 health and a 100 point reward
            _enemy = new Enemy(50, 100);
        }

        [Test]
        public void TakeDamage_WhenKilled_SetsIsAliveToFalse()
        {
            // Act
            _enemy.TakeDamage(50); // Deal exactly lethal damage

            // Assert
            Assert.IsFalse(_enemy.IsAlive);
        }

        [Test]
        public void GetReward_WhenAlreadyDead_ReturnsZero()
        {
            // Arrange
            _enemy.TakeDamage(50); // Kill the enemy first

            // Act
            int reward = _enemy.GetReward();

            // Assert
            Assert.AreEqual(0, reward); // A dead enemy shouldn't give points twice
        }

        [Test]
        public void TakeDamage_WithNegativeAmount_DoesNotHealEnemy()
        {
   
            _enemy.TakeDamage(-50);

            Assert.AreEqual(50, _enemy.Health);
        }
    }
}