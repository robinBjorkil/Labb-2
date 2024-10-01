
//String line;
//try
//{
//    //Pass the file path and file name to the StreamReader constructor
//    StreamReader sr = new StreamReader("C:\\Sample.txt");
//    //Read the first line of text
//    line = sr.ReadLine();
//    //Continue to read until you reach end of file
//    while (line != null)
//    {
//        //write the line to console window
//        Console.WriteLine(line);
//        //Read the next line
//        line = sr.ReadLine();
//    }
//    //close the file
//    sr.Close();
//    Console.ReadLine();
//}
//catch (Exception e)
//{
//    Console.WriteLine("Exception: " + e.Message);
//}
//finally
//{
//    Console.WriteLine("Executing finally block.");
//}















//Skapa en klass “LevelData”
public class LevelData
{
    //som har en private field “elements” av typ List<LevelElement>.
    private List<LevelElement>_elements;

    //Denna ska även exponeras i form av en public readonly property “Elements”.
    public List<LevelElement> Elements
    {
        get
        {
            return _elements;
        }

    }
    ////Vidare har LevelData en metod, Load(string filename), som läser in data från filen man anger vid anrop.
    public void Load(string fileName)
    {
        _elements = new List<LevelElement>();
        _elements.Add(new Rat(3, 4));
        _elements.Add(new Rat(3, 4));
        _elements.Add(new Snake(3, 4));
        //Lös denna och Draw() sen ska hela banan läsas! 
        // Load läser igenom textfilen tecken för tecken, och för varje tecken den hittar som är
        //någon av #, r, eller s, så skapar den en ny instans av den klass som motsvarar tecknet och
        //lägger till en referens till instansen på “elements”-listan.
        //foreach (char c in Level1.txt)
        {
            //Console.WriteLine(Level1[c]);
        }
    }

}








////Console.WriteLine("*** StreamReader *******************");

//using (StreamReader reader = new StreamReader("myfile.txt"))
//{
//    while (!reader.EndOfStream)
//    {
//        //Thread.Sleep(50);
//        //Console.Write((char)reader.Read());

//        //Thread.Sleep(200);
//        Console.WriteLine(reader.ReadLine());
//    }

//    //Console.Write(reader.ReadToEnd());









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