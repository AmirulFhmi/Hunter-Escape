using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualifyFinalLevel : MonoBehaviour
{
    int slot = 1;
    GameStartManager gameManager;
    bool isMany = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameStartManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (slot == 4)
        {
            //panggil function tukar scene kat game manager
            //kena ada wait for seconds sikit
            //function tu kena ada paramter sama ada player ramai or tak
            //if player ramai masuk scene next, else scene last
            //

        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
            isMany = true;
                if (slot <= 3)
                {
                    //save score

                    //qualify to next level
                    Debug.Log("Your position is " + slot);
                    slot++;
                }
                else
                {
                    //save score
                    //not qualify
                    Debug.Log("Your position is " + slot);
                    slot++;
                }
            }
    }
}
