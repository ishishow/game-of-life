using UnityEngine;

namespace UI
{
    public class LifemodelNodeFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/LifemodelNode") as GameObject);
        }
    }
}