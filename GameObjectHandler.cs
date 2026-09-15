class GameObjectHandler
{

    RenderWindow denLustigaSkärmen;
    public List<GameObject> GameList = new();

    public void GibbGubb(float deltaTime)
    {
        for (int i = 0; i < GameList.Count; i++)
        {
            //först uppdatera alla värden
            GameList[i].Update(deltaTime);
            GameList[i].TheBigD(denLustigaSkärmen); // sen ritar man ut allt till skärmen
        }

        // tar bort alla objekt efter man har itererat så inte listan förstörs
        GameList.RemoveAll(obj => obj.remove == true);
    }

    public GameObjectHandler(RenderWindow r)
    {
        denLustigaSkärmen = r;
    }
}