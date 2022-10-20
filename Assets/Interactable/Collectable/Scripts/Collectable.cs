using UnityEngine;
using AngryKoala.PlayerControls;

namespace AngryKoala.Interaction
{
    public class Collectable : Interactable
    {
        [SerializeField] protected CollectableAnimationController animationController;

        [SerializeField] protected int amount;
        public int Amount => amount;

        protected override void Interact(PlayerCollisionHandler playerCollisionHandler)
        {
            base.Interact(playerCollisionHandler);

            playerCollisionHandler.PlayerController.AdjustCollectedAmount(playerCollisionHandler.PlayerController.CollectedCollectables + amount);

            animationController.StopIdleAnimation();
            animationController.PlayCollectionAnimation(playerCollisionHandler.transform);
        }
    }
}