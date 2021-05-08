using System;

namespace Network.ResponseDto
{
    [Serializable]
    public class RankingLifeModelResponseDto : DtoBase
    {
        public LifeModel[] life_model_list;
    }
}
