using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.InitSceneStart)]
	public class InitSceneStart_InitConfig : AEvent
	{
		public override void Run()
		{
			ChessmanPool.instance.Init();
		}
	}
}
