

public class Wall : LevelElement
{
    //hårdkoda färgen och tecknet för vägg (en grå hashtag).
    public Wall (int x, int y) : base(x, y, '#', ConsoleColor.Gray)
    {
    
    }
    
}

//Klassen “Wall” ärver av LevelElement, och behöver egentligen ingen egen kod,
//förutom att hårdkoda färgen och tecknet för vägg (en grå hashtag).