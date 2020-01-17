using System.Collections.Generic;
using System.Linq;

namespace ETModel
{
	[ObjectSystem]
	public class ChesserComponentAwakeSystem : AwakeSystem<ChesserComponent>
	{
		public override void Awake(ChesserComponent self)
		{
			self.Awake();
		}
	}

	public class ChesserComponent : Entity
	{
		public static ChesserComponent Instance { get; private set; }

		private Chesser myChesser;

		public Chesser MyChesser
		{
			get
			{
				return this.myChesser;
			}
			set
			{
				this.myChesser = value;
				this.myChesser.Parent = this;
			}
		}

		private readonly Dictionary<long, Chesser> idChessers = new Dictionary<long, Chesser>();

		public void Awake()
		{
			Instance = this;
		}

		public void Add(Chesser chesser)
		{
			this.idChessers.Add(chesser.Id, chesser);
			chesser.Parent = this;
        }

		public Chesser Get(long id)
		{
            this.idChessers.TryGetValue(id, out Chesser chesser);
            return chesser;
        }

		public void Remove(long id)
		{
			this.idChessers.Remove(id);
        }

        public int Count
		{
			get
			{
				return this.idChessers.Count;
            }
        }

		public Chesser[] GetAll()
		{
			return this.idChessers.Values.ToArray();
        }

		public override void Dispose()
		{
            if (this.IsDisposed)
            {
				return;
            }
			base.Dispose();

            foreach (Chesser chesser in this.idChessers.Values)
            {
				chesser.Dispose();
            }
			Instance = null;
        }
	}
}