

LevelData level = new LevelData();
level.Load("level1.txt");

foreach (LevelElement element in level.Elements)
{
    element.Draw();

}
//Rat rat = new Rat(3, 4);
//Snake snake = new Snake(5, 6);
//Wall wall = new Wall(4, 6);
//rat.Draw();
//snake.Draw();
//wall.Draw();

//Dice dice1 = new Dice();

//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda properties med de unika
//egenskaper som respektive fiende har, samt även implementerar Update-metoden på sina egna unika sätt.
// Alla fiender ärver av klassen Enemy
LevelData levelData = new LevelData();
levelData.Load("Level1.txt");

foreach (LevelElement element in levelData.Elements)
{
    element.Draw();
}