using UnityEngine;

public static class AuthtokenManager
{
    public static bool CanLoad { get { return PlayerPrefs.HasKey("Authtoken"); } }

    public static void Save(string token)
    {
        PlayerPrefs.SetString("Authtoken", token);
    }

    public static string Load()
    {
        if(PlayerPrefs.HasKey("Authtoken"))
        {
            return PlayerPrefs.GetString("Authtoken");
        }
        Debug.LogError("save data is not found");
        return null;
    }
}