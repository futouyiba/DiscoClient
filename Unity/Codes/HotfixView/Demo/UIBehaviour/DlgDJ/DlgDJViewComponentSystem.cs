
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgDJViewComponentAwakeSystem : AwakeSystem<DlgDJViewComponent> 
	{
		public override void Awake(DlgDJViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgDJViewComponentDestroySystem : DestroySystem<DlgDJViewComponent> 
	{
		public override void Destroy(DlgDJViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
