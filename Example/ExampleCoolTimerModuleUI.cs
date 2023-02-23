using UnityEngine;
using lLCroweTool.TimerSystem;

namespace lLCroweTool.TimerSystem.Sample
{
    public class ExampleCoolTimerModuleUI : MonoBehaviour
    {
        public CoolTimerModule coolTimer;

        public CoolTimerModuleUI coolTimerModuleUI;
        private void Start()
        {
            coolTimerModuleUI.SetCoolTimerModuleUI(coolTimer.coolTimerModule);
        }

        public void StartDebug()
        {
            Debug.Log("Start");
        }
        public void EndDebug()
        {
            Debug.Log("End");
        }
    }
}