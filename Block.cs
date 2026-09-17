class Block : GameObject, ICollidable
{
    Random rnd = new();
    int countDown;

    public Block(Vector2f size, Vector2f startPos, string spriteFilePath, GameObjectHandler h) : base(h)
    {

        this.size = size;
        pos = startPos;
        sprite = new Sprite();
        if (spriteFilePath == "") sprite.Texture = new Texture("assets/mcnutt.png"); else sprite.Texture = new Texture(spriteFilePath);
        sprite.Position = pos;
        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
        countDown = 600 * rnd.Next(1, 5);
    }

    public override void Update(float deltaTime)
    {
        DoThingOnCooldown(ref countDown, countDown = 600 * rnd.Next(1, 5), ChangeSprite);
    }

    protected void DoThingOnCooldown(ref int timer, int cool, Action function)
    {
        countDown--;
        if (countDown == 0)
        {
            function();
            timer = cool;
        }
    }

    protected void ChangeSprite()
    {
        string filePath = "assets/";
        int slop = rnd.Next(0, 10);
        switch (slop)
        {
            case 0:
                filePath += "adolf kirk.png";
                break;
            case 1:
                filePath += "binding.png";
                break;
            case 2:
                filePath += "mcnutt.png";
                break;
            case 3:
                filePath += "zamn.png";
                break;
            case 4:
                filePath += "math.png";
                break;
            case 5:
                filePath += "flower.png";
                break;
            case 6:
                filePath += "thumbnail.png";
                break;
            case 7:
                filePath += "trobbio.png";
                break;
            case 8:
                filePath += "allt.png";
                break;
            case 9:
                filePath += "gobba.png";
                break;
        }

        Sprite båt = new();
        båt.Texture = new Texture(filePath);
        båt.Position = pos;
        båt.Origin = (Vector2f)(båt.Texture.Size / 2);
        båt.Scale = new Vector2f(Size.X / båt.Texture.Size.X, Size.Y / båt.Texture.Size.Y);

        sprite = båt;
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