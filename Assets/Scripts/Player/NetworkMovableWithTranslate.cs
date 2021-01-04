using System;
using Mirror;
using UnityEngine;

namespace Player
{
    // Un script pour tous les objets qu'on déplacera dans le Multiplayer par la méthode transform.Translate
    public class NetworkMovableWithTranslate : NetworkBehaviour, INetworkMovable
    {
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        protected float moveSpeed = 1.0f;
        protected float rotateSpeed = 1.0f;
        
        

        // Start is called before the first frame update
        void Start()
        {
            
        }

      
        void Update()
        {

            Debug.Log(ClientScene.localPlayer);
            Debug.Log(ClientScene.localPlayer.gameObject == this.gameObject);

            // 
            if (ClientScene.localPlayer.gameObject == this.gameObject)
            {
                Controls();
            }
        }

        // fonction Executée coté serveur
        [Command]
        void CmdMove(byte directionByte)
        {
            Direction direction = (Direction) directionByte;

            if (direction == Direction.Left)
            {
                RpcRotate(directionByte);
            }

            if (direction == Direction.Right)
            {
                RpcRotate(directionByte);
            }
            
            if (direction == Direction.Up)
            {
                RpcMove(new Vector3(0,0,1) * Time.deltaTime * (moveSpeed));
            }

            if (direction == Direction.Down)
            {
                RpcMove(new Vector3(0,0,-1) * Time.deltaTime * (moveSpeed));
            }
        }

        // fonction Executée sur tous les joueurs correspondants des clients 
        [ClientRpc]
        void RpcMove(Vector3 v)
        {
            transform.Translate(v);
        }

        [ClientRpc]
        void RpcRotate(byte directionByte)
        {
            Direction direction = (Direction)directionByte;
            
            if (direction == Direction.Left)
            {
                transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }

            if (direction == Direction.Right)
            {
                transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }

        }

        public void Controls()
        {
            
            double now = NetworkTime.time;

            int i1 = Convert.ToInt32(now);

            
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                CmdMove((byte) Direction.Left);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                CmdMove((byte) Direction.Right);
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                CmdMove((byte) Direction.Up);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                CmdMove((byte) Direction.Down);
            }
        }

    }

}