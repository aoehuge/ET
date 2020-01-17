using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
	public static class UIFactory
	{
		public static UI Create(string uiType)
		{
			try
			{
				ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
				resourcesComponent.LoadBundle(uiType.StringToAB());
				GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(uiType.StringToAB(), uiType);
				GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);

				UI ui = EntityFactory.Create<UI, string, GameObject>(Game.Scene, uiType, gameObject);

				return ui;
			}
			catch (Exception e)
			{
				Log.Error(e);
				return null;
			}
		}
	}
}