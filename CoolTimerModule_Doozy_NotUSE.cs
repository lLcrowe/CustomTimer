//using System.Collections.Generic;
//using UnityEngine;

//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using MEC;
//using MyBox;

//namespace lLCroweTool
//{
//    [RequireComponent(typeof(UpdateTimerModule))]
//    public class CoolTimerModule_Doozy_NotUSE : CoolTimerModule, IPointerDownHandler
//    {
       

//        ////자식및 자기자신이 가질 컴포넌트
//        //private Button skillButton;//버튼가져오기<--자기 자신
//        //                           //밑에꺼는 수동으로 기입
        
//        //public Image skillIcon;//스킬아이콘<--자기 자식
//        //public Image skillFillUI;//스킬이미지위에 검은 타이머<--자기 자식 
//        //public Image skillRepeatIcon;//스킬반복을 했을시 동작함<--자기 자식

//        //private float animTime;//Doozy UI 애니메이션 작동되는시간초 가져오기
//        ////StartCoolTime 함수에서 초기화시키며 다른클래스 어딘가에 total뭐시기로 가져올수 있는걸로 기억함. 찾아보기

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
//        //private void CreateCoolTimerModuleDoozySetting()
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

//        //    //SetinteractableButton(false);
//        //    Timing.RunCoroutine(WaitAnim(animTime, false));
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
//        //public void SetinteractableButton(bool onOff)
//        //{
//        //    skillButton.interactable = onOff;
//        //}

//        ////쿨타이머 버튼에 해당 스킬데이터를 세팅해주는 함수
//        ////세팅방식 변해서 필요없음
//        ////public void StartSkillCollTimerUISetting(SkillObjectScript skillData)
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
//        //            //StartSkill();//두번 작동되니  바꿈
//        //            StartCoolTime();
//        //        }
//        //    }
//        //}

//        ////애니메이션이 작동되는 동안은 누를수 없게하는 코루틴
//        //IEnumerator<float> WaitAnim(float time, bool onOff)
//        //{
//        //    yield return Timing.WaitForSeconds(time);
//        //    //skillButton.interactable = onOff;
//        //    SetinteractableButton(onOff);
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
