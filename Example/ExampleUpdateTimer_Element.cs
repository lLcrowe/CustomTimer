using UnityEngine;
using lLCroweTool.TimerSystem;

namespace lLCroweTool.TimerSystem.Sample
{
    public class ExampleUpdateTimer_Element : MonoBehaviour
    {
        public TimerModule_Element timerModule;
      

        // Update is called once per frame
        void Update()
        {
            if (!timerModule.CheckTimer())
            {
                return;
            }

            Debug.Log("Check");
        }
    }
}