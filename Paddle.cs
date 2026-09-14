 class Paddle : IDrawable
{
    public Sprite sprite;
    Vector2f position = new(600, 900);
    Vector2f size = new(220, 53);

    RectangleShape rectangle = new();

    public Paddle()
    {
        rectangle = new() { Size = size, FillColor = Color.Red, Position = position, };
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/paddle.png");
        sprite.Position = position;
    }

    public void Update(float deltaTime)
    {
        Vector2f direction = new Vector2f(0, 0);

        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            direction.X -= 1;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            direction.X += 1;

        position += direction * 500 * deltaTime;

        position.X = Math.Clamp(position.X, 0, 1760 - size.X);
    }

    public void Draw(RenderTarget targetWindow)
    {
        sprite.Position = position;
        rectangle.Position = position;
        //orka fixa sprite grejer Det kan du göra arvid
        //sprite.Texture.Size = size;
        //targetWindow.Draw(sprite);
        targetWindow.Draw(rectangle);
    }
}