using System;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 现在处理的是刚进入舞池时候的all sync。后续不排除有其他时机导致的all sync，届时再作修改。
    /// </summary>
    [MessageHandler]
    public class action_syn_s2c_handler: AMHandler<action_syn_s2c>
    {

        protected override async ETTask Run(Session session, action_syn_s2c message)
        {
            Log.Info($"action sync s2c message:{message}");
            await ETTask.CompletedTask;
        }
    }
}