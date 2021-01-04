using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SendChangeColorExample : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(hasAuthority) CmdRandomMove();
    }

    [Command]
    void CmdRandomMove()
    {
        Vector3 offset = new Vector3(Random.Range(-5 ,5),Random.Range(-5 ,5),Random.Range(-5 ,5));
        RpcRandomMove(offset);
    }

    [ClientRpc]
    void RpcRandomMove(Vector3 v)
    {
        transform.position += v;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasAuthority)
        {
            CmdRandomColor();
        }
    }

    [Command]
    void CmdRandomColor()
    {
        ColorMessage msg = new ColorMessage()
        {
            color = RandomColor()
        };

        NetworkServer.SendToAll(msg);
    }

    Color RandomColor()
    {
        Color background = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f)
        );

        return background;

    }


}
