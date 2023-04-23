using Assets.CustomTimer.TestSlideUpdate;
using lLCroweTool.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class TestUpdateManager : MonoBehaviourSingleton<TestUpdateManager>
{
    //테스트가 좀 많이 할듯한데 일단은
    //나중에 기존시스템과 연동할듯한데 이것만 따로 테스트해서 체크하기


    //기존거는
    //1. 타이머로 업데이트할지 말지
    //2. 일정수량만 업데이트 ex) 4000개씩 업데이트하자 0~4000, 4000~8000
    //둘중하나

    //이번에 새로 만드는건
    //일정수량쪽에서
    //일정수량을 파이프만큼 나누어서 집어넣는 방법

    //음...




    [System.Serializable]
    public class UpdateScheduler
    {
        private List<TestUpdateTarget_Base> testUpdateTargetList = new List<TestUpdateTarget_Base> ();
        private TestUpdateTarget_Base[] testUpdateTargetArray = new TestUpdateTarget_Base[0];

        public float totalDeltaTime = 0;

        public TestUpdateTarget_Base[] TestUpdateTargetArray
        {
            get => testUpdateTargetArray;
        }

        public void Add(TestUpdateTarget_Base target)
        {
            testUpdateTargetList.Add (target);
            testUpdateTargetArray = testUpdateTargetList.ToArray();
        }
        public void Remove(TestUpdateTarget_Base target)
        {
            testUpdateTargetList.Remove(target);
            testUpdateTargetArray = testUpdateTargetList.ToArray();
        }

    }

    private static bool checkInit = false;
    [Min(0)]public int initUpdateSchedulerAmount = 2;

    public UpdateScheduler[] updateSchedulerArray = new UpdateScheduler[0];//=>나중에 배열로 옮겨주기
    public int addCheckIndex = 0;
    public int updateIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        InitManager();
    }

    private void InitManager()
    {
        if (checkInit)
        {
            return;
        }

        updateSchedulerArray = new UpdateScheduler[initUpdateSchedulerAmount];
        for (int i = 0; i < initUpdateSchedulerAmount; i++)
        {
            UpdateScheduler updateScheduler = new UpdateScheduler();
            updateSchedulerArray[i] = updateScheduler;
        }
        checkInit = true;
    }

    public void AddTestUpdateTarget(TestUpdateTarget_Base testUpdateTarget)
    {
        InitManager();
        updateSchedulerArray[addCheckIndex].Add (testUpdateTarget);
        testUpdateTarget.updateOrderIndex = addCheckIndex;//갱신시키기
        addCheckIndex = CheckLimit(addCheckIndex, updateSchedulerArray.Length);
    }

    public void RemoveTestUpdateTarget(TestUpdateTarget_Base testUpdateTarget)
    {
        InitManager();
        updateSchedulerArray[testUpdateTarget.updateOrderIndex].Remove(testUpdateTarget);
    }
    private static int CheckLimit(int curIndex, int limitIndex)
    {
        curIndex = ++curIndex >= limitIndex ? 0 : curIndex;
        return curIndex;
    }

    private int i = 0;
    private void Update()
    {
        //델타타임갱신
        float deltaTime = Time.deltaTime;
        for (i = 0; i < updateSchedulerArray.Length; i++)
        {
            updateSchedulerArray[i].totalDeltaTime += deltaTime;
        }

        //초기세팅 가져옴
        UpdateScheduler updateScheduler = updateSchedulerArray[updateIndex];
        float totalDeltaTime = updateScheduler.totalDeltaTime;
        updateScheduler.totalDeltaTime = 0;
        TestUpdateTarget_Base[] updateTargetArray = updateScheduler.TestUpdateTargetArray;

        //업데이트시작
        for (i = 0; i < updateTargetArray.Length; i++)
        {
            updateTargetArray[i].ActionUpdate(totalDeltaTime);
        }

        //인덱스 체크
        updateIndex = CheckLimit(updateIndex, updateSchedulerArray.Length);
    }

}
