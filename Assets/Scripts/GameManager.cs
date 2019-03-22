using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	#region Inspector_Variables

    // Numbers Variables
	[SerializeField]
	int PepsiCount =10;
    [SerializeField]
    float Power = 100;

    // Prefabs Variables
    [SerializeField]
	GameObject PepsiPrefab;
	[SerializeField]
	GameObject ARCamera;
	[SerializeField]
	GameObject BulletPrefab;

	// UI Variables
    [SerializeField]
    GameObject MainUI;
    [SerializeField]
    GameObject GameUI;
	[SerializeField]
	Text ScoreText;

	[SerializeField]
	GameObject VideoPlayer;

	#endregion

	#region Hidden_Public_Variables

    [HideInInspector]
    public static bool Detected = false;
    [HideInInspector]
    public static int Score = 0;

	#endregion

	#region Private_Variables

	private bool PlayVideo =false;
	private bool PlayGame = false;
	private List<GameObject> AllPepsi = new List<GameObject>();

	#endregion 

	#region Public_Functions

	public void PlayVideoButton() {
		StartVideo ();
	}

	public void GameButton() {
		StartGame ();
	}

	public void FireButton(){
		Fire ();
	}

	#endregion

	#region Private_Functions

    void Update() {
		ScoreText.text = "Score: "+Score.ToString ();

        if (Detected == true)
        {
            UIAppearance(true);
        }
        else
        {
            UIAppearance(false);
        }
    }



    void UIAppearance(bool appear) {
		MainUI.SetActive(appear);
    }

	void StartVideo(){
		PlayVideo =! PlayVideo;
		VideoPlayer.SetActive (PlayVideo);
		EndGame ();
	}

    void StartGame() {
		PlayGame =! PlayGame;
		GameUI.SetActive(PlayGame);
		VideoPlayer.SetActive (false);
		RandomPepsi ();
    }

	void EndGame(){
		GameUI.SetActive(false);
		DestroyPepsi ();
	}

	void Fire(){
		GameObject NewBullet = Instantiate (BulletPrefab, ARCamera.transform.position, ARCamera.transform.rotation);
		NewBullet.tag = "Bullet";
		NewBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, Power) , ForceMode.Impulse);
		Destroy (NewBullet, 2f);
	}

    void RandomPepsi() {
		for (int i = 0; i < PepsiCount; i++)
        {
            Vector3 Pos = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), Random.Range(-1f, 1f));
			GameObject GM = Instantiate(PepsiPrefab, Pos, Quaternion.identity); 
			AllPepsi.Add (GM);
        }
    }

	void DestroyPepsi(){
		if (AllPepsi.Count == PepsiCount) {
			for (int i = 0; i < PepsiCount; i++) {
				Destroy (AllPepsi [i]);
			}
		}
	}

	#endregion

}
