using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Login : MonoBehaviour
{
    public InputField userName;
    public InputField password;
    public APISystem api;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginPlayer()
    {
        if (string.IsNullOrEmpty(userName.text))
        {
            Debug.Log("Enter username and password");
        }
        else
        {
            PlayerPrefs.SetString("username", userName.text);
            FindObjectOfType<APISystem>().GetPlayer(userName.text);
        }
    }

    public void Register()
    {
        SceneManager.LoadScene("Register");
    }
}
