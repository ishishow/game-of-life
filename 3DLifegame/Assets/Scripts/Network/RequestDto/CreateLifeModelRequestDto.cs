using System;

namespace Network.RequestDto
{
    [Serializable]
    public class CreateLifeModelRequestDto : DtoBase
    {
        public string name;

        public int[] map;
    }
}