class Block : GameObject, ICollidable
{
    public Block(GameObjectHandler h) : base(h)
    {
        size = new(100, 50);
        pos = new(300, 200);
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/tileGreen.png");
        sprite.Position = pos;
        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
    }

    public override void Update(float deltaTime)
    {

    }

    public void OnCollide(ICollidable collidable)
    {

    }

    public override void TheBigD(RenderTarget target)
    {
        sprite.Position = pos;
        target.Draw(sprite);
    }
}