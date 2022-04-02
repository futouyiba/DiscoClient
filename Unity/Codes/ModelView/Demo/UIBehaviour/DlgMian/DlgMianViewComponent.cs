
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

		public UnityEngine.UI.Button E_Information1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Information1Button == null )
     			{
		    		this.m_E_Information1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Information1");
     			}
     			return this.m_E_Information1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Information1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Information1Image == null )
     			{
		    		this.m_E_Information1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Information1");
     			}
     			return this.m_E_Information1Image;
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
		    		this.m_E_PortraitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_Portrait");
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
		    		this.m_E_PortraitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_Portrait");
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
		    		this.m_E_NameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_Name");
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
		    		this.m_E_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_Name");
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
		    		this.m_E_OnliineTimeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_OnliineTime");
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
		    		this.m_E_OnliineTimeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Information1/E_OnliineTime");
     			}
     			return this.m_E_OnliineTimeImage;
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

		public UnityEngine.UI.Button E_DJ_FaceButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_FaceButton == null )
     			{
		    		this.m_E_DJ_FaceButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Face");
     			}
     			return this.m_E_DJ_FaceButton;
     		}
     	}

		public UnityEngine.UI.Image E_DJ_FaceImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_FaceImage == null )
     			{
		    		this.m_E_DJ_FaceImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Face");
     			}
     			return this.m_E_DJ_FaceImage;
     		}
     	}

		public UnityEngine.UI.Button E_DJ_NameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_NameButton == null )
     			{
		    		this.m_E_DJ_NameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Name");
     			}
     			return this.m_E_DJ_NameButton;
     		}
     	}

		public UnityEngine.UI.Image E_DJ_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_NameImage == null )
     			{
		    		this.m_E_DJ_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Name");
     			}
     			return this.m_E_DJ_NameImage;
     		}
     	}

		public UnityEngine.UI.Button E_DJ_LevelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_LevelButton == null )
     			{
		    		this.m_E_DJ_LevelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Level");
     			}
     			return this.m_E_DJ_LevelButton;
     		}
     	}

		public UnityEngine.UI.Image E_DJ_LevelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DJ_LevelImage == null )
     			{
		    		this.m_E_DJ_LevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_DJ/E_DJ_Level");
     			}
     			return this.m_E_DJ_LevelImage;
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

		public UnityEngine.UI.Button E_Friend_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_1Button == null )
     			{
		    		this.m_E_Friend_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_1");
     			}
     			return this.m_E_Friend_1Button;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_1Image == null )
     			{
		    		this.m_E_Friend_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_1");
     			}
     			return this.m_E_Friend_1Image;
     		}
     	}

		public UnityEngine.UI.Button E_Friend_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_2Button == null )
     			{
		    		this.m_E_Friend_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_2");
     			}
     			return this.m_E_Friend_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_2Image == null )
     			{
		    		this.m_E_Friend_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_2");
     			}
     			return this.m_E_Friend_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Friend_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3Button == null )
     			{
		    		this.m_E_Friend_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3");
     			}
     			return this.m_E_Friend_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3Image == null )
     			{
		    		this.m_E_Friend_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3");
     			}
     			return this.m_E_Friend_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Friend_3AButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3AButton == null )
     			{
		    		this.m_E_Friend_3AButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3A");
     			}
     			return this.m_E_Friend_3AButton;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_3AImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3AImage == null )
     			{
		    		this.m_E_Friend_3AImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3A");
     			}
     			return this.m_E_Friend_3AImage;
     		}
     	}

		public UnityEngine.UI.Button E_Friend_3BButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3BButton == null )
     			{
		    		this.m_E_Friend_3BButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3B");
     			}
     			return this.m_E_Friend_3BButton;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_3BImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3BImage == null )
     			{
		    		this.m_E_Friend_3BImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3B");
     			}
     			return this.m_E_Friend_3BImage;
     		}
     	}

		public UnityEngine.UI.Button E_Friend_3CButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3CButton == null )
     			{
		    		this.m_E_Friend_3CButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3C");
     			}
     			return this.m_E_Friend_3CButton;
     		}
     	}

		public UnityEngine.UI.Image E_Friend_3CImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Friend_3CImage == null )
     			{
		    		this.m_E_Friend_3CImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Friend/E_Friend_3C");
     			}
     			return this.m_E_Friend_3CImage;
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

		public UnityEngine.UI.Button E_Ranking_topButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_topButton == null )
     			{
		    		this.m_E_Ranking_topButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_top");
     			}
     			return this.m_E_Ranking_topButton;
     		}
     	}

		public UnityEngine.UI.Image E_Ranking_topImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_topImage == null )
     			{
		    		this.m_E_Ranking_topImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_top");
     			}
     			return this.m_E_Ranking_topImage;
     		}
     	}

		public UnityEngine.UI.Button E_Ranking_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_2Button == null )
     			{
		    		this.m_E_Ranking_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_2");
     			}
     			return this.m_E_Ranking_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_Ranking_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_2Image == null )
     			{
		    		this.m_E_Ranking_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_2");
     			}
     			return this.m_E_Ranking_2Image;
     		}
     	}

		public UnityEngine.UI.Button E_Ranking_3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_3Button == null )
     			{
		    		this.m_E_Ranking_3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_3");
     			}
     			return this.m_E_Ranking_3Button;
     		}
     	}

		public UnityEngine.UI.Image E_Ranking_3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_3Image == null )
     			{
		    		this.m_E_Ranking_3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_3");
     			}
     			return this.m_E_Ranking_3Image;
     		}
     	}

		public UnityEngine.UI.Button E_Ranking_4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_4Button == null )
     			{
		    		this.m_E_Ranking_4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_4");
     			}
     			return this.m_E_Ranking_4Button;
     		}
     	}

		public UnityEngine.UI.Image E_Ranking_4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Ranking_4Image == null )
     			{
		    		this.m_E_Ranking_4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Ranking/E_Ranking_4");
     			}
     			return this.m_E_Ranking_4Image;
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

		public UnityEngine.UI.Button E_ChatAButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatAButton == null )
     			{
		    		this.m_E_ChatAButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatA");
     			}
     			return this.m_E_ChatAButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatAImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatAImage == null )
     			{
		    		this.m_E_ChatAImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatA");
     			}
     			return this.m_E_ChatAImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatBButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatBButton == null )
     			{
		    		this.m_E_ChatBButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatB");
     			}
     			return this.m_E_ChatBButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatBImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatBImage == null )
     			{
		    		this.m_E_ChatBImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatB");
     			}
     			return this.m_E_ChatBImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatCButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatCButton == null )
     			{
		    		this.m_E_ChatCButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatC");
     			}
     			return this.m_E_ChatCButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatCImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatCImage == null )
     			{
		    		this.m_E_ChatCImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatC");
     			}
     			return this.m_E_ChatCImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatDButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatDButton == null )
     			{
		    		this.m_E_ChatDButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatD");
     			}
     			return this.m_E_ChatDButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatDImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatDImage == null )
     			{
		    		this.m_E_ChatDImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatD");
     			}
     			return this.m_E_ChatDImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatEButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatEButton == null )
     			{
		    		this.m_E_ChatEButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatE");
     			}
     			return this.m_E_ChatEButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatEImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatEImage == null )
     			{
		    		this.m_E_ChatEImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatE");
     			}
     			return this.m_E_ChatEImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatFButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatFButton == null )
     			{
		    		this.m_E_ChatFButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatF");
     			}
     			return this.m_E_ChatFButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatFImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatFImage == null )
     			{
		    		this.m_E_ChatFImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatF");
     			}
     			return this.m_E_ChatFImage;
     		}
     	}

		public UnityEngine.UI.Button E_ChatGButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatGButton == null )
     			{
		    		this.m_E_ChatGButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatG");
     			}
     			return this.m_E_ChatGButton;
     		}
     	}

		public UnityEngine.UI.Image E_ChatGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChatGImage == null )
     			{
		    		this.m_E_ChatGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Chat/E_ChatG");
     			}
     			return this.m_E_ChatGImage;
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

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_Information1Button = null;
			this.m_E_Information1Image = null;
			this.m_E_PortraitButton = null;
			this.m_E_PortraitImage = null;
			this.m_E_NameButton = null;
			this.m_E_NameImage = null;
			this.m_E_OnliineTimeButton = null;
			this.m_E_OnliineTimeImage = null;
			this.m_E_DJButton = null;
			this.m_E_DJImage = null;
			this.m_E_DJ_FaceButton = null;
			this.m_E_DJ_FaceImage = null;
			this.m_E_DJ_NameButton = null;
			this.m_E_DJ_NameImage = null;
			this.m_E_DJ_LevelButton = null;
			this.m_E_DJ_LevelImage = null;
			this.m_E_GiftButton = null;
			this.m_E_GiftImage = null;
			this.m_E_FriendButton = null;
			this.m_E_FriendImage = null;
			this.m_E_Friend_1Button = null;
			this.m_E_Friend_1Image = null;
			this.m_E_Friend_2Button = null;
			this.m_E_Friend_2Image = null;
			this.m_E_Friend_3Button = null;
			this.m_E_Friend_3Image = null;
			this.m_E_Friend_3AButton = null;
			this.m_E_Friend_3AImage = null;
			this.m_E_Friend_3BButton = null;
			this.m_E_Friend_3BImage = null;
			this.m_E_Friend_3CButton = null;
			this.m_E_Friend_3CImage = null;
			this.m_E_InformationButton = null;
			this.m_E_InformationImage = null;
			this.m_E_RankingButton = null;
			this.m_E_RankingImage = null;
			this.m_E_Ranking_topButton = null;
			this.m_E_Ranking_topImage = null;
			this.m_E_Ranking_2Button = null;
			this.m_E_Ranking_2Image = null;
			this.m_E_Ranking_3Button = null;
			this.m_E_Ranking_3Image = null;
			this.m_E_Ranking_4Button = null;
			this.m_E_Ranking_4Image = null;
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
			this.m_E_ChatAButton = null;
			this.m_E_ChatAImage = null;
			this.m_E_ChatBButton = null;
			this.m_E_ChatBImage = null;
			this.m_E_ChatCButton = null;
			this.m_E_ChatCImage = null;
			this.m_E_ChatDButton = null;
			this.m_E_ChatDImage = null;
			this.m_E_ChatEButton = null;
			this.m_E_ChatEImage = null;
			this.m_E_ChatFButton = null;
			this.m_E_ChatFImage = null;
			this.m_E_ChatGButton = null;
			this.m_E_ChatGImage = null;
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
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_Information1Button = null;
		private UnityEngine.UI.Image m_E_Information1Image = null;
		private UnityEngine.UI.Button m_E_PortraitButton = null;
		private UnityEngine.UI.Image m_E_PortraitImage = null;
		private UnityEngine.UI.Button m_E_NameButton = null;
		private UnityEngine.UI.Image m_E_NameImage = null;
		private UnityEngine.UI.Button m_E_OnliineTimeButton = null;
		private UnityEngine.UI.Image m_E_OnliineTimeImage = null;
		private UnityEngine.UI.Button m_E_DJButton = null;
		private UnityEngine.UI.Image m_E_DJImage = null;
		private UnityEngine.UI.Button m_E_DJ_FaceButton = null;
		private UnityEngine.UI.Image m_E_DJ_FaceImage = null;
		private UnityEngine.UI.Button m_E_DJ_NameButton = null;
		private UnityEngine.UI.Image m_E_DJ_NameImage = null;
		private UnityEngine.UI.Button m_E_DJ_LevelButton = null;
		private UnityEngine.UI.Image m_E_DJ_LevelImage = null;
		private UnityEngine.UI.Button m_E_GiftButton = null;
		private UnityEngine.UI.Image m_E_GiftImage = null;
		private UnityEngine.UI.Button m_E_FriendButton = null;
		private UnityEngine.UI.Image m_E_FriendImage = null;
		private UnityEngine.UI.Button m_E_Friend_1Button = null;
		private UnityEngine.UI.Image m_E_Friend_1Image = null;
		private UnityEngine.UI.Button m_E_Friend_2Button = null;
		private UnityEngine.UI.Image m_E_Friend_2Image = null;
		private UnityEngine.UI.Button m_E_Friend_3Button = null;
		private UnityEngine.UI.Image m_E_Friend_3Image = null;
		private UnityEngine.UI.Button m_E_Friend_3AButton = null;
		private UnityEngine.UI.Image m_E_Friend_3AImage = null;
		private UnityEngine.UI.Button m_E_Friend_3BButton = null;
		private UnityEngine.UI.Image m_E_Friend_3BImage = null;
		private UnityEngine.UI.Button m_E_Friend_3CButton = null;
		private UnityEngine.UI.Image m_E_Friend_3CImage = null;
		private UnityEngine.UI.Button m_E_InformationButton = null;
		private UnityEngine.UI.Image m_E_InformationImage = null;
		private UnityEngine.UI.Button m_E_RankingButton = null;
		private UnityEngine.UI.Image m_E_RankingImage = null;
		private UnityEngine.UI.Button m_E_Ranking_topButton = null;
		private UnityEngine.UI.Image m_E_Ranking_topImage = null;
		private UnityEngine.UI.Button m_E_Ranking_2Button = null;
		private UnityEngine.UI.Image m_E_Ranking_2Image = null;
		private UnityEngine.UI.Button m_E_Ranking_3Button = null;
		private UnityEngine.UI.Image m_E_Ranking_3Image = null;
		private UnityEngine.UI.Button m_E_Ranking_4Button = null;
		private UnityEngine.UI.Image m_E_Ranking_4Image = null;
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
		private UnityEngine.UI.Button m_E_ChatAButton = null;
		private UnityEngine.UI.Image m_E_ChatAImage = null;
		private UnityEngine.UI.Button m_E_ChatBButton = null;
		private UnityEngine.UI.Image m_E_ChatBImage = null;
		private UnityEngine.UI.Button m_E_ChatCButton = null;
		private UnityEngine.UI.Image m_E_ChatCImage = null;
		private UnityEngine.UI.Button m_E_ChatDButton = null;
		private UnityEngine.UI.Image m_E_ChatDImage = null;
		private UnityEngine.UI.Button m_E_ChatEButton = null;
		private UnityEngine.UI.Image m_E_ChatEImage = null;
		private UnityEngine.UI.Button m_E_ChatFButton = null;
		private UnityEngine.UI.Image m_E_ChatFImage = null;
		private UnityEngine.UI.Button m_E_ChatGButton = null;
		private UnityEngine.UI.Image m_E_ChatGImage = null;
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
		public Transform uiTransform = null;
	}
}
