using UnityEngine.Events;

namespace lLCroweTool
{
    public class lLcroweUtil
    {
        /// <summary>
        /// 유니티이벤트를 체크하여 없으면 집어넣는 함수
        /// </summary>
        /// <param name="unityEvent">유니티이벤트</param>
        public static void GetAddUnitEvent(UnityEvent unityEvent)
        {
            //if (unityEvent == null)
            if (ReferenceEquals(unityEvent, null))
            {
                unityEvent = new UnityEvent();
            }
        }
    }
}
