﻿using System.Threading.Tasks;

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

            if (text != null && text.Length > 0)
            {
                actionReqC2S.str1 = text;
            }

            action_req_s2c changeFigResp = (action_req_s2c)await zoneScene.GetComponent<SessionComponent>().Session.Call(actionReqC2S);
            if (changeFigResp.Error != 0)
            {
                Log.Info("change figure and name error:" + changeFigResp.Error);
                return;
            }

            if (index > 0)
            {
                var myPlayerUnit = zoneScene.CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit();
                await Game.EventSystem.PublishAsync(new EventType.ChangeFigure() { FigureId = index, Unit = myPlayerUnit });
                zoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SelectFigure);
            }

            if (text.Length > 0)
            {
                var myPlayerUnit = zoneScene.CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit();
                await Game.EventSystem.PublishAsync(new EventType.ChangeName() { Name = text, Unit = myPlayerUnit });
                zoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SelectFigure);
            }
        }
    }
}