using System.Collections;
using System.Collections.Generic;
using System;
using ET.Demo.Camera;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgMianSystem
	{

		public static void RegisterUIEvent(this DlgMian self)
		{
			self.View.E_Skill03Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().GoDJ().Coroutine();
			});
			self.View.E_PortraitButton.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SelectFigure);
				self.ZoneScene().CurrentScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Mian);
			});
			self.View.E_Skill01Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<CameraComponent>().FollowCharWithTime();
			});
		}

		public static void ShowWindow(this DlgMian self, Entity contextData = null)
		{
		}

		 

	}
}
