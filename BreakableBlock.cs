class BreakableBlock : Block, ICollidable
{
    public event EventHandler BlockBreaked;

    public BreakableBlock(Vector2f size, Vector2f startPos, string colorStartWithUpperCase, GameObjectHandler h) : base(size, startPos, "", h)
    {
        sprite = new Sprite();

        if (colorStartWithUpperCase == "Blue" || colorStartWithUpperCase == "Green" || colorStartWithUpperCase == "Pink")
        {
            string filePath = "assets/tile" + colorStartWithUpperCase + ".png";
            sprite.Texture = new Texture(filePath);
        }
        else sprite.Texture = new Texture("assets/tileBlue.png");

        sprite.Position = pos;
        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
    }

    public void BigDieOOOOOOOOof()
    {
        remove = true;
        BlockBreaked.Invoke(this, EventArgs.Empty);
    }

    public override void Update(float deltaTime)
    {
        roligaGrejerAttGöra();
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