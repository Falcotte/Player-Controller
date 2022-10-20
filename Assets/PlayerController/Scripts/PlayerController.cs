using UnityEngine;
using AngryKoala.Extensions;
using AngryKoala.Inputs;

namespace AngryKoala.PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] protected Transform visual;
        public Transform Visual => visual;

        [SerializeField] protected Rigidbody playerRigidbody;
        public Rigidbody PlayerRigidbody => playerRigidbody;
        [SerializeField] protected Animator playerAnimator;
        public Animator PlayerAnimator => playerAnimator;

        [SerializeField] protected ParticleSystem moveParticles;
        protected ParticleSystem.EmissionModule moveEmission;

        [SerializeField] protected float rotationSpeed;
        public float RotationSpeed => rotationSpeed;

        protected Vector3 moveDirection;
        public Vector3 MoveDirection => moveDirection;

        protected bool isMoving;
        public bool IsMoving => isMoving;

        public bool IsControllable { get; set; }

        private int collectedCollectables;
        public int CollectedCollectables => collectedCollectables;

        protected virtual void Start()
        {
            IsControllable = true;

            moveEmission = moveParticles.emission;
        }

        protected virtual void Update()
        {
            if(IsControllable)
            {
                HandleMovement();
                HandleRotation();
            }
        }

        protected virtual void HandleMovement()
        {

        }

        protected virtual Vector3 SetMovementDirection(Vector2 direction)
        {
            Vector3 newDirection = Vector3.right * direction.x + Vector3.forward * direction.y;
            newDirection.Normalize();

            return new Vector3(newDirection.x, 0f, newDirection.z);
        }

        protected virtual void StopMovement()
        {

        }

        protected virtual void HandleRotation()
        {
            if(InputManager.Instance.InputAreas[0].IsTouching)
            {
                transform.LookAtGradually(transform.position + moveDirection, rotationSpeed * Time.deltaTime, true);
            }
        }

        public void AdjustCollectedAmount(int amount)
        {
            collectedCollectables = amount;
            collectedCollectables = Mathf.Max(0, amount);
        }
    }
}

