using Mirror;

namespace Player
{
    // Un script pour tous les objets qu'on déplacera dans le Multiplayer par la méthode Rigidbody
    public class NetworkMovableWithRigidbody : NetworkBehaviour, INetworkMovable
    {
        public void Controls()
        {
            // Les controles pour déplacer un NetworkMovableWithRigidbody
        }
    }
}