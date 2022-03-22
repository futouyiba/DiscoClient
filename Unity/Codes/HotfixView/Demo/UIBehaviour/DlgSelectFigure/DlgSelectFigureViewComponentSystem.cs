
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSelectFigureViewComponentAwakeSystem : AwakeSystem<DlgSelectFigureViewComponent> 
	{
		public override void Awake(DlgSelectFigureViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSelectFigureViewComponentDestroySystem : DestroySystem<DlgSelectFigureViewComponent> 
	{
		public override void Destroy(DlgSelectFigureViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
