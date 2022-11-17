//using MEC;
//using UnityEngine;

//namespace lLCroweTool.TimerSystem
//{
//    /// <summary>
//    /// 코루틴타이머 모듈
//    /// </summary>
//    public sealed class CoroutineTimerModule : UnityEventTimerModule_Base
//    {
//        //업데이트 타이머와는 별개로 작동됨
//        //업데이트와는 별개로 작동되므로 UI같은곳에 사용할예정
//        //20221113
//        //구조변경
//        //따로 필요는 없을거 같긴한데//필요할수도 있으니 그대로 둠//time 변수는 사용안함
//        //타임모듈매니저 안에 따로 집어넣을수 있게 제작해둠

//        [HideInInspector] [SerializeField] private CoroutineHandle coroutineHandle;

//        public sealed override void UpdateTimerModuleFunc()
//        {
//            unityEvent.Invoke();
//        }

//        protected sealed override void ConnectTimerModuleManager()
//        {
//            coroutineHandle = Timing.RunCoroutine(TimerModuleManager.Instance.UpdateTimerModuleFunc(this));
//            TimerModuleManager.Instance.AddTimeModule(this, UpdateTimerModuleType.CoroutineEvent);
//        }

//        protected sealed override void DeconnectTimerModuleManager()
//        {
//            Timing.KillCoroutines(coroutineHandle);
//            TimerModuleManager.Instance.RemoveTimeModule(this, UpdateTimerModuleType.CoroutineEvent);
//        }
//    }
//}
