namespace ETModel
{
    [Config((int)(AppType.ClientH | AppType.ClientM | AppType.Map))]
	public partial class LevelConfigCategory : ACategory<LevelConfig>
	{

	}

	public class LevelConfig : IConfig
	{
		public long Id { get; set; }
		public int Level;
		public int Exp;
		public int OneStarPer;
		public int TwoStarPer;
		public int ThreeStarPer;
		public int FourStarPer;
		public int FiveStarPer;
	}
}