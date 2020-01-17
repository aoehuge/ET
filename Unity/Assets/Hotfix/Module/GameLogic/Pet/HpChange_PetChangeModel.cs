using ETModel;
namespace ETHotfix
{
    [Event("HpChange")]
    public class HpChange_PetChangeModel:AEvent<long,int,int>
    {
        public override void Run(long id, int lastHp, int curHp)
        {
            Pet pet = ETModel.Game.Scene.GetComponent<PetComponent>().Get(id);
            pet.Scale = pet.Scale * curHp / lastHp;
        }
    }
}
