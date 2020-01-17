using ETModel;
namespace ETHotfix
{
	[Config((int)(AppType.ClientH | AppType.ClientM | AppType.Map))]
	public partial class ChessmanConfigCategory : ACategory<ChessmanConfig>
	{
	}

	public class ChessmanConfig : IConfig
	{
		public long Id { get; set; }
		public string Name;
		public string Desc;
		public int Star;
		public int FirstProperty;
		public int SecondProperty;
	}
}