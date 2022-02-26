using System;
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
        public static async ETTask Login(Scene zoneScene, string address, string account, string password)
        {
            try
            {
                
                
                // 创建一个ETModel层的Session
                // R2C_Login r2CLogin;
                get_transfer_endpoint_s2c getEndpointResp;
                Session session = null;
                try
                {
                    session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                    // r2CLogin = (R2C_Login)await session.Call(new C2R_Login() { Account = account, Password = password });
                    getEndpointResp =
                            (get_transfer_endpoint_s2c)await session.Call(new get_transfer_endpoint_c2s() { endpoint_id = 1, user_id = UserId75 });
                    Debug.Log("endpoint response:"+getEndpointResp);
                }
                finally
                {
                    session?.Dispose();
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(getEndpointResp.ip, getEndpointResp.port));
                gateSession.AddComponent<PingComponent>();
                zoneScene.AddComponent<SessionComponent>().Session = gateSession;
				
                // G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                //     new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});
                var authResp = (authenticate_s2c)await gateSession.Call(new authenticate_c2s()
                {
                    device_product_id = DeviceProductId75, device_type = 1, user_id = UserId75
                });
                
                Log.Debug("登陆gate成功!");

                await Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene});
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        } 
    }
}