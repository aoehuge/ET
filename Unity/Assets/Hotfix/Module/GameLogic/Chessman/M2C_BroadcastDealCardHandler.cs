using ETModel;
namespace ETHotfix
{
	[MessageHandler]
	public class M2C_BroadcastDealCardHandler : AMHandler<M2C_BroadcastDealCard>
	{
		protected override async ETTask Run(ETModel.Session session, M2C_BroadcastDealCard message)
		{
			Unit unit = ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.Id);
			ChessmanComponent chessmanComponent = unit.GetComponent<ChessmanComponent>();
			Chessman chessman = ChessmanPool.instance.Get(message.Chessman.ChessmanId);
			chessmanComponent.Add(chessman);
			
			await ETTask.CompletedTask;
		}
	}
}
