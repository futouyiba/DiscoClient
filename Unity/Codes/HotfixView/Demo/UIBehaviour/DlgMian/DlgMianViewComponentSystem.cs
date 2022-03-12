
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgMianViewComponentAwakeSystem : AwakeSystem<DlgMianViewComponent> 
	{
		public override void Awake(DlgMianViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgMianViewComponentDestroySystem : DestroySystem<DlgMianViewComponent> 
	{
		public override void Destroy(DlgMianViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
