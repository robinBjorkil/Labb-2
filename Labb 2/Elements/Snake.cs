
public class Snake : Enemy
{

    public Snake(int x, int y) : base(x, y, 's', ConsoleColor.Blue)
    {
        Name = "Snake";
        HP = 25;
        AttackDice = new Dice(3, 4, 2); // 3d4+2
        DefenceDice = new Dice(1, 8, 5); // 1d8+5
    }
    public override void Update(List<LevelElement> elements)
    {
        // Rensa den gamla positionen först
        ClearOldPosition();

        // Hitta spelaren
        Player player = elements.OfType<Player>().FirstOrDefault();

        if (player == null)
            return; // Om spelaren inte finns, avsluta metoden

        // Beräkna avståndet till spelaren
        int distanceToPlayerX = Math.Abs(player.X - X);
        int distanceToPlayerY = Math.Abs(player.Y - Y);

        // Om spelaren är mer än 2 rutor bort, stoppa ormen från att flytta sig
        if (distanceToPlayerX > 2 || distanceToPlayerY > 2)
        {
            // Rita ormen på sin nuvarande position om den inte rör sig
            DrawNewPosition();
            return; // Ormen står stilla och gör ingenting
        }

        // Annars flytta ormen bort från spelaren
        int newSnakePositionX = X;
        int newSnakePositionY = Y;

        // Rör ormen bort från spelaren i X-led
        if (player.X < X) // Spelaren är till vänster
        {
            newSnakePositionX = X + 1; // Flytta höger
        }
        else if (player.X > X) // Spelaren är till höger
        {
            newSnakePositionX = X - 1; // Flytta vänster
        }

        // Rör ormen bort från spelaren i Y-led
        if (player.Y < Y) // Spelaren är ovanför
        {
            newSnakePositionY = Y + 1; // Flytta ner
        }
        else if (player.Y > Y) // Spelaren är under
        {
            newSnakePositionY = Y - 1; // Flytta upp
        }

        // Kontrollera om rörelsen är tillåten
        if (IsMoveAllowed(newSnakePositionX, newSnakePositionY, elements))
        {
            X = newSnakePositionX;
            Y = newSnakePositionY;
        }
        LevelElement? playerEncounter = elements.FirstOrDefault(p => p.X == newSnakePositionX && p.Y == newSnakePositionY && p is Player);

        if (playerEncounter is Player)
        {

            DefenceDice.Throw();
            if (player.HP <= 0)
            {
                elements.Remove(player);

            }
        }
        // Rita ormen på den nya positionen
        DrawNewPosition();
    }
}



//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda properties med de unika
//egenskaper som respektive fiende har, samt även implementerar Update-metoden på sina egna unika sätt.
// Alla fiender ärver av klassen Enemy
