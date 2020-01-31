using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnBecameInvisible()
    {
        RepoziteBacground();
    }
    void Update()
    {
        //if (reference.gameObject.transform.position.y < -30) {
        //    RepoziteBacground();
        //    
        //    
        //}
    }
    void RepoziteBacground()
    {
        //15,120.96,0 2. resmin kordinatlaro

        Vector2 vector = new Vector2(15, 120.96f);
        transform.position =vector;
    }
}
