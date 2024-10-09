

using System;
using System.Data;



public class Rat : Enemy
{
    public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.Red)
    {
        Name = "Rat";
        HP = 10;
        enemyAttackDice = new Dice(1, 6, 3); // 1d6+3
        enemyDefenceDice = new Dice(1, 6, 1); // 1d6+1
    }
    
    public override void Update(List<LevelElement> elements)
    {
        ClearOldPosition();

        Random random = new Random();
        int ratMove = random.Next(4);

        int newRatPositionX = X;
        int newRatPositionY = Y;

        switch (ratMove)
        {
            case 0: // Vänster
                newRatPositionX = X - 1;
                break;

            case 1: // Höger
                newRatPositionX = X + 1;
                break;

            case 2: // Upp
                newRatPositionY = Y - 1;
                break;

            case 3: // Ner
                newRatPositionY = Y + 1;
                break;
        }

        LevelElement? playerEncounter = elements.FirstOrDefault(p => p.X == newRatPositionX && p.Y == newRatPositionY && p is Player);

        if (playerEncounter is Player player)
        {
            enemyAttackDice.Throw();
            player.PlayerDefenceDice.Throw();

            int enemyAttackResult = enemyAttackDice.Throw();
            int playerDefenceResult = player.PlayerDefenceDice.Throw();
            int enemyDamage = enemyAttackResult - playerDefenceResult;
            
            if (player.HP >0)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine($"Råttan attackerar spelaren med {enemyDamage} Spelarens nuvarande HP: {player.HP -= enemyDamage}");
            }

            int playerAttackResult = player.PlayerAttackDice.Throw();
            int defenceResult = enemyDefenceDice.Throw();
            int playerDamage = playerAttackResult - defenceResult;
            this.HP -= playerDamage;
        }

        // Använda IsMoveAllowed för att kontrollera och uppdatera positionen
        if (IsMoveAllowed(newRatPositionX, newRatPositionY, elements))
        {
            X = newRatPositionX;
            Y = newRatPositionY;
        }

        DrawNewPosition();
    }
}

//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda properties med de unika
//egenskaper som respektive fiende har, samt även implementerar Update-metoden på sina egna unika sätt.
// Alla fiender ärver av klassen Enemy

