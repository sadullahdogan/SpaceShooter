using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnBecameInvisible()//Obje kameradan belli bi mesafe uzaklaşınca yani kameraya görünmeyince çalışan 
                                    //fonksiyon
    {
          Destroy(gameObject);
        
        
    }
    void Update()
    {
        transform.position += transform.up * speed;
    }
   
}
