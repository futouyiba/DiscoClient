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

            await ETTask.CompletedTask;
        }
    }
}