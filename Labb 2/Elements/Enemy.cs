
public abstract class Enemy : LevelElement
{
    protected Enemy(int x, int y, char icon, ConsoleColor consoleColor) : base(x, y, icon, consoleColor)
    {
    }
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public void TakeDamage(int playerDamage)
    {
        this.HP -= playerDamage;
        if (this.HP < 0)
        {
            this.HP = 0;
        }
    }

    // Metod för att kontrollera om rörelsen är giltig
    protected bool IsMoveAllowed(int newX, int newY, List<LevelElement> elements)
    {
        foreach (var element in elements)
        {
            if (element.X == newX && element.Y == newY)
            {
                return false; // Kollision med ett objekt
            }
        }
        return true; // Ingen kollision, flytten är giltig
    }

    // Metod för att radera ikonen från den gamla positionen
    protected void ClearOldPosition()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(' '); // Ritar en tom yta på den gamla positionen
    }

    public abstract void Update(List<LevelElement> elements);
}










// lägger till funktionalitet som är specifik för fiender.

// Även Enemy är abstrakt, då vi inte vill att man ska kunna instansiera ospecifika “fiender”.

// Alla riktiga fiender ärver av denna klass. Enemy ska ha properties för namn
// (t.ex snake/rat), hälsa (HP),
//
// samt AttackDice och DefenceDice av typen Dice
// (mer om detta längre ner). Den ska även ha en abstrakt Update-metod,
// som alltså inte implementeras i denna klass, men som kräver att alla som ärver av klassen
// implementerar den. Vi vill alltså kunna anropa Update-metoden på alla fiender och
// sedan sköter de olika subklasserna hur de uppdateras (till exempel olika förflyttningsmönster).