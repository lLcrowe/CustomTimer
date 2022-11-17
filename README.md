# TimerModule
Func that call Update events at a specific time

특정 시간에 업데이트 이벤트를 호출하는 시스템



기능 

1. 업데이트를 매니저에서 관리
2. 업데이트할 대상에 대한 시간을 제어

주 모듈

1. TimerModuleManager : 업데이트를 중앙에서 관리해줄 매니저 클래스

2. TimerModule_Base : 타이머모듈들을 베이스 클래스

3. UnityEventTimerModule_Base : 유니티이벤트를 사용하는 모듈들의 베이스 클래스




주로 사용하실 모듈

1. UpdateTimerModule_Base : 상속받아서 업데이트를 작동할수 있도록 해주는 클래스

2. UpdateTimerModule : 유니티이벤트에 등록하여 업데이트를 작동할수 있도록 해주는 클래스

3. CoolTimerModule : 쿨타이머. 특정 시간까지 작동안되게 타이머가 돌아가며 그것에 대한 UI까지 제공.
시작시 이벤트, 쿨타임찰시 이벤트 제공. (UpdateTimerModule_Base를 상속받아서 작동되는 클래스)



https://user-images.githubusercontent.com/44671731/202400614-1bc45307-426b-4cfd-9273-c7efabec8331.mp4


필요시 확장에셋(코드첨부. Extend폴더 확인할것)

-MEC(More Effective Corotine) https://assetstore.unity.com/packages/tools/animation/more-effective-coroutines-pro-68480
