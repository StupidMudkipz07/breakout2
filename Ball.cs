class Ball : GameObject, IMovable, ICollidable
{
   
    float speed = 100;
    const float radius = 25;
    const float diamiter = radius * 2;

    public GameObjectHandler gibbObjectHandler;

    public Ball(GameObjectHandler h) : base(h)
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/ball.png");
        sprite.Position = new Vector2f(250, 300);
        pos = new(800, 800);
        gibbObjectHandler = h;

        sprite.Origin = (Vector2f)(sprite.Texture.Size / 2);  
        sprite.Scale = new Vector2f(diamiter / sprite.Texture.Size.X, diamiter / sprite.Texture.Size.Y);
    }

    public override void Update(float deltaTime)
    {
        Vector2f direction = new(250, -250);
        //direction.Normalized();
        
        foreach (GameObject gibbObject in gibbObjectHandler.GameList)
        {
            if (gibbObject.sprite == sprite)
                continue;

            if (Collision.CircleRectangle(pos, radius, gibbObject.Position, gibbObject.Size, out Vector2f hitPos))
            {
                pos += hitPos;
                
                direction = Reflect(hitPos.Normalized(), direction);

            }    
        }

        ((IMovable)this).MoveObject(ref pos, ((IMovable)this).CalculateMoveVector(direction, speed * deltaTime));
    }

    public Vector2f Reflect(Vector2f normalizedVector, Vector2f direction) 
    {
        return direction -= normalizedVector * (2 * (direction.X * normalizedVector.X + direction.Y * normalizedVector.Y));
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