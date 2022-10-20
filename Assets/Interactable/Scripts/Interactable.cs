using UnityEngine;
using AngryKoala.PlayerControls;

namespace AngryKoala.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected Collider interactableCollider;

        protected virtual void OnTriggerEnter(Collider other)
        {
            other.gameObject.TryGetComponent(out PlayerCollisionHandler playerCollisionHandler);

            if(playerCollisionHandler)
            {
                Interact(playerCollisionHandler);
            }
        }

        protected virtual void Interact(PlayerCollisionHandler playerCollisionHandler)
        {
            interactableCollider.enabled = false;
        }
    }
}