using System;
using UnityEngine;

namespace ET
{
    [MessageHandler]
    public class all_sync_s2c_handler: AMHandler<all_sync_s2c>
    {
        protected override async ETTask Run(Session session, all_sync_s2c message)
        {
            Log.Info($"all sync message:{message}");
            session.DomainScene().GetComponent<ObjectWait>().Notify(new WaitType.Wait_all_sync() {Message = message});
            

            await ETTask.CompletedTask;
        }
    }
}