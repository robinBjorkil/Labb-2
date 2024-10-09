

public class GameLoop
{

    private bool isRunning = true;  // Variabel för att hålla reda på om spelet ska fortsätta köras
    private LevelData levelData;  // Innehåller alla element i spelet (spelare, fiender, väggar)

    public GameLoop(LevelData levelData)
    {
        Console.CursorVisible = false;
        this.levelData = levelData;
    }

    public void Run()
    {
        levelData.Draw();

        while (isRunning)  // Sålänge spelet körs, isRunning är true.
        {
            foreach (var element in levelData.Elements.OfType<Enemy>())
            {
                element.Update(levelData.Elements);
            }

            // Rita spelaren efter att dess position kan ha ändrats
            levelData.Player.Draw();

            // Flytta spelaren beroende på vilken tangent de tryckte på
            ConsoleKey key = Console.ReadKey(true).Key; // true för att inte se knapptryckning
            levelData.Player.Move(key, levelData.Elements);

            // Escape-tangent för att avsluta spelet
            if (key == ConsoleKey.Escape)
            {
                isRunning = false;  // Avslutar
            }
        }
    }



    //visionrange
    //public bool IsInVisionRange(Player player, LevelElement element)
    //{
    //    int distance = Math.Sqrt(Math.Pow(this.X - element.X, 2) + Math.Pow(this.Y - element.Y, 2));
    //    return distance <= VisionRange;
    //}

}
//Ansvarar för att:

// 1. Lyssna på spelarens inmatning (t.ex. om spelaren trycker på en tangent för att flytta sig).
// 2. Flytta spelaren eller fienderna baserat på deras beteenden.
// 3. Uppdatera spelets grafik, så att spelaren ser vad som händer på skärmen.
// 4. Kontrollera om spelet är över (t.ex. om spelaren har dött eller besegrat alla fiender).
