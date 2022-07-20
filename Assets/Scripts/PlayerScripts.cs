using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon;
using Photon.Pun;

public class PlayerScripts : MonoBehaviourPun, IPunObservable
{
    public TMP_Text playerNameText;
    public string username;
    public CharacterController controller;
    public Vector3 playerVelocity;
    public float playerSpeed = 5;
    public float jumpHeight = 1f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 100.0F;

    //public Rigidbody rb;
    public float Speed = 3;
    private float x;
    private float z;
    public Vector3 camOffset;
    static Animator anim;

    private int totalCoins = 0;
    public static int totalScore;
    public TMP_Text coinsText;
    private int randomScore;

    public GameObject jumpSoundGameObject;
    public AudioSource jumpAudio;

    // Start is called before the first frame update
    void Start()
    {
        
        //rb = GetComponent<Rigidbody>();
        if (photonView.IsMine)
        {
            anim = GetComponent<Animator>();
            username = PlayerPrefs.GetString("username");
            playerNameText.text = username;
            Debug.Log(playerNameText.text);
            jumpSoundGameObject = GameObject.Find("JumpSound");
            jumpAudio = jumpSoundGameObject.GetComponent<AudioSource>();
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        /*if(collision.gameObject.tag == "Player")
        {
            if (photonView.IsMine)
            {
                photonView.RPC("Damage", RpcTarget.All);
            }
        }*/
        if (collider.gameObject.tag == "MysteryBox")
        {
            
            if (photonView.IsMine)
            {
                Debug.Log("Langgar");
                photonView.RPC("IncreaseScore", RpcTarget.All);

            }
        }

    }

    [PunRPC]
    void Damage()
    {

    }

    [PunRPC]
    void IncreaseScore()
    {
        randomScore = Random.Range(5, 50);
        totalCoins += randomScore;
        totalScore = totalCoins;
        Debug.Log(totalCoins);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //x = Input.GetAxisRaw("Horizontal");
            //z = Input.GetAxisRaw("Vertical");

            //float move = x + z;
            Vector3 camPos = Camera.main.transform.position;
            Vector3 pPos = transform.position;
            Camera.main.transform.position = Vector3.Lerp(camPos, new Vector3(pPos.x, pPos.y, pPos.z) + camOffset, 2f * Time.deltaTime);

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
                anim.SetTrigger("Jump");
                jumpAudio.Play();
            }

            if (move.z != 0 || move.x != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        coinsText.text = totalCoins.ToString();
        if (photonView.IsMine)
        {
            //rb.AddForce(new Vector3(x, 0, z)* Speed);
            
        }
        else
        {

        }
    }

    public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(username);
            stream.SendNext(totalCoins);
        }
        else if (stream.IsReading)
        {
            username = (string)stream.ReceiveNext();
            playerNameText.text = username;
            totalCoins = (int)stream.ReceiveNext();
        }
    }

}
