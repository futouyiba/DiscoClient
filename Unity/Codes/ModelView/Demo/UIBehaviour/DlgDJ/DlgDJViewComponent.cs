
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgDJViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_MuiscButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MuiscButton == null )
     			{
		    		this.m_E_MuiscButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Muisc");
     			}
     			return this.m_E_MuiscButton;
     		}
     	}

		public UnityEngine.UI.Image E_MuiscImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MuiscImage == null )
     			{
		    		this.m_E_MuiscImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Muisc");
     			}
     			return this.m_E_MuiscImage;
     		}
     	}

		public UnityEngine.UI.Button E_SearchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SearchButton == null )
     			{
		    		this.m_E_SearchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Search");
     			}
     			return this.m_E_SearchButton;
     		}
     	}

		public UnityEngine.UI.Image E_SearchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SearchImage == null )
     			{
		    		this.m_E_SearchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Search");
     			}
     			return this.m_E_SearchImage;
     		}
     	}

		public UnityEngine.UI.Button E_Note01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Note01Button == null )
     			{
		    		this.m_E_Note01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Note01");
     			}
     			return this.m_E_Note01Button;
     		}
     	}

		public UnityEngine.UI.Image E_Note01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Note01Image == null )
     			{
		    		this.m_E_Note01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Note01");
     			}
     			return this.m_E_Note01Image;
     		}
     	}

		public UnityEngine.UI.Button E_Note02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Note02Button == null )
     			{
		    		this.m_E_Note02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Note02");
     			}
     			return this.m_E_Note02Button;
     		}
     	}

		public UnityEngine.UI.Image E_Note02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Note02Image == null )
     			{
		    		this.m_E_Note02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Note02");
     			}
     			return this.m_E_Note02Image;
     		}
     	}

		public UnityEngine.UI.Button E_ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatButton == null )
     			{
		    		this.m_E_ChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat");
     			}
     			return this.m_E_ChatButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatImage == null )
     			{
		    		this.m_E_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat");
     			}
     			return this.m_E_ChatImage;
     		}
     	}

		public UnityEngine.UI.Button E_InputBoxButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputBoxButton == null )
     			{
		    		this.m_E_InputBoxButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_InputBox");
     			}
     			return this.m_E_InputBoxButton;
     		}
     	}

		public UnityEngine.UI.Image E_InputBoxImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputBoxImage == null )
     			{
		    		this.m_E_InputBoxImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_InputBox");
     			}
     			return this.m_E_InputBoxImage;
     		}
     	}

		public UnityEngine.UI.Button E_Skill01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill01Button == null )
     			{
		    		this.m_E_Skill01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Skill01");
     			}
     			return this.m_E_Skill01Button;
     		}
     	}

		public UnityEngine.UI.Image E_Skill01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill01Image == null )
     			{
		    		this.m_E_Skill01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Skill01");
     			}
     			return this.m_E_Skill01Image;
     		}
     	}

		public UnityEngine.UI.Button E_Skill02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill02Button == null )
     			{
		    		this.m_E_Skill02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Skill02");
     			}
     			return this.m_E_Skill02Button;
     		}
     	}

		public UnityEngine.UI.Image E_Skill02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill02Image == null )
     			{
		    		this.m_E_Skill02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Skill02");
     			}
     			return this.m_E_Skill02Image;
     		}
     	}

		public UnityEngine.UI.Button E_Skill03Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill03Button == null )
     			{
		    		this.m_E_Skill03Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Skill03");
     			}
     			return this.m_E_Skill03Button;
     		}
     	}

		public UnityEngine.UI.Image E_Skill03Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill03Image == null )
     			{
		    		this.m_E_Skill03Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Skill03");
     			}
     			return this.m_E_Skill03Image;
     		}
     	}

		public UnityEngine.UI.Button E_Skill04Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill04Button == null )
     			{
		    		this.m_E_Skill04Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Skill04");
     			}
     			return this.m_E_Skill04Button;
     		}
     	}

		public UnityEngine.UI.Image E_Skill04Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Skill04Image == null )
     			{
		    		this.m_E_Skill04Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Skill04");
     			}
     			return this.m_E_Skill04Image;
     		}
     	}

		public UnityEngine.UI.Button E_Light01Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light01Button == null )
     			{
		    		this.m_E_Light01Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Light01");
     			}
     			return this.m_E_Light01Button;
     		}
     	}

		public UnityEngine.UI.Image E_Light01Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light01Image == null )
     			{
		    		this.m_E_Light01Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Light01");
     			}
     			return this.m_E_Light01Image;
     		}
     	}

		public UnityEngine.UI.Button E_Light02Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light02Button == null )
     			{
		    		this.m_E_Light02Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Light02");
     			}
     			return this.m_E_Light02Button;
     		}
     	}

		public UnityEngine.UI.Image E_Light02Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light02Image == null )
     			{
		    		this.m_E_Light02Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Light02");
     			}
     			return this.m_E_Light02Image;
     		}
     	}

		public UnityEngine.UI.Button E_Light03Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light03Button == null )
     			{
		    		this.m_E_Light03Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Light03");
     			}
     			return this.m_E_Light03Button;
     		}
     	}

		public UnityEngine.UI.Image E_Light03Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light03Image == null )
     			{
		    		this.m_E_Light03Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Light03");
     			}
     			return this.m_E_Light03Image;
     		}
     	}

		public UnityEngine.UI.Button E_Light04Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light04Button == null )
     			{
		    		this.m_E_Light04Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Light04");
     			}
     			return this.m_E_Light04Button;
     		}
     	}

		public UnityEngine.UI.Image E_Light04Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Light04Image == null )
     			{
		    		this.m_E_Light04Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Light04");
     			}
     			return this.m_E_Light04Image;
     		}
     	}

		public UnityEngine.UI.Button E_MusicListButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MusicListButton == null )
     			{
		    		this.m_E_MusicListButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_MusicList");
     			}
     			return this.m_E_MusicListButton;
     		}
     	}

		public UnityEngine.UI.Image E_MusicListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MusicListImage == null )
     			{
		    		this.m_E_MusicListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_MusicList");
     			}
     			return this.m_E_MusicListImage;
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
			this.m_E_MuiscButton = null;
			this.m_E_MuiscImage = null;
			this.m_E_SearchButton = null;
			this.m_E_SearchImage = null;
			this.m_E_Note01Button = null;
			this.m_E_Note01Image = null;
			this.m_E_Note02Button = null;
			this.m_E_Note02Image = null;
			this.m_E_ChatButton = null;
			this.m_E_ChatImage = null;
			this.m_E_InputBoxButton = null;
			this.m_E_InputBoxImage = null;
			this.m_E_Skill01Button = null;
			this.m_E_Skill01Image = null;
			this.m_E_Skill02Button = null;
			this.m_E_Skill02Image = null;
			this.m_E_Skill03Button = null;
			this.m_E_Skill03Image = null;
			this.m_E_Skill04Button = null;
			this.m_E_Skill04Image = null;
			this.m_E_Light01Button = null;
			this.m_E_Light01Image = null;
			this.m_E_Light02Button = null;
			this.m_E_Light02Image = null;
			this.m_E_Light03Button = null;
			this.m_E_Light03Image = null;
			this.m_E_Light04Button = null;
			this.m_E_Light04Image = null;
			this.m_E_MusicListButton = null;
			this.m_E_MusicListImage = null;
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
		private UnityEngine.UI.Button m_E_MuiscButton = null;
		private UnityEngine.UI.Image m_E_MuiscImage = null;
		private UnityEngine.UI.Button m_E_SearchButton = null;
		private UnityEngine.UI.Image m_E_SearchImage = null;
		private UnityEngine.UI.Button m_E_Note01Button = null;
		private UnityEngine.UI.Image m_E_Note01Image = null;
		private UnityEngine.UI.Button m_E_Note02Button = null;
		private UnityEngine.UI.Image m_E_Note02Image = null;
		private UnityEngine.UI.Button m_E_ChatButton = null;
		private UnityEngine.UI.Image m_E_ChatImage = null;
		private UnityEngine.UI.Button m_E_InputBoxButton = null;
		private UnityEngine.UI.Image m_E_InputBoxImage = null;
		private UnityEngine.UI.Button m_E_Skill01Button = null;
		private UnityEngine.UI.Image m_E_Skill01Image = null;
		private UnityEngine.UI.Button m_E_Skill02Button = null;
		private UnityEngine.UI.Image m_E_Skill02Image = null;
		private UnityEngine.UI.Button m_E_Skill03Button = null;
		private UnityEngine.UI.Image m_E_Skill03Image = null;
		private UnityEngine.UI.Button m_E_Skill04Button = null;
		private UnityEngine.UI.Image m_E_Skill04Image = null;
		private UnityEngine.UI.Button m_E_Light01Button = null;
		private UnityEngine.UI.Image m_E_Light01Image = null;
		private UnityEngine.UI.Button m_E_Light02Button = null;
		private UnityEngine.UI.Image m_E_Light02Image = null;
		private UnityEngine.UI.Button m_E_Light03Button = null;
		private UnityEngine.UI.Image m_E_Light03Image = null;
		private UnityEngine.UI.Button m_E_Light04Button = null;
		private UnityEngine.UI.Image m_E_Light04Image = null;
		private UnityEngine.UI.Button m_E_MusicListButton = null;
		private UnityEngine.UI.Image m_E_MusicListImage = null;
		public Transform uiTransform = null;
	}
}
