using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 5;
    public float speed = 1000.0f;

    private void Start()
    {
        switch (GameManager.Instance.playerQuality)
        {
            case PlayerQuality.FIRE:
                damage = 10;
                break;
            case PlayerQuality.WATER:
                damage = 4;
                break;
            case PlayerQuality.SOIL:
                damage = 10;
                StartCoroutine(ShootSoil());
                break;
            case PlayerQuality.ICE:
                damage = 3;
                break;
            case PlayerQuality.WIND:
                damage = 6;
                StartCoroutine(ShootWind());
                break;
        }

    }

    private void Update () {
        transform.position += transform.up * speed *  Time.deltaTime;
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator ShootSoil()
    {
        for(int i = 0; i < 5; i++)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f);
            damage -= 7 * 0.1f;
            yield return new WaitForSeconds(0.75f);
        }
    }
    private IEnumerator ShootWind()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.localScale += new Vector3(0.1f, 0.1f);
            damage += 3 * 0.1f;
            yield return new WaitForSeconds(0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Fire"))
        {
            collision.GetComponent<Fire>().hp -= damage;
            GameManager.Instance.score += 10;
            Destroy(this.gameObject);
        }

        if(collision.name.Contains("Boss"))
        {
            collision.GetComponent<Boss>().hp -= damage;
            GameManager.Instance.score += 10;
            Destroy(this.gameObject);
        }

        if (collision.name.Contains("Block"))
            Destroy(this.gameObject);
    }
}
