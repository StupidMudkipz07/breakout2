class BreakOutGame
{
    static public int windowWidth = 1920;
    static public int windowHeight = 1080;

    static public int playWidth = 900;
    static public int playHeight = 1020;

    public int points = 0;
    public int health = 3;
    GameObjectHandler handler;
    Ball boll;
    Paddle paddel;
    Text Gui;
    //List<Block> blocks = new();
    Block[] boundaries = new Block[4];
    List<BreakableBlock> tiles = new();
    public RenderWindow denLustigaSkärmen;

    void MakeBoundaries(int PlayWidth, int playHeight)
    {
        //math
        int mcnuttWidth = (windowWidth - PlayWidth) / 2;
        int mcnuttHeight = windowHeight - playHeight;

        boundaries[0] = MakeBlock(new(0, 0), new(mcnuttWidth, windowHeight), "");
        boundaries[1] = MakeBlock(new(windowWidth - mcnuttWidth, 0), new(mcnuttWidth, windowHeight), "assets/binding.png");
        boundaries[2] = MakeBlock(new(mcnuttWidth, 0), new(windowWidth - (mcnuttWidth * 2), mcnuttHeight), "assets/math.png");
        //boundaries[3] = MakeBlock(new(mcnuttWidth, windowHeight - 40), new(windowWidth - (mcnuttWidth * 2), 40));
    }

    Vector2f OriginOffset(Vector2f desiredPos, Vector2f size)
    {
        return desiredPos + (size / 2);
    }

    Block MakeBlock(Vector2f pos, Vector2f size) => new(size, OriginOffset(pos, size), "", handler);

    Block MakeBlock(Vector2f pos, Vector2f size, string sprite) => new(size, OriginOffset(pos, size), sprite, handler);

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
        Gui.Position = new Vector2f(windowWidth - 267, 8);
        denLustigaSkärmen.Draw(Gui);
    }

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        handler = new();

        boll = new(new(windowWidth / 2, playHeight / 2), handler);

        //när bollen når utanför skärmen så kallas detta event
        boll.BallLeftScreen += (_, _) =>
        {
            health--;
            boll.Reset();
        };


        MakeBoundaries(900, 1020);
        paddel = new(windowHeight - 140, handler);
        Gui = new Text
        {
            CharacterSize = 45,
            Font = new Font("assets/future.ttf")
        };
    }
}