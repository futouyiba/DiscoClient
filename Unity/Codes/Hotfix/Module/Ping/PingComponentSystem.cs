using System;

namespace ET
{
    [ObjectSystem]
    public class PingComponentAwakeSystem: AwakeSystem<PingComponent>
    {
        public override void Awake(PingComponent self)
        {
            PingAsync(self).Coroutine();
        }

        private static async ETTask PingAsync(PingComponent self)
        {
            Session session = self.GetParent<Session>();
            long instanceId = self.InstanceId;
            
            while (true)
            {
                if (self.InstanceId != instanceId)
                {
                    return;
                }

                long time1 = TimeHelper.ClientNow();
                self.heartbeatC2S.client_time = time1;
                try
                {
                    await TimerComponent.Instance.WaitAsync(10000);

                    // session.Send(self.heartbeatC2S);
                    heartbeat_s2c response = await session.Call(self.heartbeatC2S) as heartbeat_s2c;
                    
                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }
                    
                    long time2 = TimeHelper.ClientNow();
                    self.Ping = time2 - time1;
                    
                    Game.TimeInfo.ServerMinusClientTime = response.server_time + (time2 - time1) / 2 - time2;

                }
                catch (RpcException e)
                {
                    // session断开导致ping rpc报错，记录一下即可，不需要打成error
                    Log.Info($"ping error: {self.Id} {e.Error}");
                    return;
                }
                catch (Exception e)
                {
                    Log.Error($"ping error: \n{e}");
                }
            }
        }
    }

    [ObjectSystem]
    public class PingComponentDestroySystem: DestroySystem<PingComponent>
    {
        public override void Destroy(PingComponent self)
        {
            self.Ping = default;
        }
    }
}