using UnityEngine;
using UnityEngine.Assertions;

namespace Network
{
    /// <summary>
    /// Dtoのベースクラス
    /// Jsonにパースできることを保証する
    /// </summary>
    public class DtoBase
    {
        public virtual string ToJson()
        {
            Assert.IsTrue(GetType().IsSerializable);
            return JsonUtility.ToJson(this);
        }
    }
}
