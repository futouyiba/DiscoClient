
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSelectViewComponentAwakeSystem : AwakeSystem<DlgSelectViewComponent> 
	{
		public override void Awake(DlgSelectViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSelectViewComponentDestroySystem : DestroySystem<DlgSelectViewComponent> 
	{
		public override void Destroy(DlgSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
