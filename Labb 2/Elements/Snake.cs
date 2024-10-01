

public class Snake : Enemy
{
    public Snake(int x, int y) : base(x, y, 'r', ConsoleColor.Blue)
    {
        Name = "Snake";
        HP = 25;//här väljer jag själv hur mycket health jag vill ha.
    }

    public override void Update()
    {
        throw new NotImplementedException();// detta ska bytas ut och betyder att jag inte skapat någon kod här.
    }
}



//Slutligen har vi klasserna “Rat” och “Snake” som initialiserar sina nedärvda properties med de unika
//egenskaper som respektive fiende har, samt även implementerar Update-metoden på sina egna unika sätt.
// Alla fiender ärver av klassen Enemy