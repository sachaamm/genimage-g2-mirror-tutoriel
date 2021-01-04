using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Tank : NetworkBehaviour
{
    public int DamagesDealed = 10;
    [SyncVar]
    public int hp = 100;
    public TextMesh textLife;

    void Start()
    {
        
    }

    void Update()
    {
        textLife.text = hp.ToString();
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
