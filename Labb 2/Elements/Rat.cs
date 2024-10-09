
public class Rat : Enemy
{
    public Rat(int x, int y) : base(x, y, 'r', ConsoleColor.Red)
    {
        Name = "Rat";
        HP = 10;
        AttackDice = new Dice(1, 6, 3); // 1d6+3
        DefenceDice = new Dice(1, 6, 1); // 1d6+1
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
            player.DefendFrom(this);
            player.Attack(this, elements);
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

