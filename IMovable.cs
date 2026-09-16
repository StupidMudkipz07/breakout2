interface IMovable
{
    public Vector2f CalculateMoveVector(Vector2f direction, float velocity)
    {
        direction = Collision.Normalized(direction);
        return direction * velocity;
    }

    public void MoveObject(ref Vector2f pos, Vector2f vectorToApply)
    {
        pos += vectorToApply;
        //add collision script here: maybe not
    }
}