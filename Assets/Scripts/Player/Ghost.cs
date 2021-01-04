using System.Collections;
using System.Collections.Generic;
using Mirror;
using Telepathy;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ghost : MonoBehaviour
{
    Rigidbody rg;

    public float reachAmount = 10;

    public float reachRotationSlerp = 0.2f; // De 0 à 1
    
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ClientScene.localPlayer)
        {
            Transform target = ClientScene.localPlayer.transform;

            Vector3 diff = target.transform.position - transform.position;
            
            rg.MovePosition(transform.position + diff / reachAmount);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, reachRotationSlerp);
            
        }
    }

    
}
