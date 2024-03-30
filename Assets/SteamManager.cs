using UnityEngine;
using UnityEngine.Events;
using Steamworks;

public class SteamManager : MonoBehaviour
{
    public uint appId;
    public UnityEvent OnSteamFailed;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        try
        {
            SteamClient.Init(appId, true);
            Debug.Log("Steam is up and running!");
        }
        catch(System.Exception e)
        {
            Debug.Log(e.Message);
            OnSteamFailed.Invoke();
        }
    }

    private void OnApplicationQuit()
    {
        try
        {
            Steamworks.SteamClient.Shutdown();

        }
        catch
        {

        }
    }
}
