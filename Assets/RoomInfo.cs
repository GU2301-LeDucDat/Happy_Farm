using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfo : MonoBehaviour
{
    [SerializeField]
    private Image _imageMap;
    [SerializeField]
    private TextMeshProUGUI _nameRoom;
    [SerializeField]
    private TextMeshProUGUI _amountPlayer;

    private LobbyController _lobbyController;
    private SessionInfo _sessionInfo;

    public void InitRoom(LobbyController lobbyController, SessionInfo sessionInfo)
    {
        _lobbyController = lobbyController;
        _sessionInfo = sessionInfo;
        _nameRoom.text = _sessionInfo.Name.ToString();
        _amountPlayer.text = _sessionInfo.PlayerCount.ToString();
    }

    public void Selected()
    {
        _lobbyController.SetCurrentRoom(_sessionInfo);
    }
}
