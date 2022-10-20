using UnityEngine;

namespace AngryKoala.PlayerControls
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        public PlayerController PlayerController => playerController;
    }
}