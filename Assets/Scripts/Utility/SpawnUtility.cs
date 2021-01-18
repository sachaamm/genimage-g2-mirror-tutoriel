using UnityEngine;

namespace Utility
{
    public class SpawnUtility
    {
        public static bool SpawnPointAvailable(GameObject spawnPoint, GameObject[] players, float distanceAvailable)
        {
            foreach (var player in players)
            {
                float distanceToPlayer = Vector3.Distance(spawnPoint.transform.position,player.transform.position);
                if(distanceToPlayer < distanceAvailable) return false;
            }
            
            return true;
        }
    }
}