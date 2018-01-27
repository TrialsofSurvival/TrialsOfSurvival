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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		
		//do this
		if (Input.GetKey (Left)) {
			gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			ninja.velocity = new Vector2 (-speed, ninja.velocity.y);
		} else if (Input.GetKey (Right)) {
			gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);;
			ninja.velocity = new Vector2 (+speed, ninja.velocity.y); 
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
	}
}
