using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float hp = 3;
    public GameObject fireBullet, waterBullet, soilBullet, iceBullet, windBullet;

    private Transform shootPoint;
    private Animator animator;

    private void Start()
    {
        shootPoint = transform.GetChild(0);
        animator = GetComponent<Animator>();
        switch(GameManager.Instance.playerQuality)
        {
            case PlayerQuality.FIRE:
                animator.SetBool("isFire", true);
                break;
            case PlayerQuality.WATER:
                animator.SetBool("isWater", true);
                break;
            case PlayerQuality.SOIL:
                animator.SetBool("isSoil", true);
                break;
            case PlayerQuality.ICE:
                animator.SetBool("isIce", true);
                break;
        }

        StartCoroutine(BulletShoot());
    }

    private void Update () {
        if (GameManager.Instance.isTouchPlayer)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position += new Vector3(0, 0, 10);
        }
	}

    private IEnumerator BulletShoot()
    {
        while (true)
        {
            switch (GameManager.Instance.playerQuality)
            {
                case PlayerQuality.FIRE:
                    Instantiate(fireBullet, shootPoint.position, Quaternion.identity);
                    break;
                case PlayerQuality.WATER:
                    Instantiate(waterBullet, shootPoint.position, Quaternion.identity);
                    break;
                case PlayerQuality.SOIL:
                    Instantiate(soilBullet, shootPoint.position, Quaternion.identity);
                    break;
                case PlayerQuality.ICE:
                    Instantiate(iceBullet, shootPoint.position, Quaternion.identity);
                    break;
                case PlayerQuality.WIND:
                    Instantiate(windBullet, shootPoint.position, Quaternion.identity);
                    break;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Fire"))
        {
            hp -= collision.GetComponent<Fire>().damage;
        }
    }

    public IEnumerator Die()
    {
        float time = 0;
        while (time <= 3)
        {
            transform.Rotate(transform.forward);
            time += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("BadScene");   
    }
}
