using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InputForce : MonoBehaviour
{

	private float XMoveAmplifier = 1000;
	private float YMoveAmplifier = 12000;
	private float cuerpoPicaOffset = 2.4f;
	public  Camera camera;
	public GameObject cuerpo;
	public GameObject joinNode;
	public GameObject distMarker_01;
	public GameObject distMarker_02;
	public GameObject picaContainer;
	public GameObject pica;
	public GameObject picaCollider1;
	public GameObject picaCollider2;
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text textIntentos;
	public Text textEmboques;
	public Text textGiros;
	private int touchCount;
	private bool touchFlag = false;
	private bool posSaveFlag = true;
	private float posX = 0f;
	private float posY = 0f;
	private float posTouchX = 0f;
	private float posTouchY = 0f;
	private float posDifX = 0f;
	private float posDifY = 0f;
	private float bestShoot = -11000f;
	private float percentageDiff = 0.2f;
	private bool canPullFlag = true;
	public GameObject pointMarker01;
	public GameObject pointMarker02;
	public GameObject pointReset;
	private float pointCount = 0;
	private float pointCountMax = 1;
	private int points = 0;
	private bool pointFlag = false;
	private int giros = 0;
	private float saveTime = 0;
	private float timeDiff = 0;
	private float timeDiffBase = 0.5f;
	private int stageCount = 0;
	public static InputForce Instance;
	private Vector3	 saveCuerpoPosition;
	private bool turnFlag = false;
	private bool resetFlag = false;
	private float resetCount = 0;
	private float resetMax = 1;
	private bool pointGirosFlag=false;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
		saveCuerpoPosition = cuerpo.transform.position;

	}

	// Use this for initialization
	void Start ()
	{

		Physics.solverIterationCount = 100;
		//joinNode.rigidbody2D.AddForce (new Vector2 (0, -1 * ( bestShoot* YMoveAmplifier)));
		stageCount=GameData.Instance.higestStage;
		print ("StageData:"+stageCount);
		UIManager.Instance.changeRetoText(stageCount+1);
	}
	
	// Update is called once per frame
	void Update ()
	{

		picaContainer.transform.rotation = Quaternion.Lerp (picaContainer.transform.rotation, Quaternion.Euler (0, 0, -45 * Input.acceleration.x), Time.time / 110);

		text3.text = "X:" + Input.acceleration.x + "\nY:" + Input.acceleration.y;
		if (Application.platform == RuntimePlatform.OSXEditor && !UIManager.Instance.UIflag) {
			if (Input.GetMouseButtonDown (0) && canPullFlag&& !UIManager.Instance.UIflag) {
				if (posSaveFlag) {

					posX = Input.mousePosition.x / Screen.width;
					posY = Input.mousePosition.y / Screen.height;
					//print ("posX:" + posX + "  posY:" + posY);
					posSaveFlag = false;
					saveTime = Time.time;
				}
			}

			if (Input.GetMouseButtonUp (0) && !posSaveFlag && !UIManager.Instance.UIflag) {

				posDifX = posX - Input.mousePosition.x / Screen.width;
				posDifY = posY - Input.mousePosition.y / Screen.height;
		
				//print ("posDifX:" + posDifX + "  posDifY:" + posDifY);
				posSaveFlag = true;
				touchFlag = true;
				timeDiff = timeDiffBase + Time.time - saveTime;
			}
		} else {
			if (Input.touchCount > 0 && canPullFlag && !UIManager.Instance.UIflag) {
				if (posSaveFlag) {

					posX = Input.touches [0].position.x / Screen.width;
					posY = Input.touches [0].position.y / Screen.height;
			
					posSaveFlag = false;
					saveTime = Time.time;
				}
				posTouchX = Input.touches [0].position.x;
				posTouchY = Input.touches [0].position.y;
			}
			
			if (Input.touchCount == 0 && !posSaveFlag && !UIManager.Instance.UIflag) {

				posDifX = posX - posTouchX / Screen.width;
				posDifY = posY - posTouchY / Screen.height;
				
				//print ("posDifX:" + posDifX + "  posDifY:" + posDifY);
				touchFlag = true;
				posSaveFlag = true;
				timeDiff = timeDiffBase + Time.time - saveTime;
				print (timeDiff);
			}
		}

		if (cuerpo.transform.position.y > -2.2f && !pointFlag) {
			canPullFlag = false;

		} else {
			resolveResults ();
			turnFlag=false;
			pointGirosFlag=false;
			canPullFlag = true;
		
		}


		if (touchFlag && canPullFlag && !UIManager.Instance.UIflag && Mathf.Abs(posDifY)>0.2) {

			print(posDifY);
			//Move Left
			joinNode.rigidbody2D.AddForce (new Vector2 (-1 * (posDifX * XMoveAmplifier), 0));
			text1.text = "X:" + (posDifX * XMoveAmplifier);
		
			//Move Rigth

			joinNode.rigidbody2D.AddForce (new Vector2 (-1 * (posDifX * XMoveAmplifier), 0));
			text1.text = "X:" + (posDifX * XMoveAmplifier);

			//Move Up

			float pullForce = -1 * (posDifY * YMoveAmplifier);
			float bestPullForce = 12000f;
			if (pullForce > bestPullForce) {
				pullForce *= 0.8f;
			}

			if (pullForce < bestPullForce * 0.9) {
				pullForce *= 1.2f;
			}

			joinNode.rigidbody2D.AddForce (new Vector2 (0, pullForce / timeDiff));
			text2.text = "Y:" + pullForce;
			touchFlag = false;

			cuerpo.rigidbody2D.AddTorque (9000f * posDifX);

			touchCount++;
			resolveResults ();
		}



		if (pica.transform.position.y + cuerpoPicaOffset < cuerpo.transform.position.y) {

			picaCollider1.GetComponent<Collider2D> ().enabled = true;
			picaCollider2.GetComponent<Collider2D> ().enabled = true;
		}

		if (pica.transform.position.y - cuerpoPicaOffset * 0.5 > cuerpo.transform.position.y) {

			picaCollider1.GetComponent<Collider2D> ().enabled = false;
			picaCollider2.GetComponent<Collider2D> ().enabled = false;
		}

		float distance = (Vector2.Distance (distMarker_01.transform.position, distMarker_02.transform.position));
		if (distance < 0.7) {


			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, Mathf.Lerp (camera.transform.position.z, -14f, 0.005f));
		} else {

			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, Mathf.Lerp (camera.transform.position.z, -19f, 0.05f));
		}

		float distancePointMarkers = Vector3.Distance (pointMarker01.transform.position, pointMarker02.transform.position);

		cuerpo.rigidbody2D.AddForce (new Vector2 ((pointMarker01.transform.position.x - pointMarker02.transform.position.x) * 25, 0));
		joinNode.rigidbody2D.AddForce (new Vector2 (0, 50f));

		if (distancePointMarkers < 0.5) {
			pointCount += 1 * Time.deltaTime;
		} else {
			pointCount = 0;
		}

		float distanceResetPoint = 1f;
		if (distancePointMarkers > distanceResetPoint) {
			pointFlag = false;
		}

		if (pointCount > pointCountMax && !pointFlag) {
			pointCount = 0;

		
			SoundManager.Instance.playEmboqueSound();
			if(pointGirosFlag){
				giros++;
				pointGirosFlag=false;
				UIManager.Instance.activateParticles();
			}else{
				points++;
				UIManager.Instance.activateParticles();
			}
			resolveResults ();
			pointFlag = true;
		}

		if (resetFlag) {
			resetCount += Time.deltaTime;
			if (resetCount > resetMax) {
				UIManager.Instance.UIflag = false;
				resetFlag = false;
				resetCount = 0;
			}
		}

		refreshText ();
		checkturns ();
	}

	private void refreshText ()
	{
		textIntentos.text = touchCount + "/" + StageManager.Instance.stageList [stageCount].intentos;
		textEmboques.text = points + "/" + StageManager.Instance.stageList [stageCount].emboques;
		textGiros.text = giros + "/" + StageManager.Instance.stageList [stageCount].giros;
	}

	private void resolveResults ()
	{
		if (points >= StageManager.Instance.stageList [stageCount].emboques && giros >= StageManager.Instance.stageList [stageCount].giros) {
			if (stageCount + 1 < StageManager.Instance.stageList.Count) {
				SoundManager.Instance.playNextStageSound();
				stageCount++;
				if(stageCount>GameData.Instance.higestStage){
					GameData.Instance.setHigestStage(stageCount);
					if(StageButtonGenerator.Instance!=null){
						StageButtonGenerator.Instance.repaintButtons();
					}
				}
				print (stageCount);
				UIManager.Instance.changeRetoText (stageCount + 1);
				UIManager.Instance.showWinUI ();

				resetMarkers ();
				resetEmboque();
			} else {
				UIManager.Instance.showEndUI ();
				SoundManager.Instance.playNextStageSound();
				resetEmboque();
			}
			
		}
		if (touchCount >= StageManager.Instance.stageList[stageCount].intentos && !canPullFlag) {
			UIManager.Instance.showLooseUI ();
			SoundManager.Instance.playLooseSound();
			resetEmboque();
			resetMarkers ();
		}
	}

	public void resetEmboque ()
	{
		picaCollider1.GetComponent<Collider2D> ().enabled = false;
		picaCollider2.GetComponent<Collider2D> ().enabled = false;
		UIManager.Instance.UIflag = true;
		canPullFlag=true;
		resetFlag = true;

		if (Input.touchCount>0 && !UIManager.Instance.UIflag) {
			posX = Input.touches [0].position.x / Screen.width;
			posY = Input.touches [0].position.y / Screen.height;

		}
		posDifX=0;
		posDifY=0;
		resetMarkers ();
	}

	public void resetStageCount ()
	{
		stageCount = 0;
		resetMarkers ();
	}

	public void resetMarkers ()
	{
		UIManager.Instance.changeRetoText (stageCount + 1);
		touchCount = 0;
		points = 0;
		giros = 0;

		refreshText ();
	}

	public void checkturns ()
	{
		float cuerpoRotation = Mathf.Abs (Mathf.Round (cuerpo.transform.rotation.w * 10));
		if (cuerpoRotation == 0 && !turnFlag) {
			pointGirosFlag=true;
			turnFlag = true;
			SoundManager.Instance.playGiroSound();
		}
		if (cuerpoRotation != 0) {
			turnFlag = false;
		}

	}

	public void setKinematicCuerpo(bool kinematic){
		cuerpo.rigidbody2D.isKinematic=kinematic;

	}

	public void starSpecificStage(int estageNum){
		stageCount=estageNum;
		if(Input.touchCount>0){
			posX = Input.touches [0].position.x / Screen.width;
			posY = Input.touches [0].position.y / Screen.height;
		}

		if (Application.platform == RuntimePlatform.OSXEditor && !UIManager.Instance.UIflag) {
			posX = Input.mousePosition.x / Screen.width;
			posY = Input.mousePosition.y / Screen.height;
		}
		resetEmboque();
	}

}
