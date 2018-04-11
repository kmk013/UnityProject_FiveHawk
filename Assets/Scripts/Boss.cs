using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public float hp = 50;
    public GameObject bossBullet;

    private float shootInterval;

    private void Start()
    {
        if (Application.loadedLevelName.Equals("GameScene"))
        {
            shootInterval = 2.0f;
        } else if(Application.loadedLevelName.Equals("GameScene 1"))
        {
            shootInterval = 1.0f;
        }

        StartCoroutine(ShootBoss());
    }

    private void Update()
    {
        if (hp <= 0)
            Destroy(this.gameObject);
    }

    private IEnumerator ShootBoss()
    {
        while(hp > 0)
        {
            Instantiate(bossBullet, new Vector3(Random.Range(transform.position.x - 100, transform.position.x + 100), transform.position.y - 180, 0), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
