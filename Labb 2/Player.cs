
using System.Drawing;
using System.Xml.Linq;

public class Player : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }

    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public Player(int x, int y) : base(x, y, '@', ConsoleColor.Yellow)
    {
        Name = "Player";
        HP = 100;
        AttackDice = new Dice(2, 6, 2); // 2d6+2
        DefenceDice = new Dice(2, 6, 0); // 2d6+0
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
    public bool IsMoveAllowed(int newPositionX, int newPositionY, List<LevelElement> elements)
    {

        LevelElement? enemyEncounter = elements.FirstOrDefault(e => e.X == newPositionX && e.Y == newPositionY && e is Enemy);
        if (enemyEncounter is Enemy enemy)
        {  
            Attack(enemy, elements, true);
            DefendFrom(enemy, true);
        }
        
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
    
    public void Attack(Enemy enemy, List<LevelElement> elements, bool playerAttackingFirst)
    {

        int attackResult = AttackDice.Throw();
        int defenceResult = enemy.DefenceDice.Throw();
        int damage = attackResult - defenceResult;
        if (damage < 0)
        {
            damage = 0;
        }
        if (damage > 0)
        {
            enemy.TakeDamage(damage);//enemy.HP -= damage;
        }
        if (enemy.HP <= 0)
        {
            enemy.HP = 0;
        }
        // info playerattack
        if (playerAttackingFirst == true)
        {
            Console.SetCursorPosition(0, 20);
        }
        else
        {
            Console.SetCursorPosition(0, 21);
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{Name} (HP {HP}) attacks {enemy.Name}! Attack ({this.AttackDice}) = {attackResult} " +
            $"{enemy.Name} (HP {enemy.HP}) Defence ({enemy.DefenceDice}) = {defenceResult} Total Attackpoäng = {damage}".PadRight(Console.BufferWidth));

    }
    
    public void DefendFrom(Enemy enemy, bool playerAttackingFirst)
    {
        int attackPoints = enemy.AttackDice.Throw();
        int defencePoints = DefenceDice.Throw();
        int damage = attackPoints - defencePoints;
        if (damage < 0)
        {
            damage = 0;
        }
        if (damage > 0)
        {
            this.HP -= damage;
        }
        if (this.HP <= 0)
        {
            this.HP = 0;
        }

        //info playerförsvar
        if (playerAttackingFirst == true)
        {
           
            Console.SetCursorPosition(0, 21);
        }
        else
        {
            Console.SetCursorPosition(0, 20);
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{enemy.Name} (HP {enemy.HP}) attacks {Name}! Attack ({enemy.AttackDice}) = {attackPoints} " +
            $"{Name} (HP {HP}) Defence ({DefenceDice}) = {defencePoints} Total Attackpäng = {damage}".PadRight(Console.BufferWidth));

    }

}
