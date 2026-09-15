class Ball : GameObject
{
    public Sprite sprite;
    Vector2f position = new(600, 900);
    Vector2f size = new(220, 53);

    public Ball(GameObjectHandler h) : base(h)
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
    }
    
    public override void Update(float deltaTime)
    {

    }

    public override void TheBigD(RenderTarget target)
    {
        target.Draw(sprite);
    }


}