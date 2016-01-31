using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public bool grounded = false;
	public float spd = 15f;
	public float jumpforce = 150f;
	public float xDir = 0f, yDir = 0f;
	private Rigidbody2D rb;
	private Animator anim;
	private float xScale = 1;
	public bool climbing = false;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveLogic();
	}

	public void Dead(){
		Application.LoadLevel (Application.loadedLevel);
	}

	private void AboutFace(){
		if(((xDir > 0f) != (gameObject.transform.localScale.x > 0f)) && xDir != 0)
		{
			xScale *= -1f;
			gameObject.transform.localScale =  new Vector3 (xScale, 1f, 1f);
		}
	}

	private void MoveLogic(){
		xDir = Input.GetAxis("Horizontal");
		if(xDir != 0f)
		{
			gameObject.transform.position += (Vector3.right * xDir * spd * Time.deltaTime);
			AboutFace();
			anim.SetFloat("Vel", Mathf.Abs(xDir));
		}
		else if(grounded)
			anim.SetFloat("Vel", xDir);

		if(rb.gravityScale == 0f){
			yDir = Input.GetAxis ("Vertical");
			if(yDir != 0f){
				gameObject.transform.localPosition += (Vector3.up * yDir * spd * Time.deltaTime);
			}
		}

		if(grounded && Input.GetButton("Jump"))
		{
			Jump ();
		}
	}

	private void Jump(){
		rb.AddForce(Vector2.up * jumpforce);
	}

	public void pickup(Tome t){
		GameController.gc.SeasonChange(t.sea);
	}

	public void tellAnim(){
		anim.SetBool ("Grounded", grounded);
		anim.SetBool("Climbing", climbing);
	}
}
