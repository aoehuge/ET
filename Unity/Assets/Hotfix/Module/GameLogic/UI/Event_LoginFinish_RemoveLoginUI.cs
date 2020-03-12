using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.LoginFinish)]
	public class Event_LoginFinish_RemoveLoginUI : AEvent
	{
		public override void Run()
		{
			Game.Scene.GetComponent<FUIComponent>().Remove(FUIType.UILogin);
			ETModel.Game.Scene.GetComponent<FUIPackageComponent>().RemovePackage(FUIType.UILogin);
		}
	}
}
