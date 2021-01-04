using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public int DamagesDealed = 10;
    public int hp = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject HitedPlayer = collision.gameObject;
            
            hp -= DamagesDealed;
            Destroy(collision.gameObject);
        }
    }
    void OnBeingHit()
    {

    }
}
