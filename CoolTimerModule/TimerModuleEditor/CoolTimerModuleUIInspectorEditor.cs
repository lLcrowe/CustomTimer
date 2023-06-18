using UnityEngine;
using lLCroweTool.TimerSystem;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#pragma warning disable 0618

namespace lLCroweTool.QC.EditorOnly
{
    [CustomEditor(typeof(CoolTimerModuleUI))]
    public class CoolTimerModuleUIInspectorEditor : CustomDataInspecterEditor<CoolTimerModuleUI>
    {
        //쿨타이머필UI
        //쿨타이머반복아이콘
        private CoolTimerModuleUI coolTimerModuleUI;

        

        protected override void InitAddFunc()
        {   
            coolTimerModuleUI = (CoolTimerModuleUI)target;
        }

        protected override bool CheckAutoGenerate(ref string content)
        {
            bool isCheck = false;

            content += "-=CoolTimerModuleUI 필요사항=-\n";

            if (!coolTimerModuleUI.TryGetComponent(out Button button))
            {
                content += "버튼이 없습니다. 직접 버튼을 만들지 말아주시고 우클릭하여 버튼을 생성해주세요\n";
                isCheck = true;
            }
            if (coolTimerModuleUI.coolTimerFillUI == null)
            {
                content += "쿨타이머를 채우는 UI가 없습니다.\n";
                isCheck = true;
            }
            if (coolTimerModuleUI.coolTimerRepeatIcon == null)
            {
                content += "반복 아이콘 게임오브젝트가 없습니다\n";
                isCheck = true;
            }

            return isCheck;
        }

        protected override void AutoGenerateSection()
        {
            coolTimerModuleUI.gameObject.name = "CoolTimerModuleUI";

            GameObject gameObject = null;
            if (coolTimerModuleUI.coolTimerFillUI == null)
            {
                //스킬 쿨타임 차기위해 보여주는 이미지오브젝트
                gameObject = new GameObject();
                gameObject.transform.parent = coolTimerModuleUI.transform;
                gameObject.transform.position = new Vector2(coolTimerModuleUI.transform.position.x + 32, coolTimerModuleUI.transform.position.y
                     + 32);
                gameObject.name = "coolTimerFillUI ImageObject";
                coolTimerModuleUI.coolTimerFillUI = gameObject.AddComponent<Image>();
                coolTimerModuleUI.coolTimerFillUI.TryGetComponent(out RectTransform rectTransform);
                rectTransform.sizeDelta = new Vector2(30, 30);
            }
            if (coolTimerModuleUI.coolTimerRepeatIcon == null)
            {
                //스킬 반복인지 보여주기 위한 이미지 오브젝트
                gameObject = new GameObject();
                gameObject.transform.parent = coolTimerModuleUI.transform;
                gameObject.transform.position = coolTimerModuleUI.transform.position;
                gameObject.name = "coolTimerRepeatIcon ImageObject";
                coolTimerModuleUI.coolTimerRepeatIcon = gameObject.AddComponent<Image>();
                Color color = coolTimerModuleUI.coolTimerRepeatIcon.color;
                color.a = 0.5f;
                coolTimerModuleUI.coolTimerRepeatIcon.color = color;
            }
        }

        protected override void DisplaySection()
        {
            
        }
    }
}
#endif

