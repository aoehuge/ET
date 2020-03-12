using System;
using ETModel;
using FairyGUI;
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

		public static FUI CreateFUI(string uiType)
		{
			try
			{
				ETModel.Game.Scene.GetComponent<FUIPackageComponent>().AddPackage(uiType);

				FUI fui = EntityFactory.Create<FUI, string, GObject>(Game.Scene, uiType, UIPackage.CreateObject(uiType, uiType));
				fui.Name = uiType;

				// 挂上窗口组件就成了窗口
				FUIWindowComponent fWindow = fui.AddComponent<FUIWindowComponent>();
				fWindow.Modal = true;
				fWindow.Show();

				return fui;
			}
			catch (Exception e)
			{
				Log.Error(e);
				return null;
			}
		}

		public static async ETTask<FUI> CreateFUIAsync(string uiType)
		{
			await ETTask.CompletedTask;

			try
			{
				ETModel.Game.Scene.GetComponent<FUIPackageComponent>().AddPackage(uiType);

				FUI fui = EntityFactory.Create<FUI, string, GObject>(Game.Scene, uiType, UIPackage.CreateObject(uiType, uiType));
				fui.Name = uiType;

				// 挂上窗口组件就成了窗口
				//FUIWindowComponent fWindow = fui.AddComponent<FUIWindowComponent>();
				//fWindow.Modal = true;
				//fWindow.Show();

				return fui;
			}
			catch (Exception e)
			{
				Log.Error(e);
				return null;
			}
		}
	}
}