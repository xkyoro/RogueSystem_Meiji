using UnityEngine;
using System.Collections;

public class goalChecker : MonoBehaviour {
    public GameObject GOAL_UI;

	// プレイヤー
	private GameObject PlayerOBJ;

	public Camera mainCamera;

	// GameClearしたあとのモーション指示前のウェイト時間
	private bool _WaitInterval = false;
	private float WaitDuration = 1.5f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		GOAL_UI.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (_WaitInterval) {
			if (timer >= WaitDuration) {
				PlayerOBJ.GetComponent<UnityChan.SD_UnityChanControlScriptWithRgidBody> ().GAMECLEAR ();
			} else {
				timer += Time.deltaTime;
			}
		} else {
			timer = 0;
		}
	}

	void OnTriggerEnter(Collider c){

		if (c.gameObject.tag == "Player") {
			PlayerOBJ = c.gameObject;
			GOAL_UI.SetActive (true);
			_WaitInterval = true;
			mainCamera.GetComponent<UnityChan.ThirdPersonCamera>().GameClear();
		}
	}
}
