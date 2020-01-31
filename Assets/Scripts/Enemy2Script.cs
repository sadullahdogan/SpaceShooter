using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform bulletPosition;
    

    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Shoot() {
        GameObject bullet;
        if (GameController.gameController.GetCountRedBulletList() > 0)
        {
             bullet = GameController.gameController.GetRedBulletFromBulletList();
            bullet.transform.position = bulletPosition.transform.position;

        }
        else {
            Debug.Log("Merhaba Yelda");
           bullet= Instantiate(bulletPrefab, bulletPosition.position,Quaternion.identity);
        }
        //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * -500);
        Debug.Log("Merhaba Yeldaaaaaaaaaaa");
    }
    IEnumerator Fire() {
        float fireRate = Random.Range(2f, 5f);
        yield return new WaitForSeconds(fireRate);
        Shoot();
        yield return Fire();
    }
}
