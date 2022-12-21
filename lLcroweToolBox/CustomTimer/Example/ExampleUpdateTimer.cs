using System.Collections;
using UnityEngine;

namespace lLCroweTool.TimerSystem
{
    public class ExampleUpdateTimer : UpdateTimerModule_Base
    {
        public int i;

        
        public override void UpdateTimerModuleFunc()
        {
            i++;
        }
    }
}