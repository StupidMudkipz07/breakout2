class GameObjectHandler
{

    RenderWindow denLusitgaSkärmen;
    public List<GameObject> GameList = new();

    public void GibbGubb(float deltaTime)
    {
        for (int i = 0; i < GameList.Count; i++)
        {
            //först uppdatera alla värden
            GameList[i].Update(deltaTime);
            GameList[i].TheBigD(denLusitgaSkärmen); // sen ritar man ut allt till skärmen
        }

        // tar bort alla objekt efter man har itererat
        GameList.RemoveAll(obj => obj.remove == true);
    }

    public GameObjectHandler(RenderWindow r)
    {
        denLusitgaSkärmen = r;
    }
}