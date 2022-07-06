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

    //public void TriggerShieldOn()
    //{
    //    hasShield = true;
    //    Debug.Log("Shield on!");

    //    new WaitForSeconds(5f);

    //    hasShield = false;
    //    Debug.Log("Shield off!");
    //}


}
