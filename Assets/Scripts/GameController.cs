using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    public Transform[] SpawnPoint = null;

    private void Awake()
    {
        int i = 0;
        i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        GameObject go = PhotonNetwork.Instantiate("Bulldog", SpawnPoint[i].position, SpawnPoint[i].rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
