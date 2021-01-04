using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;


// MainCamera
public class AssignCameraOnLocalPlayer : MonoBehaviour
{
    private bool assigned = false;

    public float camDistanceToLocalPlayerBackWard = 10;
    public float camDistanceToLocalPlayerUp = 10;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (assigned) return;
        
        // Si on a un Local Player
        if (ClientScene.localPlayer)
        {
            // on assigne la caméra à ce joueur UNE SEULE FOIS SEULEMENT
            assigned = true;

            Transform localPlayer = ClientScene.localPlayer.transform;
            transform.position = localPlayer.position + 
                                 - localPlayer.forward * camDistanceToLocalPlayerBackWard
                                 + localPlayer.up * camDistanceToLocalPlayerUp;
            transform.parent = localPlayer.transform;
        }
        
        
    }
}
