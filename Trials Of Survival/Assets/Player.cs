using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Down;
	public KeyCode Up;
	public float speed;
	public bool upAndDown;

	public Rigidbody2D ninja;

	public Camera cam;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (cam.transform.position.y <= -81 || cam.transform.position.y >= 82) {

		} else {
			cam.transform.position = new Vector3 (0, this.gameObject.transform.position.y, -1250);
		}
		//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		
		//do this
		if (Input.GetKey (Left)) {
			gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			ninja.velocity = new Vector2 (-speed, ninja.velocity.y);
			anim.Play ("Walk");
		} else if (Input.GetKey (Right)) {
			gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);;
			ninja.velocity = new Vector2 (+speed, ninja.velocity.y); 
			anim.Play ("Walk");
		} else if (Input.GetKey (Up) && upAndDown) {
			ninja.velocity = new Vector2 (ninja.velocity.x, +speed);
		} else if (Input.GetKey (Down) && upAndDown) {
			ninja.velocity = new Vector2 (ninja.velocity.x, -speed);
		}
		//if thats false ^ then do this no matter what
		else
		{
			ninja.velocity = new Vector2(0,ninja.velocity.y);
		}

		if (Input.GetKeyUp (Left)) {
			anim.Play ("Nothing");
		} else if (Input.GetKeyUp (Right)) {
			anim.Play ("Nothing");
		}

		if (Input.GetButtonDown ("Fire1")) {
			anim.Play ("Sword");
		}
	}
}
