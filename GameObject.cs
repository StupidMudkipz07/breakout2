abstract class GameObject
{

    public Sprite sprite;
    public bool remove;

    protected Vector2f pos = new();
    protected Vector2f size = new();

    public Vector2f Position => pos;
    public Vector2f Size => size;

    abstract public void Update(float deltaTime);
    abstract public void TheBigD(RenderTarget targetWindow);

    public GameObject(GameObjectHandler h)
    {
        h.GameList.Add(this);
    }
}