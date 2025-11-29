public class Player
{
    private Random _random = new Random();
    
    public int RollDie() => _random.Next(1, 19);

    public double GenerateSpellStrength() => _random.NextDouble() * 100.0d;
}
