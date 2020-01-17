using System.Collections.Generic;
using System.Linq;

namespace ETModel
{
	[ObjectSystem]
	public class PetComponentSystem : AwakeSystem<PetComponent>
	{
		public override void Awake(PetComponent self)
		{
			self.Awake();
		}
	}

	public class PetComponent : Entity
	{
		public static PetComponent Instance { get; private set; }

		public Pet MyPet;

		private readonly Dictionary<long, Pet> idPets = new Dictionary<long, Pet>();

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

			foreach (Pet pet in this.idPets.Values)
			{
				pet.Dispose();
			}

			this.idPets.Clear();

			Instance = null;
		}

		public void Add(Pet pet)
		{
			this.idPets.Add(pet.Id, pet);
			pet.Parent = this;
		}

		public Pet Get(long id)
		{
			Pet unit;
			this.idPets.TryGetValue(id, out unit);
			return unit;
		}

		public void Remove(long id)
		{
			Pet pet;
			this.idPets.TryGetValue(id, out pet);
			this.idPets.Remove(id);
			pet?.Dispose();
		}

		public void RemoveNoDispose(long id)
		{
			this.idPets.Remove(id);
		}

		public int Count
		{
			get
			{
				return this.idPets.Count;
			}
		}

		public Pet[] GetAll()
		{
			return this.idPets.Values.ToArray();
		}
	}
}