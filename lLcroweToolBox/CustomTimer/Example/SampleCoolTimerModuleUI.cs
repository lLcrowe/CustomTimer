using System.Collections;
using UnityEngine;
using lLCroweTool.TimerSystem;

namespace Assets
{
    public class SampleCoolTimerModuleUI : MonoBehaviour
    {
        public CoolTimerModule coolTimer;

        public CoolTimerModuleUI coolTimerModuleUI;
        private void Start()
        {
            coolTimerModuleUI.SetCoolTimerModuleUI(coolTimer);
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