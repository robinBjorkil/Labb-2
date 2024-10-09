
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
    private bool IsMoveAllowed(int newPositionX, int newPositionY, List<LevelElement> elements)
    {

        LevelElement? enemyEncounter = elements.FirstOrDefault(e => e.X == newPositionX && e.Y == newPositionY && e is Enemy);
        if (enemyEncounter is Enemy enemy)
        {
            Attack(enemy, elements);
            DefendFrom(enemy);

            //UTSKRIFT
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Motståndaren HP = {enemy.HP}  Din HP = {this.HP}".PadRight(Console.BufferWidth));
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

    public void Attack(Enemy enemy, List<LevelElement> elements)
    {
        int attackResult = AttackDice.Throw();
        int defenceResult = enemy.DefenceDice.Throw();
        int damage = attackResult - defenceResult;
        if (damage > 0)
        {
            enemy.TakeDamage(damage);//enemy.HP -= damage;
        }
        if (enemy.HP <= 0)
        {
            enemy.HP = 0;
        }
    }

    public void DefendFrom(Enemy enemy)
    {
        int attackPoints = enemy.AttackDice.Throw();
        int defencePoints = DefenceDice.Throw();
        int damage = attackPoints - defencePoints;
        if (damage > 0)
        {
            this.HP -= damage;
        }
        if (this.HP <= 0)
        {
            this.HP = 0;
        }

        //UTSKRIFT
        if (this.HP > 0)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Råttan attackerar spelaren med {damage} Spelarens nuvarande HP: {this.HP}");
        }
    }

}
