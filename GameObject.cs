abstract class GameObject
{


    abstract public void Update(float deltaTime);
    abstract public void TheBigD(RenderTarget targetWindow);

    public bool remove;

    Vector2f pos = new();
    Vector2f size = new();

    
    public GameObject(GameObjectHandler h)
    {
        h.GameList.Add(this);
    }
}