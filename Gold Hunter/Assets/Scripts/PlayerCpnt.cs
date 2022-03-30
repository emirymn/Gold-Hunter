using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCpnt : MonoBehaviour
{
    public AudioClip coin, fall, serdar;
    public int jumpSpeed;
    private Rigidbody rigid;
    bool canJump = true;
	public Button tekrarbuton;
	public Button nextlevelbuton;
	//private float hiz = 10f;
	public OyunCont oyunK;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    rigid = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    //private void FixedUpdate()
    //{
    //    if (oyunK.oyunAktif) { 
    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");
    //    x *= Time.deltaTime * hiz;
    //    y *= Time.deltaTime * hiz;
    //    transform.Translate(x, 0f, y);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            canJump = true;
        }
        if (collision.gameObject.tag.Equals("altin"))
        {
            GetComponent<AudioSource>().PlayOneShot(coin, 1f);
            oyunK.AltinArttir();
            Destroy(collision.gameObject);
			if(oyunK.altinSayi>=3)
            {
				nextlevelbuton.gameObject.SetActive(true);
				oyunK.oyunAktif = false;
			}
        }
        else if (collision.gameObject.tag.Equals("enemy"))
        {
            GetComponent<AudioSource>().PlayOneShot(fall, 1f);
            oyunK.oyunAktif = false;
			tekrarbuton.gameObject.SetActive(true);
		}
        else if (collision.gameObject.tag.Equals("serdar"))
        {
            GetComponent<AudioSource>().PlayOneShot(serdar, 1f);
            oyunK.oyunAktif = false;
			tekrarbuton.gameObject.SetActive(true);
		}
    }
    //private void Jumpp()
    //{
    //    if (canJump)
    //    {
    //        rigid.AddForce(Vector3.up * jumpSpeed);
    //        canJump = false;
    //    }
    //}
    // Animation script
    private CharacterAnimation anim;

	// Rotation variables
	private float rotY,
					rotX,
					sensitivity = 10.0f;

	// Speed variables
	private float speed = 10f,
	 				speedHalved = 7.5f,
	 				speedOrigin = 10f;

	// Jump!
	private float distToGround;

	void Start()
	{
		anim = GetComponent<CharacterAnimation>(); // Get the animation script
	}

	// FixedUpdate is used for physics based movement
	void FixedUpdate()
	{
		if (oyunK.oyunAktif) { 
			float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
		float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
		MouseLook(); // Call the player look function which controls the mouse
		PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
		
		}
	}

	private void MouseLook()
	{
		if(oyunK.oyunAktif) {
			rotX += Input.GetAxis("Mouse X") * sensitivity; // set a float to control Mouse X input
			rotY += Input.GetAxis("Mouse Y") * sensitivity; // set a float to control Mouse Y input
			rotY = Mathf.Clamp(rotY, -90f, 90); // Lock rotY to a 90 degree angle for looking up and down
			transform.localEulerAngles = new Vector3(0, rotX, 0); // Rotate the player mode left and right
			Camera.main.transform.localEulerAngles = new Vector3(-rotY, 0, 0); // Rotate the camera up and down rather than the player model
		}
	}

	private void PlayerMove(float h, float v)
	{
		if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
		{
			if (h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
			{
				speed = speedHalved; // Modify the speed to adjust for moving on an angle
			}
			else // If only horizontal OR vertical are pressed individually then continue
			{
				speed = speedOrigin; // Keep speed to it's original value
			}
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (transform.right * h) * speed * Time.deltaTime); // Move player based on the horizontal input
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (transform.forward * v) * speed * Time.deltaTime); // Move player based on the vertical input
			//anim._animRun = true; // Enable the run animation
		}
		else    // If horizontal or vertical are not pressed then continue
		{
			//  anim._animRun = false; // Disable the run animation
		}
	}

	private void Jump()
	{
		
		
			//if (IsGrounded()) // If the player is grounded, this calls a boolean, then continue
			//{
   //         GetComponent<Rigidbody>().velocity += 5f * Vector3.up; // add velocity to the player on vector UP
   //     }
			if (canJump)
            {
                //rigid.AddForce(Vector3.up * jumpSpeed);
				GetComponent<Rigidbody>().velocity += 5f * Vector3.up;
				canJump = false;
            }
        
	}

	private bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f); // Do a ray cast to see if the players collider is 0.1 away from the surface of something
	}
}

