using UnityEngine;
using System.Collections;

public abstract class Effected : MonoBehaviour {
	protected Season sea;
	protected Animator anim;
	public static GameObject player;
	public static Rigidbody2D rb;
	public static PlayerController pc;

	protected void Find(){
			player = GameObject.Find("Player");
			pc = player.GetComponent<PlayerController>();
			rb = player.GetComponent<Rigidbody2D>();
	}

	public void SetSeason(Season s){
		if(pc == null || player == null || rb == null)
			Find ();
		sea = s;
		IfSeason ();
	}

	protected abstract void IfSeason();
}
