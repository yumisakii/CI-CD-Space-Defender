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

        [Test]
        public void Heal_WhenHealthBelow100_IncreasesHealth()
        {
            // Arrange
            _player.TakeDamage(50); // We need to lower the health first so there is room to heal

            // Act
            _player.Heal(30);

            // Assert
            Assert.AreEqual(80, _player.Health); // 50 + 30 = 80
        }

        [Test]
        public void Heal_WhenAlreadyFullHealth_DoesNotExceed100()
        {
            // Arrange 
            // The [SetUp] already gives us a fresh player with 100 Health, so we don't need to do anything here.

            // Act
            _player.Heal(50); // Try to over-heal

            // Assert
            Assert.AreEqual(100, _player.Health); // Health should be capped at the maximum of 100
        }

        [Test]
        public void IsAlive_WhenHealthIsZero_ReturnsFalse()
        {
            // Arrange
            _player.TakeDamage(100); // Bring health down to exactly 0

            // Act
            bool isAlive = _player.IsAlive;

            // Assert
            Assert.IsFalse(isAlive);
        }

        [Test]
        public void LoseLife_WhenLastLife_IsAliveReturnsFalse()
        {
            // Arrange: The player starts with 3 lives by default
            _player.LoseLife(); // 2 lives left
            _player.LoseLife(); // 1 life left

            // Act: Lose the final life
            _player.LoseLife();

            // Assert
            Assert.AreEqual(0, _player.Lives); // Verify lives count is actually 0
            Assert.IsFalse(_player.IsAlive);   // Verify the player is no longer alive
        }


        // Bonus Tests

        [Test]
        public void AddScore_WithNegativePoints_ScoreRemainsUnchanged()
        {
            int score = _player.Score;

            _player.AddScore(-100);

            Assert.AreEqual(score, _player.Score);
        }

        [Test]
        public void Heal_WithNegativeAmount_DoesNotReduceHealth()
        {
            // Arrange
            _player.Heal(-100);

            // Assert
            Assert.AreEqual(100, _player.Health);
        }
    }
}