using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundSlider : MonoBehaviour
{

    private Rigidbody2D rg2;
    // Start is called before the first frame update

    void Start()
    {
        rg2 = GetComponent<Rigidbody2D>();
        rg2.velocity = new Vector2(0, -15f);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.gameController.GetGameState())
        {
            rg2 = GetComponent<Rigidbody2D>();
            rg2.velocity = Vector2.zero; 
            rg2.velocity = new Vector2(0, -15f);

        }
        else
        {
            rg2 = GetComponent<Rigidbody2D>();
            rg2.velocity = Vector2.zero;
        }
    }

}
