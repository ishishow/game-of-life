using UnityEngine;

namespace Lifegame
{
    public class CellFactory : Object, IFactory<GameObject>
    {
        public GameObject Create()
        {
            return Instantiate(Resources.Load("Prefabs/Cell") as GameObject);
        }
    }
}