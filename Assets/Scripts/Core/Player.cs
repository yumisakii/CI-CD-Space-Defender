namespace SpaceDefender.Core
{
    public class Player
    {
        public int Health { get; private set; } = 100;
        public int Lives { get; private set; } = 3;
        public int Score { get; private set; } = 0;

        public bool IsAlive => Health > 0 && Lives > 0;

        public void TakeDamage(int amount)
        {
            if (amount < 0) return;

            Health -= amount;

            if (Health < 0) Health = 0;
        }

        public void Heal(int amount)
        {
            if (amount < 0) return;

            Health += amount;

            if(Health > 100) Health = 100;
        }

        public void AddScore(int points)
        {
            if (points < 0) return;
            Score += points;
        }
        public void LoseLife()
        {
            Lives -= 1;

            if (Lives < 0) Lives = 0;
        }
    }
}