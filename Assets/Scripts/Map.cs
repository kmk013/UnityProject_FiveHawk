using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

    public float speed = 100;
    public GameObject gameObject;

    private void Start()
    {
        gameObject = transform.Find("Boss").gameObject;
    }

    void Update () {
        if (transform.position.y >= -3024)
            transform.position -= transform.up * speed * Time.deltaTime;
        else
        {
            if (Application.loadedLevelName.Equals("GameScene"))
                SceneManager.LoadScene("StoryScene 1");
            else if (Application.loadedLevelName.Equals("GameScene 1"))
                SceneManager.LoadScene("VictoryScene");
        }
	}
}
