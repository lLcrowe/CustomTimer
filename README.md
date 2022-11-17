# TimerModule
Func that call Update events at a specific time

특정 시간에 업데이트 이벤트를 호출하는 시스템



기능 

1. 업데이트를 중앙에서 관리
2. 업데이트할 대상에 대한 시간을 조종




1. UpdateTimerModule_Base : 상속받아서 업데이트를 작동할수 있도록 해주는 클래스

2. UpdateTimerModule : 유니티이벤트에 등록하여 업데이트를 작동할수 있도록 해주는 클래스

3. CoolTimerModule : 쿨타이머. UpdateTimerModule_Base를 상속받아서 작동되는 클래스.



















필요시 확장에셋

-MEC(More Effective Corotine) https://assetstore.unity.com/packages/tools/animation/more-effective-coroutines-pro-68480
