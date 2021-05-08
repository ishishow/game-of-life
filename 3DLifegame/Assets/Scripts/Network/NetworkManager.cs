using System.Collections;
using Network;
using UnityEngine;

public class NetworkManager : SingletonMonoBehaviour<NetworkManager>
{
    private const string ServerAddress = "http://lifegame-3d.herokuapp.com"; //ここが変わる
    private WebRequest _webRequest = new WebRequest();

    public WebRequest WebRequest{ get { return _webRequest; } } 

    private void Awake()
    {
        // サーバーアドレスを設定する
        _webRequest.SetServerAddress(ServerAddress);
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// メソッドの取得
    /// </summary>
    /// <param name="type">メソッドタイプ</param>
    /// <returns></returns>
    public string GetMethod(MethodType type)
    {
        switch (type)
        {
            case MethodType.PostUserCreate:
                return "/user/create";

            case MethodType.GetUser:
                return "/user/get"; 

            case MethodType.PostModelCreate:
                return "/model/create";
            
            case MethodType.GetModel:
                return "/model/get";
            
//            case MethodType.PostModelFavorite:
//                return "/model/favorite";
            
            case MethodType.GetRanking:
                return "/model/ranking";

            case MethodType.GetModelUser:
                return "/model/users";
        }

        return null;
    }
}
