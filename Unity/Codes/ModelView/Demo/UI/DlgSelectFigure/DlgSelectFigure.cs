namespace ET
{
	public  class DlgSelectFigure :Entity,IAwake
	{

		public DlgSelectFigureViewComponent View { get => this.Parent.GetComponent<DlgSelectFigureViewComponent>();} 

		 

	}
}
