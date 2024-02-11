using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int lvlno = 0, TotalLevel = 0;
    public Button[] BtnAry;
    public Sprite tick;
    public Page[] page; 

    private void OnEnable()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);
        TotalLevel = PlayerPrefs.GetInt("TotalLevel", 0);

        for(int i=0;i<=TotalLevel;i++)
        {
            BtnAry[i].interactable = true;
            BtnAry[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
           
            if(i < TotalLevel)
            {
                if (PlayerPrefs.HasKey("skip_" + (i + 1)))
                {
                    BtnAry[i].GetComponent<Image>().sprite = null;
                }
                else
                {
                    BtnAry[i].GetComponent<Image>().sprite = tick;
                }
                //BtnAry[i].GetComponent<Image>().sprite = tick;
            }
            else
            {
                BtnAry[i].GetComponent<Image>().sprite = null; 
            }
        }
    }
    public void onClickLevelNo(int n)
    {
        PlayerPrefs.SetInt("LevelNo", n);
        SceneManager.LoadScene("Play");
    }

}
