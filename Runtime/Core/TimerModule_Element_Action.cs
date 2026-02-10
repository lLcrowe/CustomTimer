namespace lLCroweTool.TimerSystem
{
    /// <summary>
    /// 타 타이머모듈 요소 액션타입
    /// </summary>
    public struct TimerModule_Element_Action
    {
        private TimerModule_Element timerModule;

        public System.Action action;

        public TimerModule_Element TimerModule { get => timerModule; }

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