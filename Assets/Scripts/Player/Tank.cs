using UnityEngine;
using Mirror;

public class Tank : NetworkBehaviour
{
    public int DamagesDealed = 10;
    [SyncVar]
    public int hp = 100;
    public TextMesh textLife;

    public GameObject vfxFire;
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

            if(hasAuthority) CmdOnBeingHit();

            Destroy(other.gameObject);
        }
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    [Command]
    void CmdOnBeingHit()
    {
        hp -= DamagesDealed;
        
        if (hp <= 0)
        {
            GameObject flame = Instantiate(vfxFire, transform.position, Quaternion.identity);
            NetworkServer.Spawn(flame);
        }
        
        RpcOnBeingHit();
    }

    [ClientRpc]
    void RpcOnBeingHit()
    {
        // TODO : mettre à jour l'UI de la vie du tank si il s'agit du tank du local player

        
    }
}
