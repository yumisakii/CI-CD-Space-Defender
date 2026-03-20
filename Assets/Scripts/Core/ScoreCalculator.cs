namespace SpaceDefender.Core
{
    public class ScoreCalculator
    {
        public int BaseScore { get; private set; } = 100; // Arbitrary base score per kill
        public int Multiplier { get; private set; } = 1;

        public int Calculate(int kills, int time)
        {
            return (kills * BaseScore * Multiplier);
        }

        public void ApplyCombo(int comboCount)
        {
            Multiplier += 1;
        }

        public void ResetMultiplier()
        {
            Multiplier = 1;
        }
    }
}