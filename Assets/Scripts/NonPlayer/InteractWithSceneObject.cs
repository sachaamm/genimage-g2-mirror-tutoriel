using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    
    public class InteractWithSceneObject : MonoBehaviour
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
                // SceneObjectWitoutAuthority.Singleton.RpcDefineId();
                SceneObjectWitoutAuthority.Singleton.SetNewIdInSyncList();
                counter = 0;
            }
        }
    }

}