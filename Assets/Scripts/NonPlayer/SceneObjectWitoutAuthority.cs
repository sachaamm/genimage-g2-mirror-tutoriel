using Mirror;
using UnityEngine;

namespace Interactable
{
    public class SceneObjectWitoutAuthority : NetworkBehaviour
    {

        [SyncVar] private int id;

        public TextMesh textMesh;

        private readonly SyncList<int> ids = new SyncList<int>();

        public static SceneObjectWitoutAuthority Singleton;
        private void Awake()
        {
            Singleton = this;
            
            ids.Add(RandomInt());
            
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            textMesh.text = ids[0].ToString();
        }

        [ClientRpc]
        public void RpcDefineId()
        {
            id = RandomInt();
        }

        [Server]
        public void SetNewIdInSyncList()
        {
            ids[0] = RandomInt();
        }

        int RandomInt()
        {
            return (int) Random.Range(0, 100);
        }
        
    }
}