using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorring : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreTxt;
    private void Start()
    {
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        scoreTxt.text = "Score : " + score;
    }

    private IEnumerator AddScore()
    {
        score ++;
        yield return new WaitForSeconds(1);
        StartCoroutine(AddScore());
    }  
}
