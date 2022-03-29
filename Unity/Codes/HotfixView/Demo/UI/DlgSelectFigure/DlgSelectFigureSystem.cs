﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgSelectFigureSystem
	{

		public static void RegisterUIEvent(this DlgSelectFigure self)
		{
			self.View.E_Iinterface01Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(1);
			});
			self.View.E_Iinterface02Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(2);
			});
			self.View.E_Iinterface03Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(3);
			});
			self.View.E_Iinterface04Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(4);
			});
			self.View.E_Iinterface05Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(5);
			});
			self.View.E_Iinterface06Button.AddListener(() =>
			{
				self.OnFigureButtonClicked(6);
			});
			self.View.E_EnterMapButton.AddListener(() =>
			{
				SelectFigureHelper.SelectFigure(self.ZoneScene(), SelectFigureHelper.chosenIndex).Coroutine();
			});
			// self.View.E_NameInputFieldInputField.
		}

		public static void ShowWindow(this DlgSelectFigure self, Entity contextData = null)
		{
		}

		public static void OnFigureButtonClicked(this DlgSelectFigure self, int figureIndex)
		{
			SelectFigureHelper.chosenIndex = figureIndex;
		}

	}
}