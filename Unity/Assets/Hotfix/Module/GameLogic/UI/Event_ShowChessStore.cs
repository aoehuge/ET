using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.ShowChessStore)]
	public class Event_ShowChessStore : AEvent
	{
		public override void Run()
		{
			FUI ui = UIFactory.CreateFUI(FUIType.UIChessStore);
			ui.AddComponent<FUIChessStoreComponent>();
			Game.Scene.GetComponent<FUIComponent>().Add(ui);
		}
	}
}