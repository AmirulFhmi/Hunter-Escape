using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField firstName;
    public TMP_InputField lastName;
    public TMP_InputField password;
    public TMP_InputField loginUserName;
    public TMP_InputField loginPassword;
    public APISystem api;
    public Canvas registerCanvas;
    public Canvas loginCanvas;

    // Start is called before the first frame update
    void Start()
    {
        registerCanvas.gameObject.SetActive(false);
        loginCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterPlayer()
    {
        FindObjectOfType<APISystem>().Register(userName.text, password.text, firstName.text, lastName.text);
        registerCanvas.gameObject.SetActive(false);
        loginCanvas.gameObject.SetActive(true);
        //SceneManager.LoadScene("Login");
        //Application.LoadLevel("Login");
    }

    public void LoginPlayer()
    {
        if (string.IsNullOrEmpty(loginUserName.text))
        {
            Debug.Log("Enter username and password");
        }
        else
        {
            PlayerPrefs.SetString("username", loginUserName.text);
            FindObjectOfType<APISystem>().GetPlayer(loginUserName.text);
        }
    }

    public void Login()
    {
        registerCanvas.gameObject.SetActive(false);
        loginCanvas.gameObject.SetActive(true);
        //SceneManager.LoadScene("Login");
    }

    public void Register()
    {
        registerCanvas.gameObject.SetActive(true);
        loginCanvas.gameObject.SetActive(false);
        //SceneManager.LoadScene("Login");
    }
}
