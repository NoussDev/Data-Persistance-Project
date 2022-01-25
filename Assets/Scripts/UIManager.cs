using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class UIManager : MonoBehaviour
{
    public static string namePlayer;
    public static string nameBestPlayer;
    public static int scoreBestPlayer;

    private Text bestScoreMenuText;

    private void Awake()
    {
        LoadBestScore();
        bestScoreMenuText = GameObject.Find("BestScore Menu").GetComponent<Text>();
        bestScoreMenuText.text = "Best Score: " + scoreBestPlayer + " Name: " + nameBestPlayer;
    }

    public void StartGame()
    {
        namePlayer = GameObject.Find("Player Name").GetComponent<InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void SaveBestScore(int points)
    {
        BestScore bestScore = new BestScore();
        bestScore.bestScoreNumber = points;
        bestScore.bestScoreName = UIManager.namePlayer;
        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public static void LoadBestScore()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/bestscore.json");
        BestScore bs = JsonUtility.FromJson<BestScore>(json);
        scoreBestPlayer = bs.bestScoreNumber;
        nameBestPlayer = bs.bestScoreName;
    }
}
[SerializeField]
public class BestScore
{
    public string bestScoreName = "";
    public int bestScoreNumber = 0;

}
