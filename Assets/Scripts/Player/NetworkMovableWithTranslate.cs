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
        
        [SyncVar(hook = nameof(OnLeftKeyChanged))] private bool leftKey;
        [SyncVar] private bool rightKey;
        [SyncVar] private bool upKey;
        [SyncVar] private bool downKey;

        private bool leftKeyClient;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            position = transform.position;
            rotation = transform.rotation.eulerAngles;
        }
        
        private void Update()
        {
            
            if (ClientScene.localPlayer.gameObject == this.gameObject)
            {
                Controls();
            }

            if (isServer)
            {
                MoveFromInput();
            }

            if (isClient)
            {
                transform.position = position;
                transform.rotation = Quaternion.Euler(rotation);
            }

        }

        // Coté client à jour
        void OnLeftKeyChanged(bool prevLeftKeyState, bool newLeftKeyState)
        {
            Debug.Log("Switch left key state from " + prevLeftKeyState + " to " + newLeftKeyState );
        }

        [Server]
        void MoveFromInput()
        {
            if (leftKey)
            {
                transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }
            
            if (rightKey)
            {
                transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }

            if (upKey)
            {
                transform.Translate(new Vector3(0,0,1) * Time.deltaTime * (moveSpeed));
            }
            
            if (downKey)
            {
                transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * (moveSpeed));
            }

            position = transform.position;
            rotation = transform.rotation.eulerAngles;


        }

        
        
        
        // Appellé par le serveur
        [ClientRpc]
        void RpcMove()
        {
            
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

        
        public void Controls()
        {
            
            //
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CmdOnPressKey((byte) Direction.Left);
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CmdOnPressKey((byte) Direction.Right);
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CmdOnPressKey((byte) Direction.Up);
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CmdOnPressKey((byte) Direction.Down);
            }
            
            //
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                CmdOnReleaseKey((byte) Direction.Left);
            }
            
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                CmdOnReleaseKey((byte) Direction.Right);
            }
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                CmdOnReleaseKey((byte) Direction.Up);
            }
            
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                CmdOnReleaseKey((byte) Direction.Down);
            }
            
            // if (Input.GetKey(KeyCode.LeftArrow))
            // {
            //     RotateInServer(Direction.Left);
            // }
            //
            // if (Input.GetKey(KeyCode.RightArrow))
            // {
            //     RotateInServer(Direction.Right);
            // }
            //
            // if (Input.GetKey(KeyCode.UpArrow))
            // {
            //     MoveInServer(Direction.Up);
            // }
            //
            // if (Input.GetKey(KeyCode.DownArrow))
            // {
            //     MoveInServer(Direction.Down);
            // }
        }

        [Command]
        void CmdOnPressKey(byte directionByte)
        {
            Direction direction = (Direction)directionByte;

            if (direction == Direction.Up)
            {
                upKey = true;
            }
            
            if (direction == Direction.Down)
            {
                downKey = true;
            }
            
            if (direction == Direction.Left)
            {
                leftKey = true;
            }
            
            if (direction == Direction.Right)
            {
                rightKey = true;
            }
            
        }

        [Command]
        void CmdOnReleaseKey(byte directionByte)
        {
            Direction direction = (Direction)directionByte;
            
            if (direction == Direction.Up)
            {
                upKey = false;
            }
            
            if (direction == Direction.Down)
            {
                downKey = false;
            }
            
            if (direction == Direction.Left)
            {
                leftKey = false;
            }
            
            if (direction == Direction.Right)
            {
                rightKey = false;
            }
        }
        

        [Server]
        void RotateInServer(Direction direction)
        {
            if (direction == Direction.Left)
            {
                transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }

            if (direction == Direction.Right)
            {
                transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }
            
        }
        
        [Server]
        void MoveInServer(Direction direction)
        {
            if (direction == Direction.Up)
            {
                transform.Translate(new Vector3(0,0,1) * (moveSpeed));
            }
            
            if (direction == Direction.Down)
            {
                transform.Translate(new Vector3(0,0,-1) * (moveSpeed));
            }
        }

    }

}