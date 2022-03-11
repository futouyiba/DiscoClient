namespace ET
{
	public  class DlgMian :Entity,IAwake
	{

		public DlgMianViewComponent View { get => this.Parent.GetComponent<DlgMianViewComponent>();} 

		 

	}
}
