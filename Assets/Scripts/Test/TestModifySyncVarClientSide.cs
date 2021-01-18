using Mirror;
using UnityEngine;

namespace Test
{
    public class TestModifySyncVarClientSide : NetworkBehaviour
    {
        [SyncVar] private int life = 10;

        public TextMesh textMesh;
        void Update()
        {
            textMesh.text = life.ToString();
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                life++;
                transform.name = "Player with life " + life;
                Toto();
            }
        }

        [Command]
        void Toto()
        {
            life *= 2;
            Tata();
        }

        [ClientRpc]
        void Tata()
        {
        
        }
    }
}
