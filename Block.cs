class Block : GameObject, ICollidable
{
    protected Random rnd = new();
    protected int countDown;
    protected int coolDown() => (600 + rnd.Next(-67, +67)) * rnd.Next(1, 5);
    public Action roligaGrejerAttGöra = () => { };

    public Block(Vector2f size, Vector2f startPos, string spriteFilePath, GameObjectHandler h) : base(h)
    {

        this.size = size;
        pos = startPos;
        sprite = new Sprite();

        if (spriteFilePath == "") sprite.Texture = new Texture("assets/tileBlue.png"); else sprite.Texture = new Texture(spriteFilePath);
        sprite.Position = pos;
        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);
        sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
        countDown = coolDown();
    }

    public override void Update(float deltaTime)
    {
        roligaGrejerAttGöra();
        //ChangeSpriteOnCooldown();
    }

    public void ChangeSpriteOnCooldown()
    {
        countDown--;
        if (countDown == 0)
        {
            ChangeSprite();
            countDown = coolDown();
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

    public void SpawnSlopWindow()
    {
        // din using grej hade varit bra här
        Sprite slop = new();
        slop.Texture = sprite.Texture;
        Vector2f windowSize = new(slop.Texture.Size.X, slop.Texture.Size.Y);
        RenderWindow window = new(new VideoMode((uint)windowSize.X, (uint)windowSize.Y), "Slop");
        window.Closed += (sender, e) => window.Close();
        window.DispatchEvents();
        window.Clear(Color.Black);

        window.Draw(slop);
        window.Display();
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