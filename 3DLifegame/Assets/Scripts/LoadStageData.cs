using UnityEngine;
using Network;

[CreateAssetMenu(fileName = "LoadStageData", menuName = "3D lifegame/LoadStageData", order = 0)]
public class LoadStageData : ScriptableObject 
{
    [SerializeField]
    private LifeModel _lifeModel = null;

    public LifeModel LifeModel{ get{ return _lifeModel; } }

    private void OnEnable() 
    {
        Reset();    
    }

    public void Copy(LifeModel origin)
    {
        _lifeModel = origin;
    }

    public void Reset()
    {
        _lifeModel = null;
    }
}