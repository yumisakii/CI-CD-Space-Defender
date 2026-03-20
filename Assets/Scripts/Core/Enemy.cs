namespace SpaceDefender.Core
{
    public class Enemy
    {
        public int Health { get; private set; }
        public int PointValue { get; private set; }

        // Stubbed property, currently always returns true
        public bool IsAlive = true;

        // Constructor to set initial values
        public Enemy(int health, int pointValue)
        {
            Health = health;
            PointValue = pointValue;
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0) return;

            Health -= amount;

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }
        public int GetReward()
        {
            if (IsAlive) return PointValue;
            else return 0;
        }
    }
}