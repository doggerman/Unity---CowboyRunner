using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour {

	public static LeaderboardController instance;
	private const string LEADERBOARD_SCORE = "CgkI1YP23LMLEAIQAg";

	private Button LeaderBoardsBtn;
	
	void Awake()
	{
		Debug.Log ("Leaderboards Controller Awake");
		MakeSingleton ();
		GetTheButton ();
	}

	void GetTheButton()
	{
		LeaderBoardsBtn = GameObject.Find ("Leaderboards").GetComponent<Button>();
		LeaderBoardsBtn.onClick.RemoveAllListeners ();
		LeaderBoardsBtn.onClick.AddListener(() => OpenLeaderboardScore());
	}
	
	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate ();
	}
	
	void OnLevelWasLoaded()
	{
		PostScore ();
		//ReportScore (GameController.instance.getHighScore ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void MakeSingleton()
	{
		if(instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void OpenLeaderboardScore()
	{
		Debug.Log ("OpenLeaderboardScore");
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARD_SCORE);
		} else {
			Social.localUser.Authenticate((bool success) =>{
				PlayGamesPlatform.Instance.SignOut ();
			});
		}
	}
	
	/*public void ConnectOrDisconnectGooglePlayGames()
	{
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.SignOut ();
		} else {
			Social.localUser.Authenticate((bool success) =>{
				
			});
		}
	}
	
	public void OpenLeaderboardScore()
	{
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI(LEADERBOARD_SCORE);
		}
	}*/
	
	void PostScore()
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (PlayerPrefs.GetInt("Score"), LEADERBOARD_SCORE, (bool scuccess) => {
			});
		}
	}
}
