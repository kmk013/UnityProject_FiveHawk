using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //startScene
    public void GameStartButton()
    {
        SceneManager.LoadScene("StoryScene");
    }
    public void GameQuitButton()
    {
        Application.Quit();
    }

    //characterSelectScene
    public void FireSelectButton()
    {
        GameManager.Instance.playerQuality = PlayerQuality.FIRE;
    }
    public void WaterSelectButton()
    {
        GameManager.Instance.playerQuality = PlayerQuality.WATER;
    }
    public void SoilSelectButton()
    {
        GameManager.Instance.playerQuality = PlayerQuality.SOIL;
    }
    public void IceSelectButton()
    {
        GameManager.Instance.playerQuality = PlayerQuality.ICE;
    }
    public void WindSelectButton()
    {
        GameManager.Instance.playerQuality = PlayerQuality.WIND;
    }
    public void CharacterSelectButton()
    {
        GameManager.Instance.score = 0;
        SceneManager.LoadScene("GameScene");
    }

    //storyScene
    public void Story1Button()
    {
        GameObject.Find("Story1").SetActive(false);
    }
    public void Story2Button()
    {
        SceneManager.LoadScene("CharacterScene");
    }
    public void Story3Button()
    {
        SceneManager.LoadScene("GameScene 1");
    }
    public void VictoryButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void BadToStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
