using System;

namespace Network
{
    [Serializable]
    public class User : DtoBase
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

        /// <summary>
        /// 認証トークン
        /// </summary>
        /// <value>認証トークン</value>
        public string auth_token;
    }
}
