using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    int lvlno = 0, TotalLevel = 0;
    int score = 0;
    public Text LevelBoard;
    public Text AnsBox;
    public Text Wrong;
    public Text HintBox;
    public Sprite[] PzlBoard;
    public Image PzlImg;
    string[] Answer = { "10", "25", "6", "14", "128", "7", "50", "1025", "100", "3", "212", "3011", "14", "16", "1", "2", "44", "45", "625", "1", "13", "47", "50", "34", "6", "41", "16", "126", "82", "14", "7", "132", "34", "48", "42", "288", "45", "4", "111", "47", "27", "87", "22", "253", "12", "48", "178", "1", "6", "10", "2", "20", "7", "5", "143547", "84", "11", "27", "3", "5", "39", "31", "10", "130", "22", "3", "14", "42", "164045", "11", "481", "86", "84", "13", "8" };

    string[] Hint = { "1 + 1 = 2", "1 * 1 = 1", "8 * 7(8-1) = 56", "Count Square", "square of 3 and multiply it's 2", "Manage Answer Series", "Use Mathematics Rules", "First sum after multiplication and concact it", "1 + 1 * 1 * 1 = 4", "Check difrent between reverse diagonal", "Substration and sum or concact it", "multiplacition and sum or concact it", "Use mathematic rules", "40/5=8 and 8 * 8 = 64", "Fill Missing Number", "8 + 13 = 21, 16 + 6 = 22", "last number concact with diffrent", "2,1 = 21 and 12", "Multiply with it's square root", "pyramid sum", "Count Triangle", "13", "multiply and series sum", "3 * 2 + 4 = 10", "first number square and sum with second number", "common devide number", "first square minues", "sum series", "multiply, square, sum", "8 * 10 - 5 - 1", "multiply with devide", "minues, miltiply", "sum of table series", "Multiply and Sum","lvl 34" };

    void OnEnable()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);
        TotalLevel = PlayerPrefs.GetInt("TotalLevel", 0);
        print(lvlno);
        LevelBoard.text = "Puzzle " + lvlno;

        score = PlayerPrefs.GetInt("GameScore", 0);
        print(score);

        PzlImg.sprite = PzlBoard[lvlno - 1];
    }

    string ans;
    public void onClickAnsBtn(int n)
    {
        ans += n;
        AnsBox.text = ""+ans;

        print(ans);
    }

    public void onClickDltBtn()
    {
        string v = AnsBox.text;

        ans = v.Substring(0,v.Length-1);
        AnsBox.text = "" + ans;

        print(ans);

    }

    public void onClickSubmit()
    {
        string v = AnsBox.text;

        AnsBox.text  = "";
        ans = null;

        if (Answer[lvlno-1]==v)
        {
            if(TotalLevel<=lvlno)
            {
                PlayerPrefs.SetInt("TotalLevel",lvlno);
            }

            if (TotalLevel <= lvlno)
            {
                if (!PlayerPrefs.HasKey("hint_" + (lvlno)))
                {
                    score += 10;
                    PlayerPrefs.SetInt("GameScore", score);
                }
            }

            if (PlayerPrefs.HasKey("skip_" + (lvlno)))
            {
                score += 10;
                PlayerPrefs.SetInt("GameScore", score);
            }

            PlayerPrefs.DeleteKey("skip_" + lvlno);

            lvlno++;
            PlayerPrefs.SetInt("LevelNo", lvlno);



            SceneManager.LoadScene("Win");
            print("Success");
        }
        else
        {
            Wrong.text = "Wrong!!!";
            print("Fail");
            StartCoroutine(HideText());
        }
    }

    public void OnClickSkip()
    {
        ans = null;
        AnsBox.text = "";

        if (TotalLevel<=lvlno)
        {
            PlayerPrefs.SetInt("TotalLevel", lvlno);
        }
        PlayerPrefs.SetInt("skip_" + lvlno, lvlno);

        lvlno++;

        //PlayerPrefs.SetInt("LevelNo", lvlno);
        //SceneManager.LoadScene("Play");

        LevelBoard.text = "Puzzle " + lvlno;
        PzlImg.sprite = PzlBoard[lvlno - 1];
    }

    public void onClickHintBtn()
    {
        if (score>=20)
        {
            int hntlvl = PlayerPrefs.GetInt("LevelNo", 1);
            HintBox.text = ""+Hint[hntlvl-1];

            PlayerPrefs.SetInt("hint_" + hntlvl, hntlvl);

            score = PlayerPrefs.GetInt("GameScore", 0);
            score -= 20;
            //score -= 30;
            PlayerPrefs.SetInt("GameScore", score);

            StartCoroutine(HideText());
        }
        else
        {
            HintBox.text = "You can not use hint, Because you have not enough score!!";
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);
        Wrong.text = "";
        HintBox.text = "";
    }
}
