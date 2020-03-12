
using ETModel;
namespace ETHotfix
{
	[MessageHandler]
	public class M2C_BroadcastAddGoldHandler : AMHandler<M2C_BroadcastAddGold>
	{
		protected override async ETTask Run(ETModel.Session session, M2C_BroadcastAddGold message)
		{
			ChesserComponent chesserComponent = ETModel.Game.Scene.GetComponent<ChesserComponent>();
            foreach (AddGold gold in message.Golds)
            {
				Chesser chesser = chesserComponent.Get(gold.Id);
				chesser.Gold = gold.Gold;
			}

			await ETTask.CompletedTask;
		}
	}
}