using UnityEngine;

namespace lLCroweTool.TimerSystem
{
    /// <summary>
    /// 지연모듈_요소
    /// 지연을 주기 위한 모듈
    /// </summary>
    [System.Serializable]
    public struct DelayModule_Element
    {
        [Min(0)] public float delayTimer;
        private float time;

        /// <summary>
        /// 지연모듈의 타이머체크
        /// </summary>
        /// <returns>지연시간이 다됫는가</returns>
        public bool CheckDelay()
        {
            return time + delayTimer < Time.time;
        }

        /// <summary>
        /// 리셋
        /// </summary>
        public void ResetTimer()
        {
            time = Time.time;
        }

        /// <summary>
        /// 타이머세팅
        /// </summary>
        /// <param name="timer">타임</param>
        public void SetTimer(float timer)
        {
            delayTimer = timer;
        }
    }
}