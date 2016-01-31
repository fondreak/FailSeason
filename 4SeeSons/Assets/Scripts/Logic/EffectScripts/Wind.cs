using UnityEngine;
using System.Collections;

public class Wind : Effected {
	Collider2D col;
	public float windForce = 10f;

	void Start(){
		col = gameObject.GetComponent<Collider2D>();
		anim = gameObject.GetComponent<Animator>();
		if(sea != Season.Autemn){
			col.enabled = false;
			anim.SetBool("Autum", false);
		}
		else
			anim.SetBool("Autum", true);

	}

	protected override void IfSeason(){
		if(Season.Autemn == sea){
			col.enabled = true;
			anim.SetBool("Autum", true);
		}
		else{
			col.enabled = false;
			anim.SetBool("Autum", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Equals("Player"))
			if (rb == null)
				if(player == null)
					player = GameObject.Find("Player");
				if(player != null){
					rb = player.GetComponent<Rigidbody2D>();
					rb.velocity.Set(rb.velocity.x, 0f);
			}
					
			if(rb != null)
				rb.gravityScale = 0f;
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.name.Equals("Player")){
			rb.AddForce(gameObject.transform.right * windForce);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name.Equals("Player"))
			rb.gravityScale = 1f;
	}
}