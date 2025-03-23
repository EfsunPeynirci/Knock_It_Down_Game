using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] allBallImg;
    public GameObject backFg;
    public GameObject HomeUI, GameUI;
    public GameObject gameScene;

    public Sprite enabledBallImg;
    public Sprite disableBallImg;

    //Awake kullanarak diger sayfalardan bu sayfaya erisim saglayabilecegiz
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        HomeUI.SetActive(true);
        gameScene.SetActive(false);
    }


    public void UpdateBallIcons()
    {
        int ballCount = GameManager.instance.totalBalls;
        for (int i = 0; i < 5; i++)
        {
            if(i < ballCount)
            {
                allBallImg[i].GetComponent<Image>().sprite = enabledBallImg;
            }
            else
            {
                allBallImg[i].GetComponent<Image>().sprite = disableBallImg;
            }
        }
    }

    public void B_Start()
    {
        StartCoroutine(StartRoutine());
    }

    /*30 saniye beklenip HomeUI sayfasi kapatildi ve gameScene ile GameUI aktiflestirildi.
    HomeUI Start ve Exit butonlarinin bulundugu sayfa
    GameUI kisminda top atisinin gerceklestigi sayfada bulunan geri, durdurma ve puan tablosunun oldugu kiism
    gameScene'de ise top, atislar ve tenekelerin oldugu sayfa*/
    IEnumerator StartRoutine()
    {
        ShowBlackFade();
        yield return new WaitForSeconds(0.5f);
        HomeUI.SetActive(false);
        gameScene.SetActive(true);
        GameUI.SetActive(true);

        GameManager.instance.StartGame();
    }

    //Oyunun baslangicindaki animasyon kismi kapatildi.
    public void ShowBlackFade()
    {
        StartCoroutine(FadeRoutine());
    }

    //backFg denilen oyunun basindaki animasyon
    IEnumerator FadeRoutine()
    {
        backFg.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        backFg.SetActive(false);
    }

}
