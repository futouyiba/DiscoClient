namespace ET
{
	public  class DlgDJ :Entity,IAwake
	{

		public DlgDJViewComponent View { get => this.Parent.GetComponent<DlgDJViewComponent>();} 

		 

	}
}
