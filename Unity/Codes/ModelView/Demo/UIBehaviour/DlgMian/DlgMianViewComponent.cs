
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgMianViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_PortraitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PortraitButton == null )
     			{
		    		this.m_E_PortraitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Portrait");
     			}
     			return this.m_E_PortraitButton;
     		}
     	}

		public UnityEngine.UI.Image E_PortraitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PortraitImage == null )
     			{
		    		this.m_E_PortraitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Portrait");
     			}
     			return this.m_E_PortraitImage;
     		}
     	}

		public UnityEngine.UI.Button E_NameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameButton == null )
     			{
		    		this.m_E_NameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Name");
     			}
     			return this.m_E_NameButton;
     		}
     	}

		public UnityEngine.UI.Image E_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameImage == null )
     			{
		    		this.m_E_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Name");
     			}
     			return this.m_E_NameImage;
     		}
     	}

		public UnityEngine.UI.Button E_OnliineTimeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OnliineTimeButton == null )
     			{
		    		this.m_E_OnliineTimeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_OnliineTime");
     			}
     			return this.m_E_OnliineTimeButton;
     		}
     	}

		public UnityEngine.UI.Image E_OnliineTimeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OnliineTimeImage == null )
     			{
		    		this.m_E_OnliineTimeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_OnliineTime");
     			}
     			return this.m_E_OnliineTimeImage;
     		}
     	}

		public UnityEngine.UI.Button E_ReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnButton == null )
     			{
		    		this.m_E_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Return");
     			}
     			return this.m_E_ReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReturnImage == null )
     			{
		    		this.m_E_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Return");
     			}
     			return this.m_E_ReturnImage;
     		}
     	}

		public UnityEngine.UI.Button E_DJButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJButton == null )
     			{
		    		this.m_E_DJButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_DJ");
     			}
     			return this.m_E_DJButton;
     		}
     	}

		public UnityEngine.UI.Image E_DJImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJImage == null )
     			{
		    		this.m_E_DJImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_DJ");
     			}
     			return this.m_E_DJImage;
     		}
     	}

		public UnityEngine.UI.Button E_GiftButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiftButton == null )
     			{
		    		this.m_E_GiftButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Gift");
     			}
     			return this.m_E_GiftButton;
     		}
     	}

		public UnityEngine.UI.Image E_GiftImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GiftImage == null )
     			{
		    		this.m_E_GiftImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Gift");
     			}
     			return this.m_E_GiftImage;
     		}
     	}

		public UnityEngine.UI.Button E_FriendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendButton == null )
     			{
		    		this.m_E_FriendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend");
     			}
     			return this.m_E_FriendButton;
     		}
     	}

		public UnityEngine.UI.Image E_FriendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FriendImage == null )
     			{
		    		this.m_E_FriendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend");
     			}
     			return this.m_E_FriendImage;
     		}
     	}

		public UnityEngine.UI.Button E_InformationButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InformationButton == null )
     			{
		    		this.m_E_InformationButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Information");
     			}
     			return this.m_E_InformationButton;
     		}
     	}

		public UnityEngine.UI.Image E_InformationImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InformationImage == null )
     			{
		    		this.m_E_InformationImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Information");
     			}
     			return this.m_E_InformationImage;
     		}
     	}

		public UnityEngine.UI.Button E_RankingButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankingButton == null )
     			{
		    		this.m_E_RankingButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Ranking");
     			}
     			return this.m_E_RankingButton;
     		}
     	}

		public UnityEngine.UI.Image E_RankingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankingImage == null )
     			{
		    		this.m_E_RankingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Ranking");
     			}
     			return this.m_E_RankingImage;
     		}
     	}

		public UnityEngine.UI.Button E_NextClassButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextClassButton == null )
     			{
		    		this.m_E_NextClassButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_NextClass");
     			}
     			return this.m_E_NextClassButton;
     		}
     	}

		public UnityEngine.UI.Image E_NextClassImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextClassImage == null )
     			{
		    		this.m_E_NextClassImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_NextClass");
     			}
     			return this.m_E_NextClassImage;
     		}
     	}

		public UnityEngine.UI.Button E_ MuiscButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ MuiscButton == null )
     			{
		    		this.m_E_ MuiscButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Muisc");
     			}
     			return this.m_E_ MuiscButton;
     		}
     	}

		public UnityEngine.UI.Image E_ MuiscImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ MuiscImage == null )
     			{
		    		this.m_E_ MuiscImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Muisc");
     			}
     			return this.m_E_ MuiscImage;
     		}
     	}

		public UnityEngine.UI.Button E_ SearchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ SearchButton == null )
     			{
		    		this.m_E_ SearchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Search");
     			}
     			return this.m_E_ SearchButton;
     		}
     	}

		public UnityEngine.UI.Image E_ SearchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ SearchImage == null )
     			{
		    		this.m_E_ SearchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Search");
     			}
     			return this.m_E_ SearchImage;
     		}
     	}

		public UnityEngine.UI.Button E_ Note01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Note01Button == null )
     			{
		    		this.m_E_ Note01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Note01");
     			}
     			return this.m_E_ Note01Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Note01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Note01Image == null )
     			{
		    		this.m_E_ Note01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Note01");
     			}
     			return this.m_E_ Note01Image;
     		}
     	}

		public UnityEngine.UI.Button E_ Note02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Note02Button == null )
     			{
		    		this.m_E_ Note02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Note02");
     			}
     			return this.m_E_ Note02Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Note02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Note02Image == null )
     			{
		    		this.m_E_ Note02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Note02");
     			}
     			return this.m_E_ Note02Image;
     		}
     	}

		public UnityEngine.UI.Button E_ ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ ChatButton == null )
     			{
		    		this.m_E_ ChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Chat");
     			}
     			return this.m_E_ ChatButton;
     		}
     	}

		public UnityEngine.UI.Image E_ ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ ChatImage == null )
     			{
		    		this.m_E_ ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Chat");
     			}
     			return this.m_E_ ChatImage;
     		}
     	}

		public UnityEngine.UI.Button E_ InputBoxButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ InputBoxButton == null )
     			{
		    		this.m_E_ InputBoxButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ InputBox");
     			}
     			return this.m_E_ InputBoxButton;
     		}
     	}

		public UnityEngine.UI.Image E_ InputBoxImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ InputBoxImage == null )
     			{
		    		this.m_E_ InputBoxImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ InputBox");
     			}
     			return this.m_E_ InputBoxImage;
     		}
     	}

		public UnityEngine.UI.Button E_ Skill01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill01Button == null )
     			{
		    		this.m_E_ Skill01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Skill01");
     			}
     			return this.m_E_ Skill01Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Skill01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill01Image == null )
     			{
		    		this.m_E_ Skill01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Skill01");
     			}
     			return this.m_E_ Skill01Image;
     		}
     	}

		public UnityEngine.UI.Button E_ Skill02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill02Button == null )
     			{
		    		this.m_E_ Skill02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Skill02");
     			}
     			return this.m_E_ Skill02Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Skill02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill02Image == null )
     			{
		    		this.m_E_ Skill02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Skill02");
     			}
     			return this.m_E_ Skill02Image;
     		}
     	}

		public UnityEngine.UI.Button E_ Skill03Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill03Button == null )
     			{
		    		this.m_E_ Skill03Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Skill03");
     			}
     			return this.m_E_ Skill03Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Skill03Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill03Image == null )
     			{
		    		this.m_E_ Skill03Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Skill03");
     			}
     			return this.m_E_ Skill03Image;
     		}
     	}

		public UnityEngine.UI.Button E_ Skill04Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill04Button == null )
     			{
		    		this.m_E_ Skill04Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_ Skill04");
     			}
     			return this.m_E_ Skill04Button;
     		}
     	}

		public UnityEngine.UI.Image E_ Skill04Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ Skill04Image == null )
     			{
		    		this.m_E_ Skill04Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_ Skill04");
     			}
     			return this.m_E_ Skill04Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_PortraitButton = null;
			this.m_E_PortraitImage = null;
			this.m_E_NameButton = null;
			this.m_E_NameImage = null;
			this.m_E_OnliineTimeButton = null;
			this.m_E_OnliineTimeImage = null;
			this.m_E_ReturnButton = null;
			this.m_E_ReturnImage = null;
			this.m_E_DJButton = null;
			this.m_E_DJImage = null;
			this.m_E_GiftButton = null;
			this.m_E_GiftImage = null;
			this.m_E_FriendButton = null;
			this.m_E_FriendImage = null;
			this.m_E_InformationButton = null;
			this.m_E_InformationImage = null;
			this.m_E_RankingButton = null;
			this.m_E_RankingImage = null;
			this.m_E_NextClassButton = null;
			this.m_E_NextClassImage = null;
			this.m_E_ MuiscButton = null;
			this.m_E_ MuiscImage = null;
			this.m_E_ SearchButton = null;
			this.m_E_ SearchImage = null;
			this.m_E_ Note01Button = null;
			this.m_E_ Note01Image = null;
			this.m_E_ Note02Button = null;
			this.m_E_ Note02Image = null;
			this.m_E_ ChatButton = null;
			this.m_E_ ChatImage = null;
			this.m_E_ InputBoxButton = null;
			this.m_E_ InputBoxImage = null;
			this.m_E_ Skill01Button = null;
			this.m_E_ Skill01Image = null;
			this.m_E_ Skill02Button = null;
			this.m_E_ Skill02Image = null;
			this.m_E_ Skill03Button = null;
			this.m_E_ Skill03Image = null;
			this.m_E_ Skill04Button = null;
			this.m_E_ Skill04Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_PortraitButton = null;
		private UnityEngine.UI.Image m_E_PortraitImage = null;
		private UnityEngine.UI.Button m_E_NameButton = null;
		private UnityEngine.UI.Image m_E_NameImage = null;
		private UnityEngine.UI.Button m_E_OnliineTimeButton = null;
		private UnityEngine.UI.Image m_E_OnliineTimeImage = null;
		private UnityEngine.UI.Button m_E_ReturnButton = null;
		private UnityEngine.UI.Image m_E_ReturnImage = null;
		private UnityEngine.UI.Button m_E_DJButton = null;
		private UnityEngine.UI.Image m_E_DJImage = null;
		private UnityEngine.UI.Button m_E_GiftButton = null;
		private UnityEngine.UI.Image m_E_GiftImage = null;
		private UnityEngine.UI.Button m_E_FriendButton = null;
		private UnityEngine.UI.Image m_E_FriendImage = null;
		private UnityEngine.UI.Button m_E_InformationButton = null;
		private UnityEngine.UI.Image m_E_InformationImage = null;
		private UnityEngine.UI.Button m_E_RankingButton = null;
		private UnityEngine.UI.Image m_E_RankingImage = null;
		private UnityEngine.UI.Button m_E_NextClassButton = null;
		private UnityEngine.UI.Image m_E_NextClassImage = null;
		private UnityEngine.UI.Button m_E_ MuiscButton = null;
		private UnityEngine.UI.Image m_E_ MuiscImage = null;
		private UnityEngine.UI.Button m_E_ SearchButton = null;
		private UnityEngine.UI.Image m_E_ SearchImage = null;
		private UnityEngine.UI.Button m_E_ Note01Button = null;
		private UnityEngine.UI.Image m_E_ Note01Image = null;
		private UnityEngine.UI.Button m_E_ Note02Button = null;
		private UnityEngine.UI.Image m_E_ Note02Image = null;
		private UnityEngine.UI.Button m_E_ ChatButton = null;
		private UnityEngine.UI.Image m_E_ ChatImage = null;
		private UnityEngine.UI.Button m_E_ InputBoxButton = null;
		private UnityEngine.UI.Image m_E_ InputBoxImage = null;
		private UnityEngine.UI.Button m_E_ Skill01Button = null;
		private UnityEngine.UI.Image m_E_ Skill01Image = null;
		private UnityEngine.UI.Button m_E_ Skill02Button = null;
		private UnityEngine.UI.Image m_E_ Skill02Image = null;
		private UnityEngine.UI.Button m_E_ Skill03Button = null;
		private UnityEngine.UI.Image m_E_ Skill03Image = null;
		private UnityEngine.UI.Button m_E_ Skill04Button = null;
		private UnityEngine.UI.Image m_E_ Skill04Image = null;
		public Transform uiTransform = null;
	}
}
