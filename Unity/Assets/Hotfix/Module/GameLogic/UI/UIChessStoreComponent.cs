using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    [ObjectSystem]
	public class UIChessStoreComponentSystem : AwakeSystem<UIChessStoreComponent>
	{
		public override void Awake(UIChessStoreComponent self)
		{
			self.Awake();
		}
	}
	
	public class UIChessStoreComponent: Entity
	{
		private GameObject refreshBtn;
		private GameObject uplevelBtn;
		private GameObject sellBtn;

		private GameObject goldText;

		private readonly List<long> showList = new List<long>();

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().ViewGO.GetComponent<ReferenceCollector>();
			refreshBtn = rc.Get<GameObject>("RefreshBtn");
			uplevelBtn = rc.Get<GameObject>("UplevelBtn");
			sellBtn = rc.Get<GameObject>("SellBtn");
			goldText = rc.Get<GameObject>("GoldText");

			refreshBtn.GetComponent<Button>().onClick.Add(OnRefresh);
			uplevelBtn.GetComponent<Button>().onClick.Add(OnAddExp);
			sellBtn.GetComponent<Button>().onClick.Add(OnSell);
			goldText.GetComponent<Text>().text = "";
        }

		public void SetGoldText(int gold)
		{
			goldText.GetComponent<Text>().text = Convert.ToString(gold);
        }

		private void OnRefresh()
		{
			this.RefreshChessPanel().Coroutine();
		}

		private void OnSell( )
		{
			this.SellChessman(1).Coroutine();
		}

		private void OnAddExp()
		{
			this.AddExp().Coroutine();
		}


		public void ReloadChess(ChessmanInfo[] chessmanInfos)
		{
            foreach (ChessmanInfo chessmanInfo in chessmanInfos)
            {
				this.showList.Add(chessmanInfo.ChessmanId);
            }
        }
	}
}
