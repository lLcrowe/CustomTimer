using UnityEngine;
using lLCroweTool.TimerSystem;

namespace lLCroweTool.TimerSystem.Sample
{
    public class ExampleCoolTimer_Element : MonoBehaviour
    {
        public CoolTimerModule_Element coolTimer = new CoolTimerModule_Element();

        // Update is called once per frame
        void Update()
        {
            CoolTimerModule_Element.UpdateCoolTimer(coolTimer);
        }
    }
}