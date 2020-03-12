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
			ChesserComponent ChesserComponent = ETModel.Game.Scene.GetComponent<ChesserComponent>();

            if (ChesserComponent.MyChesser.Id == id)  //本人金币变化
            {
				FUIComponent fUIComponent = Game.Scene.GetComponent<FUIComponent>();
				FUI ui = fUIComponent.Get(FUIType.UIChessStore);
				FUI goldText = ui.GetComponent<FUIChessStoreComponent>().GoldText;
				goldText.Get("gold").GObject.asLabel.text = string.Format("%d",value);
			}
		}
	}
}
