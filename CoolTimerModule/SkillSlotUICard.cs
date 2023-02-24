using lLCroweTool.SkillSystem;
using lLCroweTool.SlotSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace lLCroweTool.TimerSystem
{   
    public class SkillSlotUICard : SlotUICard
    {
        //스킬슬롯을 실시간으로 바꾸기위한 기능을 가짐//컴포넌트형식

        //20230223제작
        //SkillSlotUI에 연동된 슬롯베이스를 상속분리
        //SkillSlotUI는 CoolTimerUI쪽에 상속처리 후
        //현클래스에 기능조합중관련해서 분리
        //플레이어스킬툴바UI뷰와 체크

        //이컴포넌트는 원래 스킬슬롯UI이였고 CoolTimerUI를 상속받았음
        //구조체크하기

        //신규구조
        //신버전) MonoBehavior => SlotUICard_Base => SkillSlotUISlotCard 
        //신버전) MonoBehavior => UpdateBase => CoolTimerUI => SkillSlotUI(완)




        //구버전) MonoBehavior => SlotUICard_Base => CoolTimerUI => SkillSlotUI


        //제대로 쓸려면 데이터를 집어넣어줘야될듯한데
        //따로 함수들을 뽑아버림
        //몇가지 기능 체크후 스왑기능 구현하자


        //20230224//슬롯베이스관련해서 메커니즘관련한 기능들을 완전히 분할시키자
        //이상태로 해봣자 꼬여버린다

        //무엇을 할것인가
        //스킬슬롯간의 위치교환을 위한 슬롯기능
        //스킬스택이라든가 스킬데이터는 스킬슬롯 UI에 존재함

        //그럼 필요한것은 스킬슬롯간의 위치교환을 위한 슬롯베이스 기능인데
        //뭉터기로 되있음//그렇다고 너무분할시켜봣자 성능, 메모리 둘다 안좋음
        //기능부분만 따로 빼버리자
        //그럼 어디부분에서 문제인가하면 objectDescription부분에서 데이터설정관련된부분이 문제이다
        //해당부분은 데이터세팅, 데이터세팅으로인한 SlotCount부분
        //교환부분은 문제가 없다.//교환부분만 따로 빼버리는게 맞다

        //SlotUICard => 기존의 시스템을 그대로 두고 가버리기
        //SlotUICard_Base => 교환부분 메커니즘만 가져가기

        //그럼 UI가 변동된거까지는 완료인데//슬롯카드에있는 데이터가 변동이 안됫을뿐
        //변동할필요가 없지..?//는 이미지를 보여줘야해서 변동관련 필요함


        private SkillSlotUI targetSkillSlotUI;//타겟이될 스킬슬롯UI//해당UI와 SkillSlot의 데이터를 가져와서 뿌리기

        protected override void Awake()
        {
            base.Awake();

            InitSlot(this);
            isUseDragSlotAddOnActionFunc = true;
            slotType = SlotType.SkillSlotUI;

            targetSkillSlotUI = GetComponent<SkillSlotUI>();
        }

        /// <summary>
        /// 스킬슬롯스택 보여주는 함수
        /// </summary>
        /// <param name="cashStackAmount">스택수량</param>
        public void ShowSkillSlotStack(int cashStackAmount)
        {
            countTextObject.text = cashStackAmount.ToString();
        }

        /// <summary>
        /// 텍스트오브젝트 활성화기능관련 함수
        /// </summary>
        /// <param name="isShow">보여줄지</param>
        public void ActiveTextObject(bool isShow)
        {
            countTextObject.gameObject.SetActive(isShow);
            countImageObject.gameObject.SetActive(isShow);
        }
        protected override void BeginDragAddOnActionFunc()
        {
            //SkillSlotUI가져감
            //PlayerSkillToolBarUIView.Instance.SetDragSkillSlotUI(this);
            DragSlotUICard.Instance.SetDragComponent(this);
        }

        protected override void EndDragAddOnActionFunc()
        {
            //PlayerSkillToolBarUIView.Instance.SetDragSkillSlotUI(null);
            DragSlotUICard.Instance.SetDragComponent(null);
        }

        protected override void OnDropCurSlotAddOnActionFunc()
        {
            //테스트좀 해봐야알겠음
            //SkillSlot tempSkillSlot = skillSlot;
            //int tempIndex = GetButtonIndex();
            //슬롯을 스왑
            SkillSlotUICard skillSlotUICardA = DragSlotUICard.Instance.GetDragComponent() as SkillSlotUICard;
            SkillSlotUICard skillSlotUICardB = this;

            //스킬슬롯UI내용물인 스킬슬롯을 변경//변경한 스킬슬롯을 스킬슬롯UI에 적용
            SkillSlotUI.SwapSkillSlotUI(skillSlotUICardA.targetSkillSlotUI, skillSlotUICardB.targetSkillSlotUI);



            //스킬슬롯UICard 데이터 재세팅
            



            //여긴데이터세팅//확인하고 지우기
            //SetSkillSlotUI(PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().GetSkillSlot(), PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().GetButtonIndex());
            //PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().SetSkillSlotUI(tempSkillSlot, tempIndex);
        }


        protected override void OnDropDragSlotAddOnActionFunc()
        {
            //스킬슬롯UI 슬롯을 변경시키면 해당되는 스킬슬롯데이터를 변경해야함
            //해당 스킬슬롯을 리셋후 변경했던 슬롯데이터를 집어넣음
            //SkillManager.Instance.ResetSkillSlot(skillSlot);
            //skillSlot.skillData = (SkillObjectScript)slotData;

            ////스킬데이터가 있으면 초기화시킴
            //if (!ReferenceEquals(skillSlot.skillData, null))
            //{
            //    SkillManager.Instance.InitSkillSlot(skillSlot);
            //    //스택여부 체크
            //    if (skillSlot.skillData.isUseStack)
            //    {
            //        isUseTextObject = true;
            //        stackAmount = skillSlot.GetStackCurNum();
            //        //skillSlot.SetStackCurNum(skillSlot.GetStackCurNum());
            //    }
            //    else
            //    {
            //        isUseTextObject = false;
            //        stackAmount = 0;
            //    }
            //    ShowText(stackAmount, true);
            //}
        }

        protected override void OnPointerEnterActionFunc()
        {
            //스킬데이터가 비어있지않으면
            if (targetSkillSlotUI.GetIsExistSkillSlot() == false && slotData == null)
            {
                return;
            }

            //툴팁보여주기
            //툴바에 장착된 툴팁이 나아보임
            SkillObjectScript _skillData = (SkillObjectScript)slotData;
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.MoveToolTip(transform);
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.ShowText(_skillData.objectName, _skillData.objectShortDescription, _skillData.objectSprite);
        }
        protected override void OnPointerExitActionFunc()
        {
            if (targetSkillSlotUI.GetIsExistSkillSlot() == false)
            {
                return;
            }
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.OffText();
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.ClearText();
        }
    }
}
