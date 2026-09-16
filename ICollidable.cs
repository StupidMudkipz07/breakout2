interface ICollidable
{
    public static List<ICollidable> list = new();

    public static void CheckCollisions()
    {
        foreach (ICollidable i in list)
        {
            //if i.checkCollion stuff
            //i.OnCollide();
        }
    }

    

    public void OnCollide(ICollidable collidable);
}