class Ball : GameObject
{
    public Sprite sprite;



    public Ball(GameObjectHandler h) : base(h)
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
        pos = new(200, 200);
        size = new(200, 200);
    }

    public override void Update(float deltaTime)
    {
        Vector2f direction = new Vector2f(0, 0);
        direction = new(1,1);


        pos += direction * 500 * deltaTime;
    }

    public override void TheBigD(RenderTarget target)
    {
        sprite.Position = pos;
        //orka fixa sprite grejer Det kan du göra arvid
        target.Draw(sprite);
    }


}