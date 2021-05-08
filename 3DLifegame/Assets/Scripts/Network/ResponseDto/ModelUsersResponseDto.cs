using System;

namespace Network.ResponseDto
{
    [Serializable]
    public class ModelUsersResponseDto : DtoBase
    {
        public LifeModel[] life_model_list;
    }
}
