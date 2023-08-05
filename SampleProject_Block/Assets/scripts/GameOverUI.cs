using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private GameObject _panel;
    private GameObject _gameover;
    // Start is called before the first frame update
    void Start()
    {
        _panel = transform.Find("Panel").gameObject;
        _gameover = transform.Find("GameOver").gameObject;
        _panel.SetActive(false);
        _gameover.SetActive(false);
    }

    void Update()
    {
        if (BallBehavior.BallFinish & BallBehavior.BallOver)
        {
            //Debug.Log("GameOver");
            StartCoroutine("GameOver");
        }

    }

    IEnumerator GameOver()
    {
        _panel.SetActive(true);
        _gameover.SetActive(true);

        yield return new WaitForSeconds(3);

        BallBehavior.BallFinish = false;
        SceneManager.LoadScene("StartScene");
    }
}