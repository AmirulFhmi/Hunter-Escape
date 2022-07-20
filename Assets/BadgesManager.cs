using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgesManager : MonoBehaviour
{
    public Image rookie, novice, pro, expert;
    public Transform parent;
    private int playerScore;
    public GameObject prefab;
    public GameObject playerRankPos;
    public APISystem api;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(GetScore());

    }

    private IEnumerator GetScore()
    {
        List<GameObject> tempHold = new List<GameObject>();

        api.GetLeaderboard();

        yield return new WaitUntil(() => api.containerB.status == "1");

        for (int i = 0; i < api.containerB.message.data.Count; i++)
        {
            tempHold.Add(Instantiate(prefab, parent));
            tempHold[i].SetActive(false);
            tempHold[i].transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            tempHold[i].transform.GetChild(1).GetComponent<Text>().text = api.containerB.message.data[i].alias;

            api.GetPlayer(api.containerB.message.data[i].alias);

            yield return new WaitUntil(() => api.containerA.status == "1");

            tempHold[i].transform.GetChild(2).GetComponent<Text>().text = api.containerA.message.score[0].value;

            api.containerA.status = "0";
        }

        for (int i = 0; i < api.containerB.message.data.Count; i++)
        {
            int highestScore = 0;
            for (int j = i; j < api.containerB.message.data.Count; j++)
            {
                int score = int.Parse(tempHold[j].transform.GetChild(2).GetComponent<Text>().text);

                if (score > highestScore)
                {
                    highestScore = score;
                    string holdName;
                    string holdScore;
                    holdName = tempHold[i].transform.GetChild(1).GetComponent<Text>().text;
                    tempHold[i].transform.GetChild(1).GetComponent<Text>().text = tempHold[j].transform.GetChild(1).GetComponent<Text>().text;
                    tempHold[j].transform.GetChild(1).GetComponent<Text>().text = holdName;
                    holdScore = tempHold[i].transform.GetChild(2).GetComponent<Text>().text;
                    tempHold[i].transform.GetChild(2).GetComponent<Text>().text = tempHold[j].transform.GetChild(2).GetComponent<Text>().text;
                    tempHold[j].transform.GetChild(2).GetComponent<Text>().text = holdScore;
                }
            }
            tempHold[i].SetActive(true);

            if (tempHold[i].transform.GetChild(1).GetComponent<Text>().text == PlayerPrefs.GetString("username"))// && i > 2)
            {
                playerRankPos.SetActive(false);
                playerRankPos.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                playerRankPos.transform.GetChild(1).GetComponent<Text>().text = tempHold[i].transform.GetChild(1).GetComponent<Text>().text;
                //playerRankPos.transform.GetChild(2).GetComponent<Text>().text = tempHold[i].transform.GetChild(2).GetComponent<Text>().text;
                playerRankPos.SetActive(true);
                Debug.Log(tempHold[i].transform.GetChild(2).GetComponent<Text>().text);

                playerScore = int.Parse(tempHold[i].transform.GetChild(2).GetComponent<Text>().text);

                if(playerScore > 200 && playerScore < 500 )
                {
                    rookie.enabled = false;
                }
                else if(playerScore > 500 && playerScore < 1000)
                {
                    rookie.enabled = false;
                    novice.enabled = false;
                }
                else if (playerScore > 1000 && playerScore < 2000)
                {
                    rookie.enabled = false;
                    novice.enabled = false;
                    pro.enabled = false;
                }
                else if (playerScore >  2000)
                {
                    rookie.enabled = false;
                    novice.enabled = false;
                    pro.enabled = false;
                    expert.enabled = false;
                }
            }
        }

        Debug.Log("Selesai");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
