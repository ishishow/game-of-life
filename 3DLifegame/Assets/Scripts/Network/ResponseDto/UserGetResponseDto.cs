using System;

namespace Network.ResponseDto
{
    [Serializable]
    public class UserGetResponseDto : DtoBase
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        /// <value>ユーザーID</value>
        public string id;
        
        /// <summary>
        /// ユーザ名
        /// </summary>
        /// <value>ユーザ名</value>
        public string name;
    }
}
