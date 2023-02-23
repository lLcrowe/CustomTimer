using lLCroweTool.SkillSystem;
using lLCroweTool.SlotSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace lLCroweTool.TimerSystem
{   
    public class SkillSlotUISlotCard : SlotUICard_Base
    {
        //스킬슬롯을 실시간으로 바꾸기위한 기능을 가짐//컴포넌트형식

        //20230223제작
        //SkillSlotUI에 연동된 슬롯베이스를 상속분리
        //SkillSlotUI는 CoolTimerUI쪽에 상속처리 후
        //현클래스에 기능조합중관련해서 분리
        //플레이어스킬툴바UI뷰와 체크

        //이컴포넌트는 원래 스킬슬롯UI를 상속받았음//구조체크하기

        private SkillSlotUI targetSkillSlotUI;//타겟이될 스킬슬롯UI

        protected override void Awake()
        {
            base.Awake();

            InitSlot(this);
            isUseDragSlotAddOnActionFunc = true;
            slotType = SlotType.SkillSlotUI;
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
            SkillSlot tempSkillSlot = skillSlot;
            int tempIndex = GetButtonIndex();

            SetSkillSlotUI(PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().GetSkillSlot(), PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().GetButtonIndex());
            PlayerSkillToolBarUIView.Instance.GetDragSkillSlotUI().SetSkillSlotUI(tempSkillSlot, tempIndex);
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
            if (!isExistSkillSlot && slotData == null)
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
            if (!isExistSkillSlot)
            {
                return;
            }
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.OffText();
            PlayerSkillToolBarUIView.Instance.skillToolBarToolTip.ClearText();
        }
    }
}
