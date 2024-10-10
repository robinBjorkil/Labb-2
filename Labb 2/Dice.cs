
public class Dice
{
    private int numberOfDice;
    private int sidesPerDice;
    private int modifier;

    private Random rnd = new Random();

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
    }

    public int Throw()
    {
        int diceRoll = 0;
        int totalOfThrowDice = 0;

        for (int i = 0; i < numberOfDice; i++)
        {
            diceRoll = rnd.Next(1, sidesPerDice + 1);
            totalOfThrowDice += diceRoll;
        }
        totalOfThrowDice += modifier;

        return totalOfThrowDice;
    }

    public override string ToString()
    {
        return $"{numberOfDice}d{sidesPerDice}+{modifier}";
    }
}


