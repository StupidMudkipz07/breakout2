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
    Block blocks;
    public RenderWindow denLustigaSkärmen;

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        handler = new();
        boll = new(handler);
        paddel = new(handler);
        blocks = new(handler);
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