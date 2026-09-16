class BreakOutGame
{
    public int points = 0;
    public int health = 3;
    GameObjectHandler gameObjectHandler;
    Ball boll;
    Paddle paddel;
    Text Gui;
    public RenderWindow denLustigaSkärmen;

    public BreakOutGame(RenderWindow window)
    {
        denLustigaSkärmen = window;
        gameObjectHandler = new();
        boll = new(gameObjectHandler);
        paddel = new(gameObjectHandler);
        Gui = new Text
        {
            CharacterSize = 24,
            Font = new Font("assets/future.ttf")
        };
    }

    public void Update(float deltaTime)
    {
        gameObjectHandler.GibbGubb(deltaTime);
    }

    public void Draw()
    {
        gameObjectHandler.Draw(denLustigaSkärmen);
        
        Gui.DisplayedString = $"Health: {health}";
        Gui.Position = new Vector2f(12, 8);
        Gui.DisplayedString = $"Score: {points}";
        Gui.Position = new Vector2f(12, 8);
    }

}