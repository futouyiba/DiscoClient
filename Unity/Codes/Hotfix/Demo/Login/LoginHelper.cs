using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET
{
    public static class LoginHelper
    {
        public static string DEVICE_PRODUCT_ID = "DEVICE_PRODUCT_ID";
        public static string DEVICE_MODEL = "DEVICE_MODEL";
        public static string USER_ID = "USER_ID";
        public static int registerPostfix = 75;
        public static string CloudIp = "82.157.8.127";
        public static int port = 8800;
        public static Entity fuiComponent;

        public static int UserId75 = 32;
        public static string DeviceModel75 = "DEVICE_MODEL75";
        public static string DeviceProductId75 = "DEVICE_PRODUCT_ID75";
        public static Dictionary<int, int> USER_ID_TO_PRODUCT_ID = new Dictionary<int, int>() { { 32, 75 }, { 31, 71 }, { 30, 71 } };

        public static async ETTask Login(Scene zoneScene, string address, string account, string password)
        {
#if NOT_UNITY
            var myProductId = DeviceProductId75;
            var userId = UserId75;
#else
            var myProductId = SystemInfo.deviceUniqueIdentifier;
            Log.Info("product id:"+myProductId);
            if(!PlayerPrefs.HasKey(USER_ID))
            {
                Session selectorSession = null;
                try
                {
                    selectorSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                    var registerResp =
                            (register_user_s2c)await selectorSession.Call(new register_user_c2s() { device_model = DEVICE_MODEL, device_type =
 1, device_product_id = myProductId});
                    // (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = randomUserId });
                    // (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = UserId75 });
                    
                    Log.Info("register response:" + registerResp);
                    if (registerResp.Error == 0)
                    {
                        PlayerPrefs.SetInt(USER_ID, registerResp.user_id);
                    }
                    else
                    {
                        Log.Error("I have registered using this device identifier/productId before...");
                        await ETTask.CompletedTask;
                    }
                }
                finally
                {
                    selectorSession?.Dispose();
                }
            }

            var userId = PlayerPrefs.GetInt(USER_ID);

#endif

            // int.TryParse(account, out int accountInt);
            // var randIndex = RandomHelper.RandInt32() % 3;
            // var keyValuePair = USER_ID_TO_PRODUCT_ID.ToList()[randIndex];
            // var randomUserId = keyValuePair.Key;
            // var randomProductId = DEVICE_PRODUCT_ID + keyValuePair.Value;
            // todo specify account and product id.
            try
            {
                // 创建一个ETModel层的Session
                get_transfer_endpoint_s2c getEndpointResp;
                Session session = null;
                try
                {
                    session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                    getEndpointResp =
                            (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = userId });
                    // (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = randomUserId });
                    // (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = UserId75 });
                    Log.Info("endpoint response:" + getEndpointResp);
                }
                finally
                {
                    session?.Dispose();
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>()
                        .Create(NetworkHelper.ToIPEndPoint(getEndpointResp.ip, getEndpointResp.port));
                gateSession.AddComponent<PingComponent>();
                zoneScene.AddComponent<SessionComponent>().Session = gateSession;

                var authResp = (authenticate_s2c)await gateSession.Call(new authenticate_c2s()
                {
                    device_product_id = myProductId, device_type = 1, user_id = userId
                    // device_product_id = randomProductId, device_type = 1, user_id = randomUserId
                    // device_product_id = DeviceProductId75, device_type = 1, user_id = UserId75
                });

                Log.Debug("auth response:" + authResp);
                var errorCode = authResp.Error;
                if (errorCode == 0)
                {
                    
                    await Game.EventSystem.PublishAsync(new EventType.LoginFinish() { ZoneScene = zoneScene });

                    // await SceneChangeHelper.SceneChangeTo(gateSession.ZoneScene(), "Map1", 65535);
                }
                else
                {
                    gateSession?.Dispose();
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}