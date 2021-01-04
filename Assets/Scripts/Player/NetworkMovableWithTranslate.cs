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

        [SyncVar]
        private Vector3 position;

        [SyncVar]
        private Vector3 rotation;
        
        
        

        // Start is called before the first frame update
        void Start()
        {
            position = transform.position;
            rotation = transform.rotation.eulerAngles;
        }


        private void Update()
        {
            
            // Controls();
            
            // transform.position = position;
            // transform.rotation = Quaternion.Euler(rotation);
        }

        void FixedUpdate()
        {

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
                rotation = transform.rotation.eulerAngles + new Vector3(0,-1,0)  * (rotateSpeed);
                // RpcRotate(directionByte);
            }

            if (direction == Direction.Right)
            {
                rotation = transform.rotation.eulerAngles + new Vector3(0,1,0)  * (rotateSpeed);
                // RpcRotate(directionByte);
            }
            
            if (direction == Direction.Up)
            {
                position = transform.position + transform.forward * moveSpeed;
                // RpcMove(new Vector3(0,0,1) * (moveSpeed));
            }

            if (direction == Direction.Down)
            {
                position = transform.position - transform.forward * moveSpeed;
                // RpcMove(new Vector3(0,0,-1) * (moveSpeed));
            }
        }

        // fonction Executée sur tous les joueurs correspondants des clients 
        // [ClientRpc]
        // void RpcMove(Vector3 v)
        // {
        //     transform.Translate(v);
        // }
        //
        // [ClientRpc]
        // void RpcRotate(byte directionByte)
        // {
        //     Direction direction = (Direction)directionByte;
        //     
        //     if (direction == Direction.Left)
        //     {
        //         transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
        //     }
        //
        //     if (direction == Direction.Right)
        //     {
        //         transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
        //     }
        //
        // }
        
        

        public void Controls()
        {
            
            double now = NetworkTime.time;

            int i1 = Convert.ToInt32(now);

            
            // if (Input.GetKey(KeyCode.LeftArrow))
            // {
            //     CmdMove((byte) Direction.Left);
            // }
            //
            // if (Input.GetKey(KeyCode.RightArrow))
            // {
            //     CmdMove((byte) Direction.Right);
            // }
            //
            // if (Input.GetKey(KeyCode.UpArrow))
            // {
            //     CmdMove((byte) Direction.Up);
            // }
            //
            // if (Input.GetKey(KeyCode.DownArrow))
            // {
            //     CmdMove((byte) Direction.Down);
            // }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0,0,1) * (moveSpeed));
                // CmdMove((byte) Direction.Up);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0,0,-1) * (moveSpeed));
                // CmdMove((byte) Direction.Down);
            }
        }

    }

}