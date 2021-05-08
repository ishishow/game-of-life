using System;

namespace Network
{
    [Serializable]
    public class LifeModel : DtoBase
    {
        /// <summary>
        /// モデルID
        /// </summary>
        /// <value>モデルID</value>
        public string id;

        public User user;

        /// <summary>
        /// モデル名
        /// </summary>
        /// <value>モデル名</value>
        public string name;

        /// <summary>
        /// マップ
        /// </summary>
        /// <value>マップ</value>
        public string map;

        /// <summary>
        /// いいね
        /// </summary>
        /// <value>いいね</value>
        public int favorite;
    }
}