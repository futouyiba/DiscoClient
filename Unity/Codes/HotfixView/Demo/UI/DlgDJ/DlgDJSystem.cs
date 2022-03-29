using System.Collections;
using System.Collections.Generic;
using System;
using ET.Demo.Camera;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgDJSystem
	{

		public static void RegisterUIEvent(this DlgDJ self)
		{
			self.View.E_Skill03Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().GoDJ().Coroutine();
			});
			self.View.E_Light01Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().CutMusic().Coroutine();
			});
			self.View.E_Light04Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().LeaveDJ().Coroutine();
			});
			self.View.E_PortraitButton.AddListener(() =>
			{
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SelectFigure);
				self.ZoneScene().CurrentScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_DJ);
			});
			self.View.E_Skill01Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<CameraComponent>().FollowCharWithTime();
			});
		}

		public static void ShowWindow(this DlgDJ self, Entity contextData = null)
		{
		}

		 

	}
}
