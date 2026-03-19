using NUnit.Framework;
using SpaceDefender.Core;

namespace SpaceDefender.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            // Arrange: Initialization before each test
            _player = new Player();
        }

        [Test]
        public void TakeDamage_Normal_ReducesHealth()
        {
            // Act
            int damage = 20;
            _player.TakeDamage(damage);

            // Assert
            Assert.AreEqual(80, _player.Health);
        }

        [Test]
        public void TakeDamage_WithFatalDamage_SetsHealthToZero()
        {
            // Arrange (Setup is already creating a fresh _player with 100 Health)

            // Act
            _player.TakeDamage(150); // More damage than we have health

            // Assert
            Assert.AreEqual(0, _player.Health); // Health should stop at 0, not go to -50
        }

        [Test]
        public void TakeDamage_WithNegativeAmount_DoesNotChangeHealth()
        {
            // Arrange

            // Act
            _player.TakeDamage(-20); // Negative damage shouldn't heal the player

            // Assert
            Assert.AreEqual(100, _player.Health); // Health should remain at the starting 100
        }
    }
}