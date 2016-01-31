using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	//private GameObject Player;
	private PlayerController p;
	
	void Awake()
	{
		//Player = GameObject.FindGameObjectWithTag ("Player");
		p = gameObject.GetComponentInParent<PlayerController>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log ("I Touched");
		if (other.gameObject.layer == 9) {
			p.grounded = true;
			p.tellAnim ();
		}
	}
	
	void OnTriggerStay2D (Collider2D other)
	{
		//Debug.Log ("Im Touching");
		if (other.gameObject.layer == 9) {
			p.grounded = true;
			//p.tellAnim ();
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.layer == 9) {
			//Debug.Log ("I Left");
			p.grounded = false;
			p.tellAnim ();
		}
	}

}
