using Assets.CustomTimer.TestSlideUpdate;
using lLCroweTool.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class TestUpdateManager : MonoBehaviourSingleton<TestUpdateManager>
{
    //�׽�Ʈ�� �� ���� �ҵ��ѵ� �ϴ���
    //���߿� �����ý��۰� �����ҵ��ѵ� �̰͸� ���� �׽�Ʈ�ؼ� üũ�ϱ�


    //�����Ŵ�
    //1. Ÿ�̸ӷ� ������Ʈ���� ����
    //2. ���������� ������Ʈ ex) 4000���� ������Ʈ���� 0~4000, 4000~8000
    //�����ϳ�

    //�̹��� ���� ����°�
    //���������ʿ���
    //���������� ��������ŭ ����� ����ִ� ���

    //��...




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

    public UpdateScheduler[] updateSchedulerArray = new UpdateScheduler[0];//=>���߿� �迭�� �Ű��ֱ�
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
        testUpdateTarget.updateOrderIndex = addCheckIndex;//���Ž�Ű��
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
        //��ŸŸ�Ӱ���
        float deltaTime = Time.deltaTime;
        for (i = 0; i < updateSchedulerArray.Length; i++)
        {
            updateSchedulerArray[i].totalDeltaTime += deltaTime;
        }

        //�ʱ⼼�� ������
        UpdateScheduler updateScheduler = updateSchedulerArray[updateIndex];
        float totalDeltaTime = updateScheduler.totalDeltaTime;
        updateScheduler.totalDeltaTime = 0;
        TestUpdateTarget_Base[] updateTargetArray = updateScheduler.TestUpdateTargetArray;

        //������Ʈ����
        for (i = 0; i < updateTargetArray.Length; i++)
        {
            updateTargetArray[i].ActionUpdate(totalDeltaTime);
        }

        //�ε��� üũ
        updateIndex = CheckLimit(updateIndex, updateSchedulerArray.Length);
    }

}
