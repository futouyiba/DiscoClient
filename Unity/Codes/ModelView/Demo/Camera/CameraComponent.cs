using UnityEngine;

namespace ET
{
	

	public class CameraComponent : Entity, IAwake, ILateUpdate
	{
		
		public Camera camera;
		public Animator animator;
		//摄像机的初始位置
		public Vector3 initPos = Vector3.zero;
		//摄像机跟随用的参数
		public bool IsFollowing = false;
		public GameObject GOFollowing = null;
		//不计时追踪所用的任务
		public ETTask followingTask=null;

		public bool IsAnimatorStill = true;
		//进入静止之后，启动这个任务
		public ETTask enterStillTask = null;
		// public Camera MainCamera
		// {
		// 	get
		// 	{
		// 		return this.mainCamera;
		// 	}
		// }
		//
		// public void Awake()
		// {
		// 	this.mainCamera = Camera.main;
		// }
		//
		// public void LateUpdate()
		// {
		// 	// 摄像机每帧更新位置
		// 	UpdatePosition();
		// }
		//
		// private void UpdatePosition()
		// {
		// 	Vector3 cameraPos = this.mainCamera.transform.position;
		// 	this.mainCamera.transform.position = new Vector3(this.Unit.Position.x, cameraPos.y, this.Unit.Position.z - 1);
		// }
	}
}
