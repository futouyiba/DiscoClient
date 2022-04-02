using System.Collections;
using System.Collections.Generic;
using System;
using ET.Demo.Camera;
using ET.Demo.Light;
using ET.Light;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgDJSystem
	{

		public static void RegisterUIEvent(this DlgDJ self)
		{
			var bIs3On = false;
			var bIs4On = false;

			self.View.E_Light01Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().CutMusic().Coroutine();
			});
			self.View.E_Light04Button.AddListener(() =>
			{
				self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().LeaveDJ().Coroutine();
			});

			self.View.E_Light02Button.AddListener(() =>
			{
				bIs3On = !bIs3On;
				self.ZoneScene().CurrentScene().GetComponent<LightComponent>().OnOff(3, bIs3On);
			});
			self.View.E_Light03Button.AddListener(() =>
			{
				bIs4On = !bIs4On;
				self.ZoneScene().CurrentScene().GetComponent<LightComponent>().OnOff(4, bIs4On);
			});
		}

		public static void ShowWindow(this DlgDJ self, Entity contextData = null)
		{
		}

		 

	}
}
