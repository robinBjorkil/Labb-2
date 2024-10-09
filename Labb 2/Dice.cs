﻿
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
        // Slumpa ett tal mellan 1 och antal sidor per tärning
        //rnd.Next(1, sidesPerDice + 1);

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




//definiera upp alla antal, sidor + modifiers som separata properties i levelelement. KLART!
//hårdkoda in dina värden med en override i player, rat och snake KLART!
//i Dice kalla på levelelement.numberOfDice t.ex. så får du rätt tärning baserat på vilket objekt som tärningen rullas för





//Skriva ut


//        Console.WriteLine($"Spelaren attackerade {enemy.Name} och gjorde {damageToEnemy} skada. {enemy.Name} HP: {enemy.HP}");

//        if (enemy.HP <= 0)
//        {
//            Console.WriteLine($"{enemy.Name} har dött!");
//            break;
//        }


//        Console.WriteLine($"{enemy.Name} attackerade spelaren och gjorde {damageToPlayer} skada. Spelarens HP: {player.HP}");

//        if (player.HP <= 0)
//        {
//            Console.WriteLine("Spelaren har dött!");
//            break;

