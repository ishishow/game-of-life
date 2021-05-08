using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    public static T Instance
    {
        get 
        {
            if(_instance == null)
            {
                _instance = (T)FindObjectOfType (typeof(T));
            }
            return _instance;
        }
    }

	protected void Awake()
	{
		CheckInstance();
	}

	protected bool CheckInstance()
	{
		if(this == Instance)
        {
            return true;
        }
		Destroy(this);
		return false;
	}
}