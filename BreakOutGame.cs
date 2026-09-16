class BreakOutGame
{
    static public int windowWidth = 1920;
    static public int windowHeight = 1080;

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

        boundaries[0] = MakeBlock(new(0, 0), new(mcnuttWidth, windowHeight));

        boundaries[1] = MakeBlock(new(windowWidth - mcnuttWidth, 0), new(mcnuttWidth, windowHeight));

        boundaries[2] = MakeBlock(new(mcnuttWidth, 0), new(windowWidth - (mcnuttWidth * 2), 40));

        //boundaries[3] = MakeBlock(new(mcnuttWidth, windowHeight - 40), new(windowWidth - (mcnuttWidth * 2), 40));
    }

    Vector2f OriginOffset(Vector2f desiredPos, Vector2f size)
    {
        return desiredPos + (size / 2);
    }

    Block MakeBlock(Vector2f pos, Vector2f size) => new(size, OriginOffset(pos, size), "", handler);

    Block MakeBlock(Vector2f pos, Vector2f size, string sprite) => new(size, OriginOffset(pos, size), sprite, handler);

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        handler = new();

        boll = new(handler);

        MakeBoundaries();
        paddel = new(windowHeight - 140, handler);
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