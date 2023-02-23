//using MEC;
//using UnityEngine;

//namespace lLCroweTool.TimerSystem
//{
//    public abstract class CoroutineTimerModule_Base : TimerModule_Base
//    {
//        //20221116//구조변경 완료

//        [HideInInspector] [SerializeField] private CoroutineHandle coroutineHandle;
//        protected sealed override void ConnectTimerModuleManager()
//        {
//            coroutineHandle = Timing.RunCoroutine(TimerModuleManager.Instance.UpdateTimerModuleFunc(this));
//            TimerModuleManager.Instance.AddTimeModule(this, UpdateTimerModuleType.Coroutine);
//        }

//        protected sealed override void DeconnectTimerModuleManager()
//        {
//            Timing.KillCoroutines(coroutineHandle);
//            TimerModuleManager.Instance.RemoveTimeModule(this, UpdateTimerModuleType.Coroutine);
//        }
//    }
//}