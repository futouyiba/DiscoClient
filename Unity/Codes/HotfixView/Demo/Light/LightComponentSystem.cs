using ET.Light;

namespace ET.Demo.Light
{
    /// <summary>
    /// 管理所有效果灯的Component
    /// 每一个LightComponent对应一组灯
    /// </summary>
    public static class LightComponentSystem
    {
        public static void On(this LightComponent self,int Id)
        {
            self.GoDict.TryGetValue(Id, out var go);
            go.SetActive(true);
        }

        public static void Off(this LightComponent self,int Id)
        {
            self.GoDict.TryGetValue(Id, out var go);
            go.SetActive(false);
        }

        public static void StopMoving(this LightComponent self)
        {
            Log.Error("stop moving not implemented");
        }
        
    }
}