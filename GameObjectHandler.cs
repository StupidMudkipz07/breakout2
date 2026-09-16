class GameObjectHandler
{
    public List<GameObject> GameList = new();

    //updates all objects
    public void GibbGubb(float deltaTime)
    {
        for (int i = 0; i < GameList.Count; i++)
        {
            //först uppdatera alla värden
            GameList[i].Update(deltaTime);
        }

        // tar bort alla objekt efter man har itererat så inte listan förstörs
        GameList.RemoveAll(obj => obj.remove == true);
    }

    //draws all objects
    public void Draw(RenderWindow denLustigaSkärmen)
    {
        for (int i = 0; i < GameList.Count; i++)
        {
            GameList[i].TheBigD(denLustigaSkärmen); // sen ritar man ut allt till skärmen
        }
    }

    public GameObjectHandler()
    {
    
    }
}