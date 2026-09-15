class Ball : IDrawable
{
    public Sprite sprite;
    Vector2f position = new(600, 900);
    Vector2f size = new(220, 53);

    public void Update(float deltaTime)
    {

    }

    public void Draw(RenderTarget target)
    {
        
        sprite.Position = position;
        target.Draw(sprite);
    }

    public Ball()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
    }
}