using UnityEngine;

namespace Assets.CustomTimer.TestSlideUpdate
{
    public abstract class TestUpdateTarget_Base : MonoBehaviour
    {
        public int updateOrderIndex;

        private static bool checkExit = false;
        protected virtual void OnEnable()
        {
            TestUpdateManager.Instance.AddTestUpdateTarget(this);
        }

        protected virtual void OnDisable()
        {
            if (checkExit)
            {
                return;
            }
            TestUpdateManager.Instance.RemoveTestUpdateTarget(this);
        }

        private void OnApplicationQuit()
        {
            checkExit = true;
        }



        /// <summary>
        /// 업데이트 함수
        /// </summary>
        /// <param name="deltaTime">델타타임</param>
        public abstract void ActionUpdate(float deltaTime);
    }
}
