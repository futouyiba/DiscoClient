using System.Threading.Tasks;

namespace ET
{
    public static class SelectFigureHelper
    {
        public static int chosenIndex;
        
        public static async ETTask SelectFigure(Scene zoneScene, int index)
        {
            var changeFigResp = (action_req_s2c)await zoneScene.GetComponent<SessionComponent>().Session.Call(new action_req_c2s()
            {
                action_id = ConstValue.ACTION_ID_CHANGE_FIGURE, int1 = index,
            });
            if (changeFigResp.Error != 0)
            {
                return;
            }
            var myPlayerUnit = zoneScene.CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit();
            await Game.EventSystem.PublishAsync(new EventType.ChangeFigure() { FigureId = index, Unit = myPlayerUnit });
            zoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SelectFigure);
            
        }
    }
}