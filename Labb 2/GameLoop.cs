
public class GameLoop
{
    private bool isRunning = true;
    private LevelData levelData;

    public GameLoop(LevelData levelData)
    {
        Console.CursorVisible = false;
        this.levelData = levelData;
    }
    public void GameOver()
    {
        Console.WriteLine("YOU DIED!!! ");
    }
    public void Run()
    {
        while (isRunning)  // Sålänge spelet körs, isRunning är true.
        {
            foreach (var element in levelData.Elements.OfType<Enemy>())
            {
                element.Update(levelData.Elements);
            }

            var deadEnemies = levelData.Elements.OfType<Enemy>().Where(e => e.HP <= 0).ToList();

            foreach (var enemy in deadEnemies)
            {
                levelData.Elements.Remove(enemy);
            }

            levelData.DrawElementsWithinRange(5);

            // Rita spelaren efter att dess position kan ha ändrats
            levelData.Player.Draw();

            // Flytta spelaren beroende på vilken tangent de tryckte på
            ConsoleKey key = Console.ReadKey(true).Key; // true för att inte se knapptryckning
            levelData.Player.Move(key, levelData.Elements);

            // Escape-tangent för att avsluta spelet
            if (key == ConsoleKey.Escape || levelData.Player.HP <= 0)
            {
                isRunning = false;  // Avslutar
            }
            if(levelData.Player.HP <= 0)
            {
                //Console.Clear();
                GameOver();
            }
        }
    }

}
