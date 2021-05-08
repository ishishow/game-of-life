using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Network.ResponseDto
{
    /// <summary>
    /// レスポンスがない通信用に使用するDto
    /// </summary>
    public class NoneResponseDto : DtoBase
    {
        public override string ToJson()
        {
            Debug.LogError("レスポンスデータが存在しないリクエストです");
            return null;
        }
    }   
}
