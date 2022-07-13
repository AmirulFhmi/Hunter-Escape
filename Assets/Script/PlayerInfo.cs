using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerInfo : MonoBehaviour
{
    /// <summary>
    /// This script for getting info from player such as player speed, player collider, etc
    /// </summary>

    [SerializeField] GameObject player;
    ThirdPersonController tpController;
    public bool hasShield = false;
    float oldMoveSpeed;
    float oldSprintSpeed;

    //for activating magnet
    GameObject magnetPosition;
    bool isMagnet = false;
    float pullSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        tpController = player.GetComponent<ThirdPersonController>();
        oldMoveSpeed = tpController.MoveSpeed;
        oldSprintSpeed = tpController.SprintSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnet)
        {
            //transform.position = Vector3.Lerp(transform.position, magnetPosition.transform.position, pullSpeed * Time.deltaTime);
            player.transform.position = Vector3.MoveTowards(player.transform.position, magnetPosition.transform.position, pullSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        
        
    }

    public void ChangePlayerSpeed(float newMoveSpeed, float newSprintSpeed)
    {
        tpController.MoveSpeed = newMoveSpeed;
        tpController.SprintSpeed = newSprintSpeed;
    }

    public void ReturnPlayerSpeed()
    {
        tpController.MoveSpeed = oldMoveSpeed;
        tpController.SprintSpeed = oldSprintSpeed;
    }

    public void PullPlayer(GameObject p, float speed)
    {
        magnetPosition = p;
        Debug.Log(magnetPosition);
        pullSpeed = speed;
        tpController.enabled = false;
        isMagnet = true;
    }

    public void ReleasePlayer()
    {
        isMagnet = false;
        tpController.enabled = true;
    }

    //public void TriggerShieldOn()
    //{
    //    hasShield = true;
    //    Debug.Log("Shield on!");

    //    new WaitForSeconds(5f);

    //    hasShield = false;
    //    Debug.Log("Shield off!");
    //}


}
