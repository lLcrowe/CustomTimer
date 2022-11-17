using UnityEngine;
using System.Collections;

namespace lLCroweTool
{
    [CreateAssetMenu(fileName = "New ObjectDeScriptionData", menuName = "lLcroweTool/New ObjectDeScriptionData")]
    public abstract class ObjectDeScription_Base : ScriptableObject
    {
        //ObjectDeScription Data
        //유닛은 다오브젝트로 칭함 => 20191221
        //오브젝트해석기 및 설명용
        public Sprite objectSprite;//오브젝트의 아이콘 이미지
        [Space]
        public string objectName;//오브젝트의 이름
        //[TextArea]//너무크다
        [Multiline]
        public string objectShortDescription;//오브젝트의 짧은설명
        [TextArea]
        public string objectDescription;//오브젝트의 설명

    }
}
