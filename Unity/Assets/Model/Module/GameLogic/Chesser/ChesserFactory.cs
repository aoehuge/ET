namespace ETModel
{
    public static class ChesserFactory
    {
        public static Chesser Create(Entity domain, long id)
        {
            Chesser chesser = EntityFactory.CreateWithId<Chesser>(domain, id);
            ChesserComponent playerComponent = Game.Scene.GetComponent<ChesserComponent>();
            playerComponent.Add(chesser);
            return chesser;
        }
    }
}