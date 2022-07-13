using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnecttoServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public static void OnClickConnect()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        Debug.Log("connecting..");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        SceneManager.LoadScene("Main Menu");
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("SelectCharacter");
        //PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entering the lobby");
    }
}
