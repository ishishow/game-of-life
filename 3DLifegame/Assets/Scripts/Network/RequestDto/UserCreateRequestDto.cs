using System;

namespace Network.RequestDto
{
    [Serializable]
    public class UserCreateRequestDto : DtoBase
    {
        public string name;
    }
}