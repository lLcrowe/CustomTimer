namespace lLCroweTool.TimerSystem
{
    /// <summary>
    /// 타 타이머모듈 요소 액션타입
    /// </summary>
    public struct TimerModule_Element_Action
    {
        public TimerModule_Element timerModule;
        public System.Action action;

        public void UpdateTimerModule()
        {
            if (!timerModule.CheckTimer())
            {
                return;
            }
            action?.Invoke();
        }        
    }
}