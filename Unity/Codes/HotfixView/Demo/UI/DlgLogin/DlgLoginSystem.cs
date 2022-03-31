using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.E_LoginButton.AddListener(self.OnLoginClickHandler);
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
			
		}
		
		public static async void OnLoginClickHandler(this DlgLogin self)
		{
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
			// self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
			var scComp = self.ZoneScene().GetComponent<SceneChangeComponent>();
			await scComp.ChangeSceneAsync("Loading");
			// SceneManager.LoadScene("Loading");
			LoginHelper.Login(
				self.DomainScene(), 
				ConstValue.SelectorAddress).Coroutine();
			
			var res=scComp.TryBindProcessView();
			// Log.Warning($"bind process view succeeded? {res}");

		}
		
		public static void HideWindow(this DlgLogin self)
		{

		}
	}
}
