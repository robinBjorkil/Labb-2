

public class Wall : LevelElement
{
    public Wall (int x, int y) : base(x, y, '#', ConsoleColor.Gray)
    {
        //efter baskonstruktor gör sina grejer så görs extra kod här. behövs ej för labben.
    }
    //hårdkoda färgen och tecknet för vägg (en grå hashtag).
}

//Klassen “Wall” ärver av LevelElement, och behöver egentligen ingen egen kod,
//förutom att hårdkoda färgen och tecknet för vägg (en grå hashtag).