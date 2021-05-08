using System;

namespace Network.ResponseDto
{
    [Serializable]
    public class GetLifeModelResponseDto : DtoBase
    {
        public LifeModel[] life_model;

    }
}
