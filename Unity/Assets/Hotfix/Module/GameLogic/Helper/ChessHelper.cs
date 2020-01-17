using ETModel;
namespace ETHotfix
{
    public static class ChessHelper
    {
        public static async ETVoid RefreshChessPanel(this UIChessStoreComponent uIChessStoreComponent)
        {
            M2C_DealCards m2C_DealCards = (M2C_DealCards)await SessionComponent.Instance.Session.Call(new C2M_DealCards());

            uIChessStoreComponent.ReloadChess(m2C_DealCards.Chessmans.array);
        }

        public static async ETVoid SellChessman(this UIChessStoreComponent uIChessStoreComponent, long chessmanId)
        {
            M2C_SellCard m2C_DealCards = (M2C_SellCard)await SessionComponent.Instance.Session.Call(new C2M_SellCard() { ChessmanId = chessmanId });
            //uIChessStoreComponent.ReloadChess();
        }

        public static async ETVoid AddExp(this UIChessStoreComponent uIChessStoreComponent)
        {
            M2C_AddExp m2C_DealCards = (M2C_AddExp)await SessionComponent.Instance.Session.Call(new C2M_AddExp());
            //uIChessStoreComponent.ReloadChess();
        }
    }
}
