using System;

using UnityEngine;

namespace ET
{
	public class OperaComponent: Entity, IAwake, IUpdate
    {
        public Vector3 ClickPoint;
        public int CurrentSongIndex;

	    public int mapMask;
	    public GameObject DjGO;
	    public GameObject DiscoCamera;
	    public GameObject TeleportStartParticleGO;
	    public GameObject TeleportEndParticleGO;

	    public readonly C2M_PathfindingResult frameClickMap = new C2M_PathfindingResult();
	    public readonly action_req_c2s move_action_req_c2s = new action_req_c2s(){action_id = 2};
    }
}
