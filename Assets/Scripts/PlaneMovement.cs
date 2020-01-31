using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlaneMovement : MonoBehaviour
{
    float yatay,dikey;
    public float planeSpeed;
    public GameObject bulletPrefab;
    public GameObject[] bulletsPos;
    private int bulletCount;
    AudioClip deadClip;
   
    // Start is called before the first frame update
    void Start()
    {
        bulletCount =1;
        planeSpeed = 2.5f   ;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameController.gameController.GetGameState()) {
            
                yatay = CrossPlatformInputManager.GetAxis("Horizontal") + Input.GetAxis("Horizontal");
                dikey = CrossPlatformInputManager.GetAxis("Vertical") + Input.GetAxis("Vertical");
                transform.position += transform.right * yatay / planeSpeed;
                transform.position += transform.up * dikey / planeSpeed;
                if (CrossPlatformInputManager.GetButtonDown("FireBtn") || Input.GetKeyDown(KeyCode.Space))
                {
                //ateş etmek için delay eklencek 
                GetComponent<AudioSource>().Play();
                for (int i = 0; i < bulletCount; i++)
                {
                   
                    Instantiate(bulletPrefab, bulletsPos[i].gameObject.transform.position, Quaternion.identity);
                    
                    //ekrana kodun içinden obje eklenebilir.
                }
                   
                }
      
            
        }

    }
 

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //   // if (collision.gameObject.CompareTag("Shield")) { 
        
    //    //shield.gameObject.SetActive(true);
    //   // }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        if (collision.gameObject.CompareTag("Astroid"))
        {

            GameController.gameController.DecreaseNumberOfLifes();
            if (GameController.gameController.GetNumberOfLifes() > 0)
            {
                GameController.gameController.RestartScene();
            }

        }
        if (collision.gameObject.CompareTag("UpgradeBullet"))
        {
            if (bulletCount < 3)
            {
                bulletCount++;
            }
            Destroy(collision.gameObject);
        }
        ///
        if(collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Geldi Enemy");
            GetComponent<PolygonCollider2D>().enabled = false;
            GameController.gameController.DecreaseNumberOfLifes();
            if (GameController.gameController.GetNumberOfLifes() > 0)
            {
                //GameController.gameController.RestartScene();
                GameController.gameController.RestartScene();
            }
            else
            {
                //end game panel
                GameController.gameController.SetGameState(false);
            }
        }
        if (collision.gameObject.CompareTag("Mine"))
        {
            Debug.Log("Geldi Mine");
            GetComponent<PolygonCollider2D>().enabled = false;
            //GameController.gameController.Addmine(collision.gameObject);
            //collision.gameObject.SetActive(false);
            GameController.gameController.DecreaseNumberOfLifes();
            if (GameController.gameController.GetNumberOfLifes() > 0)
            {
                GameController.gameController.RestartScene();
            }
            else
            {

                //end game panel
                GameController.gameController.SetGameState(false);
            }

        }

    }


}
