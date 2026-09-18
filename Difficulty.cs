struct Difficulty
{
    public string name;
    public int playWidth;
    public int playHeight;

    public int tileWidth;
    public int amountOfRows;
    public int rows;

    public int paddleMoveSpeed;
    public int ballMoveSpeed;

    public int health;

    public bool BlockDistraction;
    public bool BreakableBlockDistraction;
    public bool BreakableBlockDistractionSlop;
    public bool SoundDistractions;

    public Difficulty()
    {

    }

    public void Print()
    {
        System.Console.WriteLine("playWidth " + playWidth);
        System.Console.WriteLine("playHeight " + playHeight);

        System.Console.WriteLine("tileWidth " + tileWidth);
        System.Console.WriteLine("amountOfRows " + amountOfRows);
        System.Console.WriteLine("rows " + rows);

        System.Console.WriteLine("paddleMoveSpeed " + paddleMoveSpeed);
        System.Console.WriteLine("ballMoveSpeed " + ballMoveSpeed);

        System.Console.WriteLine("health " + health);
    }
}

