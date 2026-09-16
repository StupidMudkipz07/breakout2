class Ball : GameObject, IMovable, ICollidable
{
    public Sprite sprite;

    float speed = 500;

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

        Vector2f direction = new(500, 1);

        ((IMovable)this).MoveObject(ref pos, ((IMovable)this).CalculateMoveVector(direction, speed * deltaTime));
    }

    public void OnCollide(ICollidable collidable)
    {

    }

    public override void TheBigD(RenderTarget target)
    {
        sprite.Position = pos;
        //orka fixa sprite grejer Det kan du göra arvid
        target.Draw(sprite);
    }


}