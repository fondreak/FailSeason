using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController gc;
	private GameObject background;
//	private PlayerController player;
	public Season sea;
	public Animator scenery;
	public Season intSea = Season.Autemn;
	private Effected[] targets;
	
	//starts b4 start
	void Awake(){
		if(gc == null){
			gc = this;
		}
		else if(gc != this)
			Destroy(this);
		GrabMethods();
		scenery.SetInteger("Season", SeasonExtension.ToInt(intSea));
		GrabMethods();
	}

	// Use this for initialization
	void Start () {
		if(background = null)
			background = GameObject.Find("Background");
	}

	//proc by grabMethods
	public Effected[] GetEffectedArray(){
		GameObject[] go = GameObject.FindGameObjectsWithTag("Effected");
		Effected[] targets = new Effected[go.Length];
		for(int i = 0; i < go.Length; i++)
			targets[i] = go[i].GetComponent<Effected>();
		return targets;
	}

	//proc by tome touch
	public void SeasonChange(Season s)
	{
		// set season
		sea = s;
		//send to animator
		scenery.SetInteger("Season", SeasonExtension.ToInt(s));
		//check effected
		foreach(Effected e in targets)
			if(e != null)
				e.SetSeason(s);
	}

	//starts after lvl change
	void OnLevelWasChanged(int level){
		GrabMethods();
		scenery.SetInteger("Season", SeasonExtension.ToInt(sea));
		SeasonChange(sea);
	}

	//called by lvl change
	private void GrabMethods(){ 
		background = GameObject.Find("Background");
		//player = GameObject.Find("Player").GetComponent<PlayerController>();
		scenery = background.GetComponent<Animator>();
		sea =  SeasonExtension.ToSeason(scenery.GetInteger("Season"));
		targets = GetEffectedArray();
	}

	public static void StartGame(){
		Application.LoadLevel("First");
	}

	public static void ToMenu(){
		Application.LoadLevel ("Menu");
	}

	public static void ToCredits(){
		Application.LoadLevel ("Credits");
	}

	public static void ToInstructions(){
		Application.LoadLevel("Instructions");
	}

	public static void NextLvl(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
