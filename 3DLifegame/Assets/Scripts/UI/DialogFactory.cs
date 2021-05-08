using UnityEngine;

namespace UI
{
    public class DialogFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/Dialog") as GameObject);
        }
    }
}