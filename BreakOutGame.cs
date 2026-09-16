class BreakOutGame
{
    static public uint windowWidth = 1920;
    static public uint windowHeight = 1080;

    public int points = 0;
    public int health = 3;
    GameObjectHandler handler;
    Ball boll;
    Paddle paddel;
    Text Gui;
    //List<Block> blocks = new();
    Block[] boundaries = new Block[4];
    BreakableBlock block2;
    public RenderWindow denLustigaSkärmen;

    void MakeBoundaries()
    {
        //math


        uint mcnuttWidth = 500;


        // Vector2f siz = new(mcnuttWidth, windowHeight);
        // uint x = mcnuttWidth - mcnuttWidth / 2;
        // uint y = windowHeight - windowHeight / 2;


        Vector2f siz = new(mcnuttWidth, windowHeight);
        Vector2f pos = originOffset(new(0,0),siz);

        boundaries[0] = new(siz, pos, "", handler);

        // Vector2f siz2 = new(mcnuttWidth, windowHeight);
        // uint x2 = windowWidth - mcnuttWidth + (mcnuttWidth - mcnuttWidth / 2);
        // uint y2 = windowHeight - windowHeight / 2;

        Vector2f siz2 = new(mcnuttWidth, windowHeight);
        Vector2f pos2 = originOffset(new(windowWidth-mcnuttWidth,0),siz);

        boundaries[1] = new(siz2, pos2, "", handler);

        Vector2f siz3 = new(windowWidth - (mcnuttWidth * 2), 10);
        uint x3 = mcnuttWidth + (uint)siz3.X / 2;
        uint y3 = windowHeight - windowHeight / 2;

        boundaries[2] = new(siz3, new(x3, y3), "assets/tileGreen.png", handler);


    }

    Vector2f originOffset(Vector2f desiredPos, Vector2f size)
    {
        return desiredPos + (size / 2);
    }

    

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        handler = new();
        paddel = new(handler);
        boll = new(handler);

        MakeBoundaries();
        Gui = new Text
        {
            CharacterSize = 24,
            Font = new Font("assets/future.ttf")
        };
    }

    public void Update(float deltaTime)
    {
        handler.GibbGubb(deltaTime);
    }

    public void DrawStuff()
    {
        handler.Draw(denLustigaSkärmen);

        Gui.DisplayedString = $"Health: {health}";
        Gui.Position = new Vector2f(12, 8);
        denLustigaSkärmen.Draw(Gui);
        Gui.DisplayedString = $"Score: {points}";
        Gui.Position = new Vector2f(windowWidth - 170, 8);
        denLustigaSkärmen.Draw(Gui);
    }

}