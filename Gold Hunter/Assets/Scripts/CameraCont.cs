using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public OyunCont oyunK;
    public float hassasiyet = 5f;
   public float yumusaklik = 2f;
    Vector2 gecisPos;
    Vector2 camPos;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.gameObject;
        camPos.y = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        //if(oyunK.oyunAktif)
        //{ 
        //Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));
        //gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklik);
        //gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklik);
        //camPos += gecisPos;
        //transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
        //Player.transform.localRotation = Quaternion.AngleAxis(camPos.x, Player.transform.up);
        //}
    }
    private GameObject player;
    private Vector3 offsetPos;

    void OnEnable()
    {
        player = GameObject.FindWithTag("Player"); // Find the GameObject named Player
        offsetPos = new Vector3(0, 1f, 0f); // Set an offset position for the camera
        transform.rotation = player.transform.rotation; // Set the camera's rotation
        gameObject.transform.parent = player.transform; // Sets the player as the cameras Parent
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offsetPos + player.transform.forward * 0.5f; // Follow the player plus the offset position plus half the players transform forward
    }
}
