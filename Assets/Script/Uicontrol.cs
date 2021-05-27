using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Uicontrol : MonoBehaviour
{
    public static string Dcode;
    public Text Restaurant;
    public GameObject main_panel;
    public GameObject[] infopanel;
    public GameObject moc_screen;
    public GameObject map_screen;
    public GameObject bt;
    public int bol = 0;
    public void GotoArScene()
    {
        SceneManager.LoadScene("ArSearch");
    }
    public void GotoSearch()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GotoSelect()
    {
        SceneManager.LoadScene("SelectDcode");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GotoSampleScene()
    {
        SceneManager.LoadScene("SelectDcode");
    }
    public void Gotoboack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void KKK()
    {
        Dcode = "한식";
    }
    public void CCC()
    {
        Dcode = "중식";
    }
    public void JJJ()
    {
        Dcode = "일식";
    }
    public void WWW()
    {
        Dcode = "양식";
    }
    public void XmlStart()
    {
        var app = GameObject.Find("Canvas").GetComponent<App>();
        bt.SetActive(false);
        Debug.Log(Dcode);
        app.AppControl(Dcode);
        //Debug.Log(Restaurant.text + "버튼누름");
    }
    public void momsinfo()
    {
        main_panel.SetActive(true);
        infopanel[0].SetActive(true);
        infopanel[1].SetActive(false);
        infopanel[2].SetActive(false);
    }
    public void dosmasinfo()
    {
        main_panel.SetActive(true);
        infopanel[1].SetActive(true);
        infopanel[0].SetActive(false);
        infopanel[2].SetActive(false);
    }
    public void fireinfo()
    {
        main_panel.SetActive(true);
        infopanel[2].SetActive(true);
        infopanel[0].SetActive(false);
        infopanel[2].SetActive(false);
    }
    public void menu_close()
    {
        main_panel.SetActive(false);
        infopanel[2].SetActive(false);
        infopanel[0].SetActive(false);
        infopanel[2].SetActive(false);
    }
    public void close_info()
    {
        GameObject.Find("Screen").SetActive(false);
    }
    public void Change_screen()
    {
        if(bol == 0)
        {
            moc_screen.SetActive(false);
            map_screen.SetActive(true);
            bol = 1;
        }
        else if(bol == 1)
        {
            moc_screen.SetActive(true);
            map_screen.SetActive(false);
            bol = 0;
        }
    }
}

