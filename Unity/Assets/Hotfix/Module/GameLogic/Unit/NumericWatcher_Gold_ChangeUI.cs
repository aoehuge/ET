using ETModel;
namespace ETHotfix
{
	/// <summary>
	/// 监视金币数值变化，改变金币
	/// </summary>
	[NumericWatcher(NumericType.Gold)]
	public class NumericWatcher_Gold_ChangeUI : INumericWatcher
	{
		public void Run(long id, int value)
		{
			UnitComponent unitComponent = ETModel.Game.Scene.GetComponent<UnitComponent>();

            if (unitComponent.MyUnit.Id == id)  //本人金币变化
            {
				UIComponent uIComponent = Game.Scene.GetComponent<UIComponent>();
				UI ui = uIComponent.Get(UIType.UIChessStore);
				ui.GetComponent<UIChessStoreComponent>()?.SetGoldText(value);
			}
		}
	}
}
