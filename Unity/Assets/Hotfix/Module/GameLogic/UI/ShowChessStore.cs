using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.ShowChessStore)]
	public class ShowChessStore : AEvent
	{
		public override void Run()
		{
			UI ui = UIFactory.Create(UIType.UIChessStore);
			ui.AddComponent<UIChessStoreComponent>();
			Game.Scene.GetComponent<UIComponent>().Add(ui);
		}
	}
}