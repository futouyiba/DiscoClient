
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgSelectFigureViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface01Button == null )
     			{
		    		this.m_E_Iinterface01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface01");
     			}
     			return this.m_E_Iinterface01Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface01Image == null )
     			{
		    		this.m_E_Iinterface01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface01");
     			}
     			return this.m_E_Iinterface01Image;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface02Button == null )
     			{
		    		this.m_E_Iinterface02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface02");
     			}
     			return this.m_E_Iinterface02Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface02Image == null )
     			{
		    		this.m_E_Iinterface02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface02");
     			}
     			return this.m_E_Iinterface02Image;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface03Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface03Button == null )
     			{
		    		this.m_E_Iinterface03Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface03");
     			}
     			return this.m_E_Iinterface03Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface03Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface03Image == null )
     			{
		    		this.m_E_Iinterface03Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface03");
     			}
     			return this.m_E_Iinterface03Image;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface04Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface04Button == null )
     			{
		    		this.m_E_Iinterface04Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface04");
     			}
     			return this.m_E_Iinterface04Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface04Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface04Image == null )
     			{
		    		this.m_E_Iinterface04Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface04");
     			}
     			return this.m_E_Iinterface04Image;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface05Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface05Button == null )
     			{
		    		this.m_E_Iinterface05Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface05");
     			}
     			return this.m_E_Iinterface05Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface05Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface05Image == null )
     			{
		    		this.m_E_Iinterface05Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface05");
     			}
     			return this.m_E_Iinterface05Image;
     		}
     	}

		public UnityEngine.UI.Button E_Iinterface06Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface06Button == null )
     			{
		    		this.m_E_Iinterface06Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface06");
     			}
     			return this.m_E_Iinterface06Button;
     		}
     	}

		public UnityEngine.UI.Image E_Iinterface06Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Iinterface06Image == null )
     			{
		    		this.m_E_Iinterface06Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Iinterface06");
     			}
     			return this.m_E_Iinterface06Image;
     		}
     	}

		public UnityEngine.UI.InputField E_NameInputFieldInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameInputFieldInputField == null )
     			{
		    		this.m_E_NameInputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/E_NameInputField");
     			}
     			return this.m_E_NameInputFieldInputField;
     		}
     	}

		public UnityEngine.UI.Image E_NameInputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameInputFieldImage == null )
     			{
		    		this.m_E_NameInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_NameInputField");
     			}
     			return this.m_E_NameInputFieldImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_E_Iinterface01Button = null;
			this.m_E_Iinterface01Image = null;
			this.m_E_Iinterface02Button = null;
			this.m_E_Iinterface02Image = null;
			this.m_E_Iinterface03Button = null;
			this.m_E_Iinterface03Image = null;
			this.m_E_Iinterface04Button = null;
			this.m_E_Iinterface04Image = null;
			this.m_E_Iinterface05Button = null;
			this.m_E_Iinterface05Image = null;
			this.m_E_Iinterface06Button = null;
			this.m_E_Iinterface06Image = null;
			this.m_E_NameInputFieldInputField = null;
			this.m_E_NameInputFieldImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_E_Iinterface01Button = null;
		private UnityEngine.UI.Image m_E_Iinterface01Image = null;
		private UnityEngine.UI.Button m_E_Iinterface02Button = null;
		private UnityEngine.UI.Image m_E_Iinterface02Image = null;
		private UnityEngine.UI.Button m_E_Iinterface03Button = null;
		private UnityEngine.UI.Image m_E_Iinterface03Image = null;
		private UnityEngine.UI.Button m_E_Iinterface04Button = null;
		private UnityEngine.UI.Image m_E_Iinterface04Image = null;
		private UnityEngine.UI.Button m_E_Iinterface05Button = null;
		private UnityEngine.UI.Image m_E_Iinterface05Image = null;
		private UnityEngine.UI.Button m_E_Iinterface06Button = null;
		private UnityEngine.UI.Image m_E_Iinterface06Image = null;
		private UnityEngine.UI.InputField m_E_NameInputFieldInputField = null;
		private UnityEngine.UI.Image m_E_NameInputFieldImage = null;
		public Transform uiTransform = null;
	}
}
