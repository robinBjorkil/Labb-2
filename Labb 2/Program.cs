


public class Program
{
    public static void Main(string[] args)
    {
       
        // Skapa en instans av LevelData
        LevelData levelData = new LevelData();

        // Ladda spelets nivådata (t.ex. spelare, fiender, väggar)
        levelData.Load(levelData.path);

        // Skapa en instans av GameLoop och skicka levelData till den
        GameLoop gameLoop = new GameLoop(levelData);

        // Starta spelets loop
        gameLoop.Run();
    }
}



