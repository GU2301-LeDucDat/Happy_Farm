using Fusion;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public static string Lobby_Name => "Game nong trai";

    [SerializeField]
    private GameObject _listRoom;
    [SerializeField]
    private RoomInfo _roomInfoPrefabs;
    [SerializeField]
    private NetworkRunner _networkRunnerPrefab;
    [SerializeField]
    private NetworkSceneManagerDefault _networkSceneManagerDefault;
    [SerializeField]
    private TMP_InputField _inputNameRoom;
    [SerializeField]
    private TextMeshProUGUI _nameRoom;
    [SerializeField]
    private TextMeshProUGUI _amountPlayer;
    //Display in UI lobby info about the current session
    private SessionInfo currentRoom;

    private void OnEnable()
    {
        FusionManager.SESSION_LIST_UPDATED += UpdateListRoom;
    }
    private void OnDisable()
    {
        FusionManager.SESSION_LIST_UPDATED -= UpdateListRoom;
    }

    private void Start()
    {
        NetworkRunner runner = Instantiate(_networkRunnerPrefab);
        FusionManager.Instance.Init(runner, _networkSceneManagerDefault);
        FusionManager.Instance.JoinLobby(Lobby_Name);
        _nameRoom.text = "";
        _amountPlayer.text = "";
    }

    private void UpdateListRoom(List<SessionInfo> sessionList)
    {
        foreach (Transform room in _listRoom.transform)
        {
            Destroy(room.gameObject);
        }
        for(int i = 0; i < sessionList.Count; i++)
        {
            //This code will instantiate a room has roominfo in list room
            RoomInfo roomInfo = Instantiate(_roomInfoPrefabs, _listRoom.transform);
            //Then set value of the session into room info
            roomInfo.InitRoom(this, sessionList[i]);
        }
        //Set default is the first session
        if(sessionList.Count > 0) 
        {
            SetCurrentRoom(sessionList[0]);
        }
    }

    public void SetCurrentRoom(SessionInfo sessionInfo)
    {
        currentRoom = sessionInfo;
        _nameRoom.text = currentRoom.Name;
        _amountPlayer.text = currentRoom.PlayerCount.ToString();
    }

    public void CreateGame()
    {
        FusionManager.Instance.HostAGame(Lobby_Name, _inputNameRoom.text);
    }

    public void JoinGame()
    {
        FusionManager.Instance.JoinAGame(Lobby_Name, currentRoom.Name);
    }

}
