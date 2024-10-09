

using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Player : LevelElement
{
   

    public string Name { get; set; }
    public int HP { get; set; }

    public Dice PlayerAttackDice { get; set; }
    public Dice PlayerDefenceDice { get; set; }

    public Player(int x, int y) : base(x, y, '@', ConsoleColor.Yellow)
    {
        Name = "Player";
        HP = 100;
        PlayerAttackDice = new Dice(2, 6, 2); // 2d6+2
        PlayerDefenceDice = new Dice(2, 6, 0); // 2d6+0
    }
   

    public void Move(ConsoleKey key, List<LevelElement> elements)
    {
        Clear();

        // Skapa int för att hänvisa nya positionen till X och Y
        int newPositionX = X;
        int newPositionY = Y;

        // skapa switch med nya positioner
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                newPositionX -= 1; // Flytta vänster
                break;
            case ConsoleKey.RightArrow:
                newPositionX += 1; // Flytta höger
                break;
            case ConsoleKey.UpArrow:
                newPositionY -= 1; // Flytta upp
                break;
            case ConsoleKey.DownArrow:
                newPositionY += 1; // Flytta ner
                break;
        }

        LevelElement? enemyEncounter = elements.FirstOrDefault(e => e.X == newPositionX && e.Y == newPositionY && e is Enemy);
        if (enemyEncounter is Enemy enemy)
        {
            int attackResult = PlayerAttackDice.Throw();
            int defenceResult = enemy.enemyDefenceDice.Throw(); 
            int playerDamage = attackResult - defenceResult;
            if( playerDamage > 0)
            {
                enemy.EnemyTakeDamage(playerDamage);//enemy.HP -= damage;
            }

            int enemyAttackResult = enemy.enemyAttackDice.Throw();
            int playerDefenceResult = PlayerDefenceDice.Throw();
            int enemyDamage = enemyAttackResult - playerDefenceResult;
            if (enemyDamage > 0)
            {
                this.HP -= enemyDamage;
            }

            Console.SetCursorPosition(0, 20);

            Console.WriteLine($"Motståndaren HP = {enemy.HP}  Din HP = {this.HP}".PadRight(Console.BufferWidth));
            if (enemy.HP <= 0)
            {
                enemy.HP = 0;
                elements.Remove(enemy);
                
            }
            else if (this.HP <= 0)
            {
                //Exit game!!!
            }
        }

        // Kontrollera om den nya positionen är giltig
        if (IsMoveAllowed(newPositionX, newPositionY, elements))
        {
            // Sätt X och Y till sina nya positioner
            X = newPositionX;
            Y = newPositionY;
        }

        Draw();
    }

    // Metod för att kontrollera om rörelsen är giltig
    private bool IsMoveAllowed(int newPositionX, int newPositionY, List<LevelElement> elements)
    {
        // Kontrollera om den nya positionen är blockerad av ett objekt
        foreach (var element in elements)
        {
            if (element.X == newPositionX && element.Y == newPositionY)
            {
                return false;
            }
        }
        //returnera true i motsats till false
        return true;
    }

}
