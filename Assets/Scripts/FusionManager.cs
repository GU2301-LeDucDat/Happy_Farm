using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct NetworkInputData : INetworkInput
{
    public Vector3 direction;
}

public class FusionManager : ISingleton<FusionManager>
{
    public static Action<List<SessionInfo>> SESSION_LIST_UPDATED { get; set; }

    public NetworkRunner NetworkRunner { get; set; }
    public NetworkSceneManagerDefault NetworkSceneManagerDefault { get; private set; }
    public Dictionary<PlayerRef, NetworkObject> SpawnedCharacters { get; private set; } = new Dictionary<PlayerRef, NetworkObject>();

    public void Init(NetworkRunner networkRunner, NetworkSceneManagerDefault networkSceneManagerDefault)
    {
        Debug.Log("Fusion manager has been init");
        NetworkRunner = networkRunner;
        NetworkSceneManagerDefault = networkSceneManagerDefault;
    }
    public async void JoinLobby(string lobbyName)
    {
        await NetworkRunner.JoinSessionLobby(SessionLobby.ClientServer, lobbyName);
    }

    private async void StartGame(GameMode mode, string lobby, string roomName)
    {
        Debug.Log("Fusion manager start game");
        NetworkRunner.ProvideInput = true;
        NetworkRunner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        StartGameArgs config = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
            CustomLobbyName = lobby,
            Scene = 5,
            SceneManager = NetworkRunner.gameObject.GetComponent<NetworkSceneManagerDefault>(),
        };
        await NetworkRunner.StartGame(config);

    }

    private IEnumerator LoadingGame()
    {
        SceneManager.LoadScene("Loading");
        yield return new WaitForSeconds(10);
    }    


    public void HostAGame(string lobby, string roomName)
    { 
        StartGame(GameMode.Host, lobby, roomName);
    }

    public void JoinAGame(string lobby, string roomName)
    { 
        StartGame(GameMode.Client, lobby, roomName);
    }

    public void ExitGame()
    { 
        NetworkRunner.Shutdown();
    }
}
