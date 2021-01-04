﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Tank : NetworkBehaviour
{
    public int DamagesDealed = 10;
    public int hp = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject HitedPlayer = other.gameObject;

            CmdOnBeingHit();

            Destroy(other.gameObject);
        }
    }

    [Command]
    void CmdOnBeingHit()
    {
        hp -= DamagesDealed;

        RpcOnBeingHit();
    }

    [ClientRpc]
    void RpcOnBeingHit()
    {
        // TODO : mettre à jour l'UI de la vie du tank si il s'agit du tank du local player
    }
}
