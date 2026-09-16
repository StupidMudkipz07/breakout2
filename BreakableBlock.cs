class BreakableBlock : GameObject, ICollidable
{

    public BreakableBlock(Vector2f size, Vector2f startPos, string colorStartWithUpperCase, GameObjectHandler h) : base(h)
    {
        this.size = size;
        pos = startPos;
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