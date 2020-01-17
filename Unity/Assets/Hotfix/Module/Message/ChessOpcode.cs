using ETModel;
namespace ETHotfix
{
	[Message(ChessOpcode.ChessmanInfo)]
	public partial class ChessmanInfo {}

	[Message(ChessOpcode.C2M_DealCards)]
	public partial class C2M_DealCards : IRequest {}

	[Message(ChessOpcode.M2C_DealCards)]
	public partial class M2C_DealCards : IResponse {}

	[Message(ChessOpcode.M2C_BroadcastDealCard)]
	public partial class M2C_BroadcastDealCard : IActorMessage {}

	[Message(ChessOpcode.C2M_SellCard)]
	public partial class C2M_SellCard : IRequest {}

	[Message(ChessOpcode.M2C_SellCard)]
	public partial class M2C_SellCard : IResponse {}

	[Message(ChessOpcode.C2M_AddExp)]
	public partial class C2M_AddExp : IRequest {}

	[Message(ChessOpcode.M2C_AddExp)]
	public partial class M2C_AddExp : IResponse {}

	[Message(ChessOpcode.AddGold)]
	public partial class AddGold {}

//加金币
	[Message(ChessOpcode.M2C_BroadcastAddGold)]
	public partial class M2C_BroadcastAddGold : IActorMessage {}

}
namespace ETHotfix
{
	public static partial class ChessOpcode
	{
		 public const ushort ChessmanInfo = 20001;
		 public const ushort C2M_DealCards = 20002;
		 public const ushort M2C_DealCards = 20003;
		 public const ushort M2C_BroadcastDealCard = 20004;
		 public const ushort C2M_SellCard = 20005;
		 public const ushort M2C_SellCard = 20006;
		 public const ushort C2M_AddExp = 20007;
		 public const ushort M2C_AddExp = 20008;
		 public const ushort AddGold = 20009;
		 public const ushort M2C_BroadcastAddGold = 20010;
	}
}
