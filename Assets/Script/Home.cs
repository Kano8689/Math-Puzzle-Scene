using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void onClickContinue()
    {
        SceneManager.LoadScene("Play");
    }

    public void onClickPuzzle()
    {
        SceneManager.LoadScene("Level");
    }
}
