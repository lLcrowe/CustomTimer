using UnityEngine;

namespace lLCroweTool.TimerSystem
{
    /// <summary>
    /// 타이머모듈 요소
    /// </summary>
    [System.Serializable]
    public struct TimerModule_Element
    {
        //컴포넌트식이 아닌 요소로 붙착시킴
        [Header("-=1. 몇초마다 이벤트를 발생할것인가.")]
        //몇초에 리셋될건지 해주는 타이머
        [SerializeField] private float timer;//작동될 타이머 : 0.02~ 0.05 정도

        [Header("-=2. 독립적인 타이머인가?")]
        //월드타이머와 별개로 돌아간건지
        public bool indieTimer;

        //기존의 돌아가는 타이머
        private float time;

        //4,2,4,4

        public TimerModule_Element(in float timer, in bool indieTimer = false)
        {
            this.timer = timer;
            this.indieTimer = indieTimer;
            time = -1;
        }

        /// <summary>
        /// 타이머모듈의 타이머체크
        /// </summary>
        /// <returns>작동할 시간이 됫는지 여부</returns>
        public bool CheckTimer()
        {
            //시간체크
            bool check = CheckTimer(this);//작동할시간이 됫는지 여부
            if (check)
            {
                ResetTime();//타이머시간 리셋
            }
            return check;
        }

        private static float timerValue;
        /// <summary>
        /// 작동할 시간이 됫는지 체크해주는 함수(TimerModule_Element용)
        /// </summary>
        ///<param name="timerModule_Element">타이머모듈_요소</param>
        /// <returns>작동할 시간이 됫는지 여부</returns>
        private static bool CheckTimer(in TimerModule_Element timerModule_Element)
        {
            //20221113제작//공통로직 합동
            //20221114테스트진행 GC문제있음
            //202216문제는 Action같은 Delegate문제. 여긴상관없음
            //20230220데이터부분을 분리
            //20240328Pause부분을 중앙에서 관리하는대상에게로만 변경

            timerValue = CalTimerValue(timerModule_Element.GetTimer(), timerModule_Element.GetTime(), timerModule_Element.indieTimer, 1);
            return Time.time > timerValue;
        }

        /// <summary>
        /// 작동할 시간이 됫는지 체크해주는 함수(TimerModule_Base용)
        /// </summary>
        ///<param name="timerModule_Element">타이머모듈_요소</param>
        ///<param name="scale">시간스케일값</param>
        /// <returns>작동할 시간이 됫는지 여부</returns>
        public bool CheckTimer(in float scale)
        {   
            timerValue = CalTimerValue(timer, time, indieTimer, scale);
            return Time.time > timerValue;
        }

        /// <summary>
        /// 지정된 시간을 계산해주는 함수
        /// </summary>
        /// <param name="timer">지정된 타이머</param>
        /// <param name="time">저장된 시간</param>
        /// <param name="indieTimer">독립된 타이머여부</param>
        /// <param name="timerScale">시간 스케일</param>
        /// <returns>계산된 타임밸류</returns>
        private static float CalTimerValue(in float timer, in float time, in bool indieTimer, in float timerScale)
        {
            float tempValue = indieTimer ? timer + time : (timer * timerScale) + time;
            return tempValue;
        }

        /// <summary>
        /// 타이머 세팅(시간초)
        /// </summary>
        /// <param name="value">시간</param>
        public void SetTimer(in float value)
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
    }
}
