using lLCroweTool.TimerSystem;

namespace lLCroweTool.TimerSystem.Sample
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