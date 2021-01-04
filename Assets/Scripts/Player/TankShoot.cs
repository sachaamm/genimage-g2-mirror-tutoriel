using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class TankShoot : NetworkBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;

    public int shootPower = 100;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdCreateBullet();
        }
    }

    [Command]
    void CmdCreateBullet()
    {
        RpcCreateBullet();
    }

    [ClientRpc]
    void RpcCreateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.transform.position;
        Rigidbody rg = newBullet.GetComponent<Rigidbody>();
        
        rg.AddForce(transform.forward * shootPower);
        
    }
}