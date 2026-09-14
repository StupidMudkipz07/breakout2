interface IMovable
{
    protected void Move(Vector2f position, Vector2f velocity)
    {
        position += velocity;
    }
}