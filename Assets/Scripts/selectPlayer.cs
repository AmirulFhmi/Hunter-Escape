using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectPlayer : MonoBehaviour
{
    public GameObject[] characters;
    public static int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        characters[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCharacter()
    {
        
        characters[i].SetActive(false);
        if (i < characters.Length-1)
            i++;
        else
            i = 0;
        characters[i].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[i].SetActive(false);
        if (i <= 0)
            i = characters.Length-1;
        else
            i--;
        characters[i].SetActive(true);
    }

    public void SpawnCharacter()
    {
        //int charnum = gameFlow.instance.characterNum;

        //charnum = i;
    }
}
