using System.Collections;
using UnityEngine;

namespace Assets.CustomTimer.TestSlideUpdate
{
    public class TestUpdateMove : TestUpdateTarget_Base
    {
        public float rotateSpeed;

        private float check;
        private Transform tr;
        private void Awake()
        {
            tr = transform;
        }

        //업데이트
        public override void ActionUpdate(float deltaTime)
        {
            check += rotateSpeed * deltaTime;
            tr.rotation = Quaternion.AngleAxis(check, Vector3.forward);
        }
    }
}