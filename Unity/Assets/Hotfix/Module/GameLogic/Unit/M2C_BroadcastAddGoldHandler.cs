
using ETModel;
namespace ETHotfix
{
	[MessageHandler]
	public class M2C_BroadcastAddGoldHandler : AMHandler<M2C_BroadcastAddGold>
	{
		protected override async ETTask Run(ETModel.Session session, M2C_BroadcastAddGold message)
		{
			UnitComponent unitComponent = ETModel.Game.Scene.GetComponent<UnitComponent>();
            foreach (AddGold gold in message.Golds)
            {
				Unit unit = unitComponent.Get(gold.Id);
				unit.Gold = gold.Gold;
			}

			await ETTask.CompletedTask;
		}
	}
}