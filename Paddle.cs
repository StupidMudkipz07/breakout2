class Paddle : GameObject, IMovable, ICollidable
{
    float paddleMoveSpeed;
    public Paddle(int height, int moveSpeed, GameObjectHandler h) : base(h)
    {
        size = new(220, 53);
        pos = new(BreakOutGame.windowWidth / 2, height);
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/paddle.png");
        sprite.Position = pos;
        paddleMoveSpeed = moveSpeed;

        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
    }

    public void OnCollide(ICollidable collidable)
    {

    }

    public override void Update(float deltaTime)
    {
        Vector2f direction = new Vector2f(0, 0);

        if (KeyboardHandler.IsKeyDown(Keyboard.Key.A))
            direction.X -= 1;
        if (KeyboardHandler.IsKeyDown(Keyboard.Key.D))
            direction.X += 1;

        ((IMovable)this).MoveObject(ref pos, direction * paddleMoveSpeed * deltaTime);

        pos.X = Math.Clamp(pos.X, 0, BreakOutGame.windowWidth);
    }

    public override void TheBigD(RenderTarget targetWindow)
    {
        sprite.Position = pos;
        //orka fixa sprite grejer Det kan du göra arvid
        targetWindow.Draw(sprite);
    }
}