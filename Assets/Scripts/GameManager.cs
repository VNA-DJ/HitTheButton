using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public bool button01aktif = false;
	public bool button02aktif = false;
	public bool button03aktif = false;
	public bool button04aktif = false;
	public bool button05aktif = false;
	public bool button06aktif = false;
	public bool complete = false;
	private int button01rand;
	private int button02rand;
	private int button03rand;
	private int button04rand;
	private int button05rand;
	private int button06rand;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject google;
	public GameObject twt;
	public GameObject leaderboard;
	public GameObject rate;
	public GameObject next;
	public Text timerLabel;
	AudioSource winsfx;
	public AudioSource sfx;
	public AudioClip comp;
	public float timer;
	Animator anim;
	Animator animMenu;

	public VG_GoogleAdmob admob;
	public int no;

	// Use this for initialization
	void Start() {
		next.GetComponent<Button> ().interactable = false;
		winsfx = GetComponent<AudioSource> ();
		anim = GameObject.Find("BackToMenu").GetComponent<Animator> ();
		animMenu = GameObject.Find("Menu").GetComponent<Animator> ();
		google.SetActive (false);
		twt.SetActive (false);
		leaderboard.SetActive (false);
		rate.SetActive (false);
		Time.timeScale = 0f;
	}
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Menu();
		}
		timer += Time.deltaTime;

		int minutes = Mathf.FloorToInt(timer / 60); //Divide the guiTime by sixty to get the minutes.
		int seconds = Mathf.FloorToInt(timer % 60);//Use the euclidean division for the seconds.

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
	
		button01rand = Random.Range(1, 12);
		button02rand = Random.Range(1, 12);
		button03rand = Random.Range(1, 12);
		button04rand = Random.Range(1, 12);
		button05rand = Random.Range(1, 12);
		button06rand = Random.Range(1, 12);
		if (button01aktif == true)
		{
			button1.GetComponent<Button> ().interactable = false;
		}
		if (button01aktif == false)
		{
			button1.GetComponent<Button> ().interactable = true;
		}
		if (button02aktif == true)
		{
			button2.GetComponent<Button> ().interactable = false;
		}
		if (button02aktif == false)
		{
			button2.GetComponent<Button> ().interactable = true;
		}

		if (button03aktif == true)
		{
			button3.GetComponent<Button> ().interactable = false;
		}
		if (button03aktif == false)
		{
			button3.GetComponent<Button> ().interactable = true;
		}
		if (button04aktif == true)
		{
			button4.GetComponent<Button> ().interactable = false;
		}
		if (button04aktif == false)
		{
			button4.GetComponent<Button> ().interactable = true;
		}

		if (button05aktif == true)
		{
			button5.GetComponent<Button> ().interactable = false;
		}
		if (button05aktif == false)
		{
			button5.GetComponent<Button> ().interactable = true;
		}
		if (button06aktif == true)
		{
			button6.GetComponent<Button> ().interactable = false;
		}
		if (button06aktif == false)
		{
			button6.GetComponent<Button> ().interactable = true;
		}

		if (button01aktif == true && button02aktif == true && button03aktif == true && button04aktif == true && button05aktif == true && button06aktif == true && !complete)
		{
			complete = true;
			Score ();
			no++;
		}

		if (complete) {
			button1.GetComponent<Button> ().interactable = false;
			button2.GetComponent<Button> ().interactable = false;
			button3.GetComponent<Button> ().interactable = false;
			button4.GetComponent<Button> ().interactable = false;
			button5.GetComponent<Button> ().interactable = false;
			button6.GetComponent<Button> ().interactable = false;
			Time.timeScale = 0f;
		}
		if (no.Equals(2))
		{
			admob.ShowInterstitial();
			no = 0;
		}
	}

	public void Buttonkomut() {
		if (button01rand == 1)
		{
			button01aktif = true;
		}

		if (button01rand == 3)
		{
			button01aktif = false;
		}

		if (button02rand == 4)
		{
			button02aktif = true;
		}

		if (button02rand == 6)
		{
			button02aktif = false;
		}

		if (button03rand == 5)
		{
			button03aktif = true;
		}

		if (button03rand == 7)
		{
			button03aktif = false;
		}

		if (button04rand == 8)
		{
			button04aktif = true;
		}

		if (button04rand == 10)
		{
			button04aktif = false;
		}

		if (button05rand == 9)
		{
			button05aktif = true;
		}

		if (button05rand == 11)
		{
			button05aktif = false;
		}

		if (button06rand == 10)
		{
			button06aktif = true;
		}

		if (button06rand == 12)
		{
			button06aktif = false;
		}

	}

	public void Sound()
	{
		sfx.Play ();
	}

	public void NextGame()
	{
		button01aktif = false;
		button02aktif = false;
		button03aktif = false;
		button04aktif = false;
		button05aktif = false;
		button06aktif = false;
		button1.GetComponent<Button> ().interactable = true;
		button2.GetComponent<Button> ().interactable = true;
		button3.GetComponent<Button> ().interactable = true;
		button4.GetComponent<Button> ().interactable = true;
		button5.GetComponent<Button> ().interactable = true;
		button6.GetComponent<Button> ().interactable = true;
		timer = 0;
		Time.timeScale = 1f;
		complete = false;
		next.GetComponent<Button> ().interactable = false;
		google.SetActive (false);
		twt.SetActive (false);
		leaderboard.SetActive (false);
		rate.SetActive (false);
		
	}

	void Score()
	{
		if (timer > 0 && timer <= 15) {
			ScoreManager.score += 100;
		} else if (timer > 15 && timer <= 30) {
			ScoreManager.score += 75;
		} else if (timer > 30 && timer <= 60) {
			ScoreManager.score += 50;
		} else if (timer > 60) {
			ScoreManager.score += 25;
		}
		winsfx.PlayOneShot (comp, 0.5f);
		next.GetComponent<Button> ().interactable = true;
		google.SetActive (true);
		twt.SetActive (true);
		leaderboard.SetActive (true);
		rate.SetActive (true);
		button01aktif = false;
		button02aktif = false;
		button03aktif = false;
		button04aktif = false;
		button05aktif = false;
		button06aktif = false;
			
	}

	public void Menu()
	{
		anim.Play ("Giris");
		Debug.Log ("Menü Açıldı.");
		Time.timeScale = 0f;
	}

	public void Yes()
	{
		Debug.Log ("Menüye girildi.");
		button01aktif = false;
		button02aktif = false;
		button03aktif = false;
		button04aktif = false;
		button05aktif = false;
		button06aktif = false;
		button1.GetComponent<Button> ().interactable = true;
		button2.GetComponent<Button> ().interactable = true;
		button3.GetComponent<Button> ().interactable = true;
		button4.GetComponent<Button> ().interactable = true;
		button5.GetComponent<Button> ().interactable = true;
		button6.GetComponent<Button> ().interactable = true;
		complete = false;
		next.GetComponent<Button> ().interactable = false;
		ScoreManager.score = 0;
		animMenu.Play ("Exit");
		anim.Play ("Cikis");
	}

	public void No()
	{
		anim.Play ("Cikis");
		if (complete)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void Play()
	{
		Time.timeScale = 1f;
		animMenu.Play ("Play");
		timer = 0;
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
