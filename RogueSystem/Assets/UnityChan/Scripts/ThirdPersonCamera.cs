//
// Unityちゃん用の三人称カメラ
// 
// 2013/06/07 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

namespace UnityChan
{
	public class ThirdPersonCamera : MonoBehaviour
	{
		public float smooth = 3f;		// カメラモーションのスムーズ化用変数
		GameObject standardOBJ;
		GameObject frontPosOBJ;
		Transform standardPos;			// the usual position for the camera, specified by a transform in the game
		Transform frontPos;			// Front Camera locater
		Transform jumpPos;			// Jump Camera locater

		//Clear フラグ
		private bool _GAMECLEAR;

		// スムーズに繋がない時（クイック切り替え）用のブーリアンフラグ
		bool bQuickSwitch = false;	//Change Camera Position Quickly


		void Start ()
		{
			// 各参照の初期化
			standardOBJ = GameObject.Find ("CamPos").gameObject;

			if (GameObject.Find ("FrontPos"))
				frontPosOBJ = GameObject.Find ("FrontPos").gameObject;
			frontPos = frontPosOBJ.transform;

			if (GameObject.Find ("JumpPos"))
				jumpPos = GameObject.Find ("JumpPos").transform;

			//カメラをスタートする
			transform.position = standardOBJ.transform.position;	
			transform.forward = standardOBJ.transform.forward;	
		}

		void FixedUpdate ()	// このカメラ切り替えはFixedUpdate()内でないと正常に動かない
		{
			if (_GAMECLEAR) {
				setGameClearPosition();
			}
			else if (Input.GetButton ("Fire1")) {	// left Ctlr	
				// Change Front Camera
				setCameraPositionFrontView ();
			}
			else if (Input.GetButton ("Fire2")) {	//Alt	
				// Change Jump Camera
				setCameraPositionJumpView ();
			}
			else {	
				// return the camera to standard position and direction
				setCameraPositionNormalView ();
			}
		}

		void setCameraPositionNormalView ()
		{
			if (bQuickSwitch == false) {
				// the camera to standard position and direction
				transform.position = Vector3.Lerp (transform.position, standardOBJ.transform.position, Time.fixedDeltaTime * smooth);	
				transform.forward = Vector3.Lerp (transform.forward, standardOBJ.transform.forward, Time.fixedDeltaTime * smooth);
			} else {
				// the camera to standard position and direction / Quick Change
				transform.position = standardOBJ.transform.position;	
				transform.forward = standardOBJ.transform.forward;
				bQuickSwitch = false;
			}
		}

		void setCameraPositionFrontView ()
		{
			// Change Front Camera
			bQuickSwitch = true;
			//	transform.position = frontPosOBJ.transform.position;	
			//	transform.forward = frontPosOBJ.transform.forward;
		}

		void setCameraPositionJumpView ()
		{
			// Change Jump Camera
			bQuickSwitch = false;
			transform.position = Vector3.Lerp (transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp (transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);		
		}

		void setGameClearPosition()
		{
			transform.position = Vector3.Slerp (transform.position, frontPos.position, Time.fixedDeltaTime * smooth);
			transform.forward = Vector3.Lerp (transform.forward, frontPos.forward, Time.fixedDeltaTime * smooth);
		}

		public void GameClear(){
			_GAMECLEAR = true;
		}

	}
}