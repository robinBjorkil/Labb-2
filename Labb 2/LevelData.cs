//Skapa en klass “LevelData”
using System.Xml.Linq;

public class LevelData
{
    //som har en private field “elements” av typ List<LevelElement>.
    private List<LevelElement> _elements;
    public string path = @"Levels\\Level1.txt";
    //Denna ska även exponeras i form av en public readonly property “Elements”.
    public List<LevelElement> Elements
    {
        get
        {
            return _elements;
        }

    }

    public Player Player { get; set; }

    public LevelData()
    {
        _elements = new List<LevelElement>();
    }


    ////Vidare har LevelData en metod, Load(string filename), som läser in data från filen man anger vid anrop.
    public void Load(string fileName)
    {
        List<string> linesFromLevel1 = File.ReadAllLines(fileName).ToList();

        _elements = new List<LevelElement>();

        for (int y = 0; y < linesFromLevel1.Count; y++)
        {
            for (int x = 0; x < linesFromLevel1[y].Length; x++)
            {
                char currentChar = linesFromLevel1[y][x];

                switch (currentChar)
                {
                    case '#':
                        Elements.Add(new Wall(x, y));
                        break;
                    case 'r':
                        Elements.Add(new Rat(x, y));
                        break;
                    case 's':
                        Elements.Add(new Snake(x, y));
                        break;
                    case '@':
                        Player = new Player(x, y);
                        Elements.Add(Player);
                        break;
                }
            }
        }
    }

    public void Draw()
    {
        foreach (var element in Elements)
        {
            element.Draw();
        }
    }
}



//Skapa en klass “LevelData” som har en private field “elements” av typ List<LevelElement>.
//Denna ska även exponeras i form av en public readonly property “Elements”.

//Vidare har LevelData en metod, Load(string filename), som läser in data från filen man anger vid anrop.
//Load läser igenom textfilen tecken för tecken, och för varje tecken den hittar som är
//någon av #, r, eller s, så skapar den en ny instans av den klass som motsvarar tecknet och lägger till
//en referens till instansen på “elements”-listan.
//Tänk på att när instansen skapas så måste den även få en (X/Y) position; d.v.s Load behöver alltså
//hålla reda på vilken rad och kolumn i filen som tecknet hittades på.
//Den behöver även spara undan startpositionen för spelaren när den stöter på @.

//När filen är inläst bör det alltså finnas ett objekt i “elements” för varje tecken i filen
//(exkluderat space/radbyte), och en enkel foreach-loop som anropar .Draw() för varje element i listan,
//bör nu rita upp hela banan på skärmen.