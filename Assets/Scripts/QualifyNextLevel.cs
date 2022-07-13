using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualifyNextLevel : MonoBehaviour
{
    int slot = 0;
    GameStartManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameStartManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
