using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Rank {
	public int score;
	public string name;
}

public class HighscoreManager : MonoBehaviour {
	[SerializeField] Text score;
	[SerializeField] Text nameLabel;
	[SerializeField] InputField nameField;
	[SerializeField] Transform nameInput;
	[SerializeField] Transform table;

	bool leaderboardDisplayed = false;
	int scoreCount;
	int playerScore;
	List<Rank> scores;

	void Start () {
		scores = new List<Rank>();
		nameField.ActivateInputField();
		playerScore = PlayerPrefs.GetInt("playerScore", Random.Range(110,200));
		score.text = playerScore.ToString();
		table.gameObject.SetActive(false);
	}

	void DisplayLeaderBoards() {
		scoreCount = PlayerPrefs.GetInt("highscore:count");
		leaderboardDisplayed = true;
		nameInput.GetComponent<InputField>().DeactivateInputField();
		table.gameObject.SetActive(true);
		Rank tmpRank;

		for (int i = 0; i < scoreCount; i++) {
			tmpRank = new Rank();
			tmpRank.name = PlayerPrefs.GetString("highscore:name["+i+"]", "W.B.");
			tmpRank.score = PlayerPrefs.GetInt("highscore:score["+i+"]", 0);
			scores.Add(tmpRank);
		}

		tmpRank = new Rank();
		tmpRank.score = playerScore;
		tmpRank.name = nameField.text;

		scores.Add(tmpRank);

		List<Rank> sortedList = scores.OrderByDescending(o=>o.score).ToList();
		SetTable(sortedList);

		if(sortedList.Last().score < playerScore) {
			Debug.Log("is new Highscore!");
			sortedList.Last().score = playerScore;
			sortedList.Last().name = nameField.text;

			SaveLeaderboard(sortedList);
		}
	}

	void SaveLeaderboard(List<Rank> scores) {
		for (int i = 0; i < scores.Count; i++) {
			PlayerPrefs.SetInt("highscore:score["+i+"]", scores[i].score);
			PlayerPrefs.SetString("highscore:name["+i+"]", scores[i].name);
			Debug.Log("123");
		}

		// PlayerPrefs.Save();
	}

	void SetTable(List<Rank> scores) {
		for (int i = 0; i < table.childCount; i++) {
			if(i >= scores.Count) return;

			table.GetChild(i).transform.FindChild("name").GetComponent<Text>().text = scores[i].name;
			table.GetChild(i).transform.FindChild("score").GetComponent<Text>().text = scores[i].score.ToString();
			table.GetChild(i).transform.FindChild("Rank").GetComponent<Text>().text = "#"+(i+1).ToString();
		}
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) && !leaderboardDisplayed){
			DisplayLeaderBoards();
		}
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(0);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

	void BuildDummyScores() {
		scoreCount = 6;

		for (int i = 0; i < scoreCount; i++) {
			PlayerPrefs.SetInt("highscore:score["+i+"]", Random.Range(110, 200));
			PlayerPrefs.SetString("highscore:name["+i+"]", "Whale Boy");
		}
	}
}
