namespace ETModel
{
	public sealed class Chesser : Entity
	{
		public long ChesserId { get; set; }

		public int Gold { get; set; }


		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}