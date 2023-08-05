using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    private GameObject _panel;
    private GameObject _clear;
    private int ClearScore;
    // Start is called before the first frame update
    void Start()
    {
        _panel = transform.Find("Panel").gameObject;
        _clear = transform.Find("Clear").gameObject;
        _panel.SetActive(false);
        _clear.SetActive(false);
        ClearScore = 490;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreCounter.score>=ClearScore)
        {
            StartCoroutine("ClearMethod");
        }
    }

    IEnumerator ClearMethod()
    {
        _panel.SetActive(true);
        _clear.SetActive(true);
        BallBehavior.BallFinish = true;

        yield return new WaitForSeconds(3);

        BallBehavior.BallFinish = false;
        ScoreCounter.score = 0;
        SceneManager.LoadScene("StartScene");
    }
}
