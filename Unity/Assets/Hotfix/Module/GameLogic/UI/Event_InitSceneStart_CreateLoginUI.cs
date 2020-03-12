using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.InitSceneStart)]
	public class Event_InitSceneStart_CreateLoginUI : AEvent
	{
		public override void Run()
		{
			FUI fUI = UIFactory.CreateFUI(FUIType.UILogin);
			fUI.AddComponent<UILobbyComponent>();
			Game.Scene.GetComponent<FUIComponent>().Add(fUI);
		}
	}
}
