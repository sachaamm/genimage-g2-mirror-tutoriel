using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Interactable
{
    
    public class InteractWithSceneObject : NetworkBehaviour
    {
        private float timeToChangeId = 2;
        private float counter = 0;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            counter += Time.deltaTime;
        
            if (counter > timeToChangeId)
            {
                if (isServer)
                {
                    SceneObjectWitoutAuthority.Singleton.ServerSetNewId();
                }
                // SceneObjectWitoutAuthority.Singleton.SetNewIdInSyncList();
                counter = 0;
            }
        }
        
    }

}