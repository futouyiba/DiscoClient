using UnityEngine;

namespace ET
{
    namespace EventType
    {
        public struct AppStart
        {
        }

        public struct SceneChangeStart
        {
            public Scene ZoneScene;
        }

        public struct SceneChangeHaveArtMissingChars
        {
            public Scene ZoneScene;
        }
        
        public struct SceneChangeFinish
        {
            public Scene ZoneScene;
            public Scene CurrentScene;
        }

        public struct ChangePosition
        {
            public Unit Unit;
            public Vector3 OldPos;
        }

        public struct ChangeRotation
        {
            public Unit Unit;
        }

        public struct PingChange
        {
            public Scene ZoneScene;
            public long Ping;
        }
        
        public struct AfterCreateZoneScene
        {
            public Scene ZoneScene;
        }
        
        public struct AfterCreateCurrentScene
        {
            public Scene CurrentScene;
        }
        
        public struct AfterCreateLoginScene
        {
            public Scene LoginScene;
        }

        public struct AppStartInitFinish
        {
            public Scene ZoneScene;
        }

        public struct LoginFinish
        {
            public Scene ZoneScene;
        }

        public struct LoadingBegin
        {
            public Scene Scene;
        }

        public struct LoadingFinish
        {
            public Scene Scene;
        }

        public struct EnterMapFinish
        {
            public Scene ZoneScene;
        }

        public struct AfterUnitCreate
        {
            public Unit Unit;
        }

        public struct AfterUnitRemove
        {
            public Unit Unit;
        }
        
        public struct MoveStart
        {
            public Unit Unit;
            public float x;
            public float y;
        }

        public struct MoveStop
        {
            public Unit Unit;
        }
        
        public struct ChangeName
        {
            public string Name { get; set; }

            public Unit Unit { get; set; }
        }

        public struct BecomeDJ
        {
            public Unit Unit;
            public int SeatId;
        }

        public struct LeaveDJ
        {
            public Unit Unit;
        }

        public struct ControlLight
        {
            public Scene ZoneScene;
            public int LightId;
            public int SwitchType;
        }

        public struct CutToMusic
        {
            public int MusicId;
            public Scene ZoneScene;
        }

        public struct GrowBig
        {
            public Unit Unit;
        }

        public struct ChangeFigure
        {
            public Unit Unit;
            public int FigureId;
        }

        public struct TakeSeat
        {
            public Unit Unit;
            public int SeatId;
        }

        public struct ShoutSlogan
        {
            public Unit Unit;
            public string SloganToShout;
        }

        public struct Chat
        {
            public Unit Unit;
            public string Content;
        }


    }
}