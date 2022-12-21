using System.Collections;
using UnityEngine;

namespace lLCroweTool.TimerSystem
{
    public abstract class TimerModule_Base : MonoBehaviour
    {
        //20221113
        //구조변경//타이머모듈들을 더 슬림하게 제작
        //20221116
        //구조변경//통합완료

        [Header("-=1. 몇초마다 이벤트를 발생할것인가.")]
        //몇초에 리셋될건지 해주는 타이머
        [SerializeField] protected float timer = 0;//작동될 타이머 : 0.02~ 0.05 정도

        [Header("-=2. 독립적인 타이머인가?")]
        //월드타이머와 별개로 돌아간건지
        public bool indieTimer = false;

        //기존의 돌아가는 타이머
        [HideInInspector][SerializeField]
        private float time = -1;


        ////컴포넌트를 켯을시
        //RequireComponent 컴포넌트사용시 해당 컴포넌트 오브젝트가 만들어지자마자
        //onenable이 작동이 되버림//코드활성화시 체크할것

        /// <summary>
        /// 타임모듈매니저에 현 클래스를 등록하는 함수//앱작동시
        /// </summary>
        protected abstract void ConnectTimerModuleManager();

        /// <summary>
        /// 타임모듈매니저에 현 클래스를 삭제하는 함수//앱작동시
        /// </summary>
        protected abstract void DeconnectTimerModuleManager();

        /// <summary>
        /// 업데이트할 기능을 명시하는 함수//매니저에서 호출//활성화됫을시 작동
        /// </summary>
        public abstract void UpdateTimerModuleFunc();

        protected virtual void Awake()
        {
            if (time == -1)
            {
                ResetTime();
                //time = Time.time;
            }
        }

        private void OnEnable()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            ConnectTimerModuleManager();
        }

        private void OnDisable()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            DeconnectTimerModuleManager();
        }


        /// <summary>
        /// 타이머 세팅(시간초)
        /// </summary>
        /// <param name="value">시간</param>
        public void SetTimer(float value)
        {
            timer = value;
        }

        /// <summary>
        /// 세팅한 타이머를 가져오는 함수
        /// </summary>
        /// <returns>세팅된 타이머</returns>
        public float GetTimer()
        {
            return timer;
        }

        /// <summary>
        /// 현재 저장된 시간을 가져오기
        /// </summary>
        /// <returns></returns>
        public float GetTime()
        {
            return time;
        }

        /// <summary>
        /// 시간을 현재 시간으로 초기화
        /// </summary>
        public void ResetTime()
        {
            time = Time.time;
        }

#if UNITY_EDITOR
        /// <summary>
        ///타이머 디버그용//테스트할때 쓴다.
        /// </summary>
        public void TimerDebug()
        {
            Debug.Log(gameObject.name + " : 타이머이벤트가 호출되었습니다.");
        }
 #endif
    }
}