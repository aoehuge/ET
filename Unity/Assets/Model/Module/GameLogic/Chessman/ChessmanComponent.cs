using System.Collections.Generic;
using System.Linq;

namespace ETModel
{
	[ObjectSystem]
	public class ChessmanComponentSystem : AwakeSystem<ChessmanComponent>
	{
		public override void Awake(ChessmanComponent self)
		{
			self.Awake();
		}
	}

	public class ChessmanComponent : Entity
	{
		public static ChessmanComponent Instance { get; private set; }

		private readonly Dictionary<long, Chessman> myChessmans = new Dictionary<long, Chessman>();

		public void Awake()
		{
			Instance = this;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			base.Dispose();

			foreach (Chessman unit in this.myChessmans.Values)
			{
				unit.Dispose();
			}

			this.myChessmans.Clear();

			Instance = null;
		}

		public void Add(Chessman unit)
		{
			this.myChessmans.Add(unit.Id, unit);
			unit.Parent = this;
		}

		public Chessman Get(long id)
		{
			Chessman unit;
			this.myChessmans.TryGetValue(id, out unit);
			return unit;
		}

		public void Remove(long id)
		{
			Chessman unit;
			this.myChessmans.TryGetValue(id, out unit);
			this.myChessmans.Remove(id);
			unit?.Dispose();
		}

		public void RemoveNoDispose(long id)
		{
			this.myChessmans.Remove(id);
		}

		public int Count
		{
			get
			{
				return this.myChessmans.Count;
			}
		}

		public Chessman[] GetAll()
		{
			return this.myChessmans.Values.ToArray();
		}
	}
}