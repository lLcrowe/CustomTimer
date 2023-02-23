//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using MyBox;

//namespace lLCroweTool
//{
//    public class CoolTimerModule_UI_NotUSE : CoolTimerModule, IPointerDownHandler
//    {  
//        ////자식및 자기자신이 가질 컴포넌트
//        //private Button skillButton;//버튼가져오기<--자기 자신
//        //                           //밑에꺼는 수동으로 기입
//        //public Image skillIcon;//스킬아이콘<--자기 자식
//        //public Image skillFillUI;//스킬이미지위에 검은 타이머<--자기 자식    
//        //public Image skillRepeatIcon;//스킬반복을 했을시 동작함<--자기 자식

//        //private void Awake()
//        //{
//        //    StartSettingCoolTimerModule();
//        //}
       
//        //public override void StartSettingCoolTimerModule()
//        //{
//        //    base.StartSettingCoolTimerModule();

//        //    skillButton = GetComponent<Button>();

//        //    //UI세팅
//        //    if (ReferenceEquals(skillButton, null))
//        //    {
//        //        return;
//        //    }
//        //    skillFillUI.fillAmount = 0;
//        //    skillRepeatIcon.enabled = isRepeat;
//        //    skillButton.onClick.AddListener(delegate { StartSkill(); });
//        //}

//        //[ButtonMethod]
//        ////처음 컴포넌트를 추가 시켯을떄 사용하는 UI세팅함수 
//        //private void CreateCoolTimerModuleUISetting()
//        //{
//        //    gameObject.AddComponent<Button>();

//        //    GameObject go = new GameObject();
//        //    go.name = "skillIcon";
//        //    go.transform.parent = transform;
//        //    go.transform.position = transform.position;
//        //    Image image = skillIcon = go.AddComponent<Image>();
//        //    image.raycastTarget = false;

//        //    go = new GameObject();
//        //    go.name = "skillRepeatIcon";
//        //    go.transform.parent = transform;
//        //    //RectTransform rectTransform = go.AddComponent<RectTransform>();
//        //    //rectTransform.transform.position = transform.position;
//        //    go.transform.position = transform.position;
//        //    image = skillRepeatIcon = go.AddComponent<Image>();
//        //    image.raycastTarget = false;


//        //    go = new GameObject();
//        //    go.name = "skillFillImage";
//        //    go.transform.parent = transform;
//        //    go.transform.position = transform.position;
//        //    image = skillFillUI = go.AddComponent<Image>();
//        //    image.raycastTarget = false;
//        //    //image.color = new Color(0, 0, 0, 0.5f);//검은색 알파값 0.5
//        //    image.color = new Color(255, 255, 255, 0.5f);//흰색 알파값 0.5
//        //    image.type = Image.Type.Filled;
//        //}

//        //public override void StartCoolTime()
//        //{
//        //    base.StartCoolTime();
//        //    timeValue = 0;
//        //    timeUIValue = 0;
//        //    SetinteractableButton(false);
//        //}

//        //public override void UpdateSkillCoolTime()
//        //{
//        //    base.UpdateSkillCoolTime();
//        //    UpdateSkillCoolTimeUI();
//        //}

//        ////스킬UI업데이트
//        //private void UpdateSkillCoolTimeUI()
//        //{
//        //    if (timeUIValue >= 1)
//        //    {
//        //        skillFillUI.fillAmount = 0;
//        //        SetinteractableButton(true);
//        //    }
//        //    skillFillUI.fillAmount = timeValue;
//        //}

//        ////스킬UI 비활성와 활성화시켜주는
//        //private void SetinteractableButton(bool onOff)
//        //{
//        //    skillButton.interactable = onOff;
//        //}

//        ////쿨타이머 버튼에 해당 스킬데이터를 세팅해주는 함수]
//        ////세팅방법 변해서 아직 안씀
//        ////public void StartSkillCollTimerUISetting(UnitSkill skillData)
//        ////{
//        ////    //이미지
//        ////    //쿨타임시간
//        ////    //유니티액션등등
//        ////    //가져와서 세팅

//        ////}
        
//        ////우클릭했을시 반복하는걸 멈추거나 반복하게만듬
//        //public void OnPointerDown(PointerEventData eventData)
//        //{
//        //    if (Input.GetMouseButtonDown(1) && isUseRepeat)
//        //    {
//        //        isRepeat = !isRepeat;
//        //        skillRepeatIcon.enabled = isRepeat;
//        //        if (GetEnableSkill())
//        //        {
//        //            //StartSkill();//두번작동되니 바꿈
//        //            StartCoolTime();
//        //        }
//        //    }
//        //}

//        ////초기화
//        //private void Reset()
//        //{
//        //    //자식들 초기화(삭제-)
//        //    int count = transform.childCount;
//        //    for (int i = 0; i < count; i++)
//        //    {
//        //        //배열중에 삭제라 배열에서 곧장 삭제해버리면 에러남
//        //        //DestroyImmediate는 게임오브젝트만 삭제가능
//        //        DestroyImmediate(transform.GetChild(0).gameObject);
//        //    }
//        //}
//    }
//}
