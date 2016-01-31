using UnityEngine;
using System.Collections;

public enum Season{ Winter, Spring, Summer, Autemn};
public static class SeasonExtension{
	public static Season ToSeason(int num){
		switch(num){
		default:
		case 1: return Season.Winter;
		case 2: return Season.Spring;
		case 3: return Season.Summer;
		case 4: return Season.Autemn;
		}
	}
	//Conversion for animator
	public static int ToInt(Season s){
		switch(s){
		default:
		case Season.Winter: return 1;
		case Season.Spring: return 2; 
		case Season.Summer: return 3;
		case Season.Autemn: return 4; 
		}
	}
}

public class Tome : MonoBehaviour {
	public static GameObject player;
	private static PlayerController pc;
	public Season sea = Season.Spring;

	void Start(){
		player = GameObject.Find("Player");
		pc = player.GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("Player")){
			if(pc == null){
				GameObject.FindGameObjectWithTag("Player");
			}else{
				pc.pickup(this);
				Destroy(this.gameObject);
			}
		}
	}
}
