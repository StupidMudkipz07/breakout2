class Paddle : GameObject
{
    public Sprite sprite;

    RectangleShape rectangle = new();

    public Paddle(GameObjectHandler h) : base(h)
    {
        rectangle = new() { Size = size, FillColor = Color.Red, Position = pos, };
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/paddle.png");
        sprite.Position = pos;
        size = new(220, 53);
        pos = new(600, 900);
    }

    public override void Update(float deltaTime)
    {
        Vector2f direction = new Vector2f(0, 0);

        if (KeyboardHandler.IsKeyDown(Keyboard.Key.A))
            direction.X -= 1;
        if (KeyboardHandler.IsKeyDown(Keyboard.Key.D))
            direction.X += 1;

        pos += direction * 500 * deltaTime;

        pos.X = Math.Clamp(pos.X, 0, 1760 - size.X);
    }

    public override void TheBigD(RenderTarget targetWindow)
    {
        sprite.Position = pos;
        rectangle.Position = pos;
        //orka fixa sprite grejer Det kan du göra arvid
        targetWindow.Draw(sprite);
        targetWindow.Draw(rectangle);
    }
}