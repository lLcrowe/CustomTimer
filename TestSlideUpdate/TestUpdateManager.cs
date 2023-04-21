using Assets.CustomTimer.TestSlideUpdate;
using lLCroweTool.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public List<TestUpdateTarget_Base> testUpdateTargetList = new List<TestUpdateTarget_Base> ();
        public float totalDeltaTime = 0;
    }

    private static bool checkInit = false;
    [Min(0)]public int initUpdateSchedulerAmount = 2;

    public List<UpdateScheduler> updateSchedulerList = new List<UpdateScheduler> ();//=>���߿� �迭�� �Ű��ֱ�
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
        for (int i = 0; i < initUpdateSchedulerAmount; i++)
        {
            UpdateScheduler updateScheduler = new UpdateScheduler();
            updateSchedulerList.Add(updateScheduler);
        }
        checkInit = true;
    }

    public void AddTestUpdateTarget(TestUpdateTarget_Base testUpdateTarget)
    {
        InitManager();
        updateSchedulerList[addCheckIndex].testUpdateTargetList.Add (testUpdateTarget);
        testUpdateTarget.updateOrderIndex = addCheckIndex;//���Ž�Ű��
        addCheckIndex = CheckLimit(addCheckIndex, updateSchedulerList.Count);
    }

    public void RemoveTestUpdateTarget(TestUpdateTarget_Base testUpdateTarget)
    {
        InitManager();
        updateSchedulerList[testUpdateTarget.updateOrderIndex].testUpdateTargetList.Remove(testUpdateTarget);
    }
    private static int CheckLimit(int curIndex, int limitIndex)
    {
        curIndex = ++curIndex >= limitIndex ? 0 : curIndex;
        return curIndex;
    }

    private void Update()
    {
        //��ŸŸ�Ӱ���
        int i = 0;
        float deltaTime = Time.deltaTime;
        for (i = 0; i < updateSchedulerList.Count; i++)
        {
            updateSchedulerList[i].totalDeltaTime += deltaTime;
        }

        //�ʱ⼼�� ������
        UpdateScheduler updateScheduler = updateSchedulerList[updateIndex];
        deltaTime = updateScheduler.totalDeltaTime;
        updateScheduler.totalDeltaTime = 0;
        List<TestUpdateTarget_Base> updateTargetList = updateScheduler.testUpdateTargetList;

        //������Ʈ����
        for (i = 0; i < updateTargetList.Count; i++)
        {
            updateTargetList[i].ActionUpdate(deltaTime);
        }

        //�ε��� üũ
        updateIndex = CheckLimit(updateIndex, updateSchedulerList.Count);
    }

}
