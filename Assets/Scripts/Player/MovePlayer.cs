using Mirror;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MovePlayer : NetworkBehaviour
{

    enum Direction
    {
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(ClientScene.localPlayer);
        Debug.Log(ClientScene.localPlayer.gameObject == this.gameObject);

        // 
        if (ClientScene.localPlayer.gameObject == this.gameObject)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                CmdMove((byte)Direction.Left);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                CmdMove((byte)Direction.Right);
            }
        }
    }

    // fonction Executée coté serveur
    [Command]
    void CmdMove(byte directionByte)
    {
        Direction direction = (Direction)directionByte;

        if (direction == Direction.Left)
        {
            RpcMove(-transform.right * Time.deltaTime);
        }

        if (direction == Direction.Right)
        {
            RpcMove(transform.right * Time.deltaTime);
        }
    }

    // fonction Executée sur tous les joueurs correspondants des clients 
    [ClientRpc]
    void RpcMove(Vector3 v)
    {
        transform.Translate(v);
    }

}
