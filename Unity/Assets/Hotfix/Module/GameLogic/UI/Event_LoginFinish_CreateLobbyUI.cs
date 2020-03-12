using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.LoginFinish)]
	public class Event_LoginFinish_CreateLobbyUI : AEvent
	{
		public override void Run()
		{
			FUI fUI = UIFactory.CreateFUI(FUIType.UILobby);
			Game.Scene.GetComponent<FUIComponent>().Add(fUI);
		}
	}
}
