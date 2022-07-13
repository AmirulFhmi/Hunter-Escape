using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Magnet : MonoBehaviour
{

    public bool isTrue = false;
    public GameObject magnetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrue)
        {
            transform.position = Vector3.MoveTowards(transform.position, magnetPosition.transform.position, 5f * Time.deltaTime);

        }
    }
}
