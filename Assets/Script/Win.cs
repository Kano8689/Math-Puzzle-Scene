using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text ScoreBox;
    public Slider ScoreLine;
    public Text WinBox;
    int lvlno = 0;
    int score = 0;

    private void OnEnable()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);

        score = PlayerPrefs.GetInt("GameScore");
        ScoreBox.text = "" + score + "/750";
        ScoreLine.value = score;

        WinBox.text = "PUZZLE " + (lvlno - 1) + " COMPLETED";
    }
    public void OnClickContinue()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);

        SceneManager.LoadScene("Play");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Home");
    }
}
