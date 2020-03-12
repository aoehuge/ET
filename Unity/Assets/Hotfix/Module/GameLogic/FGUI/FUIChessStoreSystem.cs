using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class FUIChessStoreSystem : AwakeSystem<FUIChessStoreComponent>
    {

        private readonly List<long> showList = new List<long>();

        public override void Awake(FUIChessStoreComponent self)
        {
            FUI fUI = self.GetParent<FUI>();

            self.GoldText = fUI.Get("GoldText");

            fUI.Get("RefreshBtn").GObject.asButton.onClick.Add(() => OnRefresh(self));
            fUI.Get("UplevelBtn").GObject.asButton.onClick.Add(() => OnAddExp(self));
            fUI.Get("SellBtn").GObject.asButton.onClick.Add(() => OnSell(self));

        }

        public static void OnRefresh(FUIChessStoreComponent self)
        {
            self.RefreshChessPanel().Coroutine();
        }

        public static void OnAddExp(FUIChessStoreComponent self)
        {
            self.SellChessman(1).Coroutine();
        }

        public static void OnSell(FUIChessStoreComponent self)
        {
            self.AddExp().Coroutine();
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