using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deathChecker : MonoBehaviour {
	public GameObject GAMEOVER_UI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player") {
			GAMEOVER_UI.SetActive (true);
		}
	}
}
