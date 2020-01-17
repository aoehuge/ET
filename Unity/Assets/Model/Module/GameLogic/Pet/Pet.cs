using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ETModel
{
    [ObjectSystem]
	public class PetAwakeSystem : AwakeSystem<Pet, GameObject>
	{
		public override void Awake(Pet self, GameObject gameObject)
		{
			self.Awake(gameObject);
		}
	}

	[HideInHierarchy]
	public sealed class Pet : Entity
	{
		public void Awake(GameObject gameObject)
		{
			this.ViewGO = gameObject;
			this.ViewGO.AddComponent<ComponentView>().Component = this;
		}


		public Vector3 Position
		{
			get
			{
				return ViewGO.transform.position;
			}
			set
			{
				ViewGO.transform.position = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return ViewGO.transform.rotation;
			}
			set
			{
				ViewGO.transform.rotation = value;
			}
		}

		public Vector3 Scale
		{
			get
			{
				return ViewGO.transform.localScale;
			}
			set
			{
				ViewGO.transform.localScale = value;
			}
		}

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