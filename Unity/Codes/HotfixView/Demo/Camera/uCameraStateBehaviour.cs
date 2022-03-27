using System;
using ET.EventType;
using UnityEngine;

namespace ET.Demo.Camera
{
    public class uCameraStateBehaviour: StateMachineBehaviour
    {
        // [SerializeField]
        // protected Animator _animator;
        //
        // [SerializeField]
        // protected AnimatorStateInfo _stateInfo;

        protected Action Dlg_EnteredStill;
        protected Action Dlg_LeaveStill;
        
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Log.Info($"{Time.time}:camera animator state entered Still");
            this.Dlg_EnteredStill?.Invoke();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Log.Info($"{Time.time}:camera animator state left Still");
            this.Dlg_LeaveStill?.Invoke();
        }

        public void AddEnterStillDlg(Action func)
        {
            if (func == null)
            {
                Debug.LogError($"function added is null");
                return;
            }
            this.Dlg_EnteredStill += func;
        }
        
        public void AddLeaveStillDlg(Action func)
        {
            if (func == null)
            {
                Debug.LogError($"function added is null");
                return;
            }
            this.Dlg_LeaveStill += func;
        }
        
        
    }
}