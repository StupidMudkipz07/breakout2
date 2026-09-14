class Ball : IDrawable
{
    public Sprite sprite;


    public void Update(float deltaTime)
    {

    }


    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }

    public Ball()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
    }
}