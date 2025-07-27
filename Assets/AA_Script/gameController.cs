using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class gameController : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreText;
    public static gameController instance;


    void Start()
    {
        totalScore = 0;
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}