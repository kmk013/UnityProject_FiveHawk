using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerQuality
{
    FIRE,
    WATER,
    SOIL,
    ICE,
    WIND
}

public class GameManager : SingleTon<GameManager> {

    public bool isTouchPlayer = false;
    public PlayerQuality playerQuality;
    public bool isBad = false;
    public int score = 0;

    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () {
        if (Application.loadedLevelName.Contains("GameScene"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D ray = new Ray2D(wp, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null)
                {
                    if (hit.collider.name.Contains("Player"))
                        isTouchPlayer = true;
                    else
                        isTouchPlayer = false;
                }
            }
            else if (Input.GetMouseButtonUp(0))
                isTouchPlayer = false;

            GameObject.Find("Slider").GetComponent<Slider>().value = GameObject.Find("Player").GetComponent<Player>().hp;

            if (GameObject.Find("Player").GetComponent<Player>().hp <= 0)
                StartCoroutine(GameObject.Find("Player").GetComponent<Player>().Die());
        }
        else if (Application.loadedLevelName.Equals("CharacterScene"))
        {
            GameObject showPlayer = GameObject.Find("Player");
            Text infoText = GameObject.Find("InfoText").GetComponent<Text>();
            Animator animator = showPlayer.GetComponent<Animator>();
            switch (playerQuality)
            {
                case PlayerQuality.FIRE:
                    animator.SetBool("isWater", false);
                    animator.SetBool("isSoil", false);
                    animator.SetBool("isIce", false);
                    animator.SetBool("isWind", false);
                    animator.SetBool("isFire", true);
                    infoText.text = "크기와 데미지가 크지만 불이 조금 남게 된다";
                    break;
                case PlayerQuality.WATER:
                    animator.SetBool("isFire", false);
                    animator.SetBool("isSoil", false);
                    animator.SetBool("isIce", false);
                    animator.SetBool("isWind", false);
                    animator.SetBool("isWater", true);
                    infoText.text = "얼음보다 크기가 작은 대신 데미지가 크다";
                    break;
                case PlayerQuality.SOIL:
                    animator.SetBool("isFire", false);
                    animator.SetBool("isWater", false);
                    animator.SetBool("isIce", false);
                    animator.SetBool("isWind", false);
                    animator.SetBool("isSoil", true);
                    infoText.text = "처음 발사 했을 때 크기와 데미지가 크지만\n멀리갈수록 크기와 데미지가 감소된다";
                    break;
                case PlayerQuality.ICE:
                    animator.SetBool("isFire", false);
                    animator.SetBool("isWater", false);
                    animator.SetBool("isSoil", false);
                    animator.SetBool("isWind", false);
                    animator.SetBool("isIce", true);
                    infoText.text = "물보다 크기가 큰 대신 데미지가 적다";
                    break;
                case PlayerQuality.WIND:
                    animator.SetBool("isFire", false);
                    animator.SetBool("isWater", false);
                    animator.SetBool("isSoil", false);
                    animator.SetBool("isIce", false);
                    animator.SetBool("isWind", true);
                    infoText.text = "처음 발사 했을 때 크기와 데미지가 적지만\n멀리갈수록 크기와 데미지가 증가한다";
                    break;
            }
        }
        if(Application.loadedLevelName.Equals("BadScene"))
        {
            Text text = GameObject.Find("ScoreText").GetComponent<Text>();
            text.text = "최종점수 : " + (GameManager.Instance.score).ToString();
        }
    }

    
}
