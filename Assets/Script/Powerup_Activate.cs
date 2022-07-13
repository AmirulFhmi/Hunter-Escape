using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Activate : MonoBehaviour
{
    /// <summary>
    /// This script for trigger powerup when player hit the object
    /// Can be used generally for any powerup
    /// </summary>

    [SerializeField] private GameObject powerupRange;
    [SerializeField] public GameObject player;
    MeshRenderer material;

    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerupRange.SetActive(true);
            player = other.gameObject;
            material.enabled = false;
        }
    }
}
