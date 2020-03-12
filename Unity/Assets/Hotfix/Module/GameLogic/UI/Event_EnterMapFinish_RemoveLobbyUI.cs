using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.EnterMapFinish)]
	public class Event_EnterMapFinish_RemoveLobbyUI : AEvent
	{
		public override void Run()
		{
			Game.Scene.GetComponent<FUIComponent>().Remove(FUIType.UILobby);
			ETModel.Game.Scene.GetComponent<FUIPackageComponent>().RemovePackage(FUIType.UILobby);
		}
	}
}
