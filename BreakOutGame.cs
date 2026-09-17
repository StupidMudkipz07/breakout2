class BreakOutGame
{
    //state that doesnt change between tries

    static public string[] difficulties;
    static public int MaxFps = 600;

    static public int windowWidth = 1920;
    static public int windowHeight = 1080;

    public static int playWidth = 1000;
    public static int playHeight = 1050;

    public static int tileWidth = 100;
    public static int amountOfRows = 6;
    public static int rows = 6;

    //

    public int points = 0;
    public int health = 3;
    GameObjectHandler handler;
    Ball boll;
    Paddle paddel;
    Text Gui;
    Block[] boundaries = new Block[4];
    List<BreakableBlock> tiles = new();
    public RenderWindow denLustigaSkärmen;

    void BallEvent()
    {
        health--;
        boll.Reset();
    }

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        handler = new();
        paddel = new(windowHeight - 140, handler);

        boll = new(new(windowWidth / 2, playHeight / 2), paddel, handler);

        //när bollen når utanför skärmen så kallas detta event
        boll.BallLeftScreen += (_, _) => { BallEvent(); };

        MakeBoundaries();

        MakeTiles(tileWidth, amountOfRows, rows);

        Gui = new Text
        {
            CharacterSize = 45,
            Font = new Font("assets/future.ttf")
        };
    }

    void MakeTiles(int tileWidth, int amountPerRow, int rows)
    {
        //math
        int amountOfTilesPerColumn = amountPerRow;
        int GapBetweenTiles = (playWidth - amountOfTilesPerColumn * tileWidth) / (amountOfTilesPerColumn + 1);

        int tileHeight = tileWidth / 2;
        int rowGap = 67;


        Vector2f playSpaceOrigin = new((windowWidth - playWidth) / 2, windowHeight - playHeight);

        for (int i = 0; i < rows; i++)
        {
            //generate tiles for each column
            for (int j = 0; j < amountOfTilesPerColumn; j++)
            { //
                Vector2f positon = new(playSpaceOrigin.X + (j * tileWidth) + (GapBetweenTiles * (j + 1)), playSpaceOrigin.Y + rowGap * (i + 1));
                Vector2f tileSize = new(tileWidth, tileHeight);
                string color = "";
                switch (i % 3)
                {
                    case 0:
                        color += "Pink";
                        break;
                    case 1:
                        color += "Green";
                        break;

                    case 2:
                        color += "Blue";
                        break;
                }
                MakeBreakableBlock(positon, tileSize, color);
            }
        }
    }

    void MakeBoundaries()
    {
        //math
        int mcnuttWidth = (windowWidth - playWidth) / 2;
        int mcnuttHeight = windowHeight - playHeight;

        boundaries[0] = MakeBlock(new(0, 0), new(mcnuttWidth, windowHeight));
        boundaries[1] = MakeBlock(new(windowWidth - mcnuttWidth, 0), new(mcnuttWidth, windowHeight), "assets/binding.png");
        boundaries[2] = MakeBlock(new(mcnuttWidth, 0), new(windowWidth - (mcnuttWidth * 2), mcnuttHeight), "assets/math.png");
        //boundaries[3] = MakeBlock(new(mcnuttWidth, windowHeight - 40), new(windowWidth - (mcnuttWidth * 2), 40));
    }

    Vector2f OriginOffset(Vector2f desiredPos, Vector2f size) => desiredPos + (size / 2);

    Block MakeBlock(Vector2f pos, Vector2f size) => new(size, OriginOffset(pos, size), "", handler);

    Block MakeBlock(Vector2f pos, Vector2f size, string sprite) => new(size, OriginOffset(pos, size), sprite, handler);

    BreakableBlock MakeBreakableBlock(Vector2f pos, Vector2f size, string color)
    {
        BreakableBlock båt = new(size, OriginOffset(pos, size), color, handler);
        tiles.Add(båt);
        båt.BlockBreaked += (_, _) =>
        {
            points++;
            //om inte den här finns så finns den fortfarande kvar i tileslistan och då resettas inte tilesen 
            tiles.Remove(båt);
        };
        return båt;
    }

    void CheckTiles()
    {
        if (tiles.Count == 0)
        {
            MakeTiles(tileWidth, amountOfRows, rows);
        }
    }

    public void Update(float deltaTime)
    {
        handler.GibbGubb(deltaTime);
        CheckTiles();
    }

    public void DrawStuff()
    {
        handler.Draw(denLustigaSkärmen);

        Gui.DisplayedString = $"Score: {points}";
        Gui.Position = new Vector2f(12, 8);
        denLustigaSkärmen.Draw(Gui);

        Gui.DisplayedString = $"Health: {health}";
        Gui.Position = new Vector2f(windowWidth - 267, 8);
        denLustigaSkärmen.Draw(Gui);
    }


    static public void HiddenSlop()
    {
        int wait = 150;
        // slop dialogue
        Console.WriteLine("Hej kära spelare"); Console.ReadKey();
        Console.WriteLine("Jag är spelledaren av detta spel"); Console.ReadKey();
        Console.WriteLine("Jag har gjort spel i många år nu"); Thread.Sleep(wait);
        Console.WriteLine("Jag har även vunnit SM långfinger dragkamp"); Thread.Sleep(wait);
        Console.WriteLine("Och vet du vad?"); Thread.Sleep(wait);
        Console.WriteLine("Jag har även skapat en 1:1 kopia av Darth Vader av snorkråkor och öronvax i mitt gara..."); Thread.Sleep(300);
        Console.WriteLine("juste"); Thread.Sleep(wait);
        Console.WriteLine("Det är inte jag som är huvudpersonen av denna berättelse"); Thread.Sleep(wait);
        Console.WriteLine("Det är du som är den viktiga nu!"); Thread.Sleep(wait);
        Console.WriteLine("Vad är ditt namn?"); Thread.Sleep(wait);
        Console.Write("Skriv ditt namn här:"); Console.ReadKey();
        Console.WriteLine("Äsch strunta i det där"); Console.ReadKey();
        Console.WriteLine("Nu spelar vi Adolf Kirk OUT!!!!!11"); Console.ReadKey();
    }
}