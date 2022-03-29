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
		
		public static void OnLoginClickHandler(this DlgLogin self)
		{
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
			// self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
			SceneManager.LoadSceneAsync("Loading");
			LoginHelper.Login(
				self.DomainScene(), 
				ConstValue.SelectorAddress).Coroutine();
		}
		
		public static void HideWindow(this DlgLogin self)
		{

		}
	}
}
