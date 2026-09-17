class Ball : GameObject, IMovable, ICollidable
{
    float speed = 500;
    const float radius = 25;
    const float diameter = radius * 2;
    Vector2f startPos = new();
    Vector2f direction = new(-67, 67);
    GameObjectHandler gibbObjectHandler;
    Paddle paadel;
    bool IsNotAdolf = false;

    public event EventHandler BallLeftScreen;

    public Ball(Vector2f startPos, Paddle paddle, GameObjectHandler h) : base(h)
    {
        this.startPos = startPos;
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
        gibbObjectHandler = h;
        direction = RandomDirection();
        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(diameter / sprite.Texture.Size.X, diameter / sprite.Texture.Size.Y);
        paadel = paddle;
        Reset();
    }

    public void Reset()
    {
        //put on paddle maybe 
        pos = startPos;
        direction = RandomDirection();
        pos = new Vector2f(paadel.Position.X, paadel.Position.Y - 75);
    }

    Vector2f RandomDirection()
    {
        Random rnd = new();
        int angle = rnd.Next(0, 180);
        //Maybe guarantee that ball goes downwards?
        Vector2f slop = new((float)Math.Cos(angle), (float)Math.Sin(angle));
        return slop;
    }

    Vector2f Reflect(Vector2f normalizedVector, Vector2f direction) => direction -= normalizedVector * (2 * (direction.X * normalizedVector.X + direction.Y * normalizedVector.Y));

    public override void Update(float deltaTime)
    {
        if (!IsNotAdolf)
        {
            Reset();

            if (KeyboardHandler.WasKeyJustDown(Keyboard.Key.Space))
            {
                IsNotAdolf = true;
            }
        }

        foreach (GameObject gibbObject in gibbObjectHandler.GameList)
        {
            if (gibbObject.sprite == sprite)
                continue; //skip its own sprite

            if (Collision.CircleRectangle(pos, radius, gibbObject.Position, gibbObject.Size, out Vector2f hitPos))
            {
                pos += hitPos;
                direction = Reflect(hitPos.Normalized(), direction);

                if (gibbObject is BreakableBlock)
                {
                    BreakableBlock b = gibbObject as BreakableBlock;
                    b.BigDieOOOOOOOOof();
                }
            }
        }
        ((IMovable)this).MoveObject(ref pos, ((IMovable)this).CalculateMoveVector(direction, speed * deltaTime));

        if (pos.Y > BreakOutGame.windowHeight + radius)
        {
            BallLeftScreen.Invoke(this, EventArgs.Empty);
            IsNotAdolf = false;
        }
    }

    public void OnCollide(ICollidable collidable) { }

    public override void TheBigD(RenderTarget target)
    {
        sprite.Position = pos;
        //orka fixa sprite grejer Det kan du göra arvid
        target.Draw(sprite);
    }
}