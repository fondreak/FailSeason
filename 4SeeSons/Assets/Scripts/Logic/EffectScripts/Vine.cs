using UnityEngine;
using System.Collections;

public class Vine : Effected {
	public int size = 1;
	private Collider2D col;

	void Start(){
		base.Find();
		if(rb == null)
			{rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();}
		anim = gameObject.GetComponent<Animator>();
		col = gameObject.GetComponent<Collider2D>();
		if(sea != Season.Spring)
			col.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name.Equals("Player")){
			if(rb == null){
				base.Find();
			}
			rb.gravityScale = 0f;
			pc.climbing = true;
			pc.tellAnim();
		}
			
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.name.Equals("Player"))
			if(rb != null){
				rb.gravityScale = 0f;
			}
			else{
				base.Find();
				rb.gravityScale = 0f;
			}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name.Equals("Player")){
			rb.gravityScale = 1f;
			pc.climbing = false;
			pc.tellAnim();
		}
	}

	protected override void IfSeason(){
		switch(sea){
		default: col.enabled = false;
			anim.SetBool("Spring", false); break;
		case Season.Spring: col.enabled = true;
			anim.SetBool("Spring" , true); 
			anim.SetInteger("Size" , size);break;
		}
	}
}
