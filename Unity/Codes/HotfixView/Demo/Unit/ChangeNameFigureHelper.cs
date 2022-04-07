using System.Threading.Tasks;

namespace ET
{
    public static class ChangeNameFigureHelper
    {
        public static int chosenIndex;

        public static async ETTask ChangeNameFigure(Scene zoneScene, int index, string text)
        {
            if (index <= 0 && string.IsNullOrEmpty(text))
            {
                return;
            }

            action_req_c2s actionReqC2S = new action_req_c2s() { action_id = ConstValue.ACTION_ID_CHANGE_FIGURE, };
            if (index > 0)
            {
                actionReqC2S.int1 = index;
            }

            if (!string.IsNullOrEmpty(text))
            {
                actionReqC2S.str1 = text;
            }

            action_req_s2c changeFigResp = (action_req_s2c)await zoneScene.GetComponent<SessionComponent>().Session.Call(actionReqC2S);
            if (changeFigResp.Error != 0)
            {
                Log.Info("change figure and name error:" + changeFigResp.Error);
                return;
            }

            UIComponent uiComponent = zoneScene.GetComponent<UIComponent>();
            
            if (index > 0)
            {
                var myPlayerUnit = zoneScene.CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit();
                await Game.EventSystem.PublishAsync(new EventType.ChangeFigure() { FigureId = index, Unit = myPlayerUnit });
                uiComponent.HideWindow(WindowID.WindowID_SelectFigure);
            }

            if (text.Length > 0)
            {
                var myPlayerUnit = zoneScene.CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit();
                await Game.EventSystem.PublishAsync(new EventType.ChangeName() { Name = text, Unit = myPlayerUnit });
                uiComponent.HideWindow(WindowID.WindowID_SelectFigure);
            }
            await uiComponent.ShowWindowAsync(WindowID.WindowID_Mian);
        }
    }
}