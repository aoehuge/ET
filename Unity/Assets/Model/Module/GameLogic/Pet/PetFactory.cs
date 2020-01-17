using UnityEngine;

namespace ETModel
{
    public static class PetFactory
    {
        public static Pet Create(Entity domain, long id)
        {
            ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");

            PetComponent petComponent = Game.Scene.GetComponent<PetComponent>();

            GameObject go = UnityEngine.Object.Instantiate(prefab);
            Pet pet = EntityFactory.CreateWithId<Pet, GameObject>(domain, id, go);

            pet.AddComponent<AnimatorComponent>();
            pet.AddComponent<MoveComponent>();
            pet.AddComponent<TurnComponent>();
            pet.AddComponent<UnitPathComponent>();
            pet.AddComponent<NumericComponent>();

            petComponent.Add(pet);
            return pet;
        }
    }
}