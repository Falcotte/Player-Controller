using UnityEngine;
using AngryKoala.Extensions;
using AngryKoala.Inputs;

namespace AngryKoala.PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform visual;
        public Transform Visual => visual;

        [SerializeField] private Rigidbody playerRigidbody;
        public Rigidbody PlayerRigidbody => playerRigidbody;
        [SerializeField] private Animator playerAnimator;
        public Animator PlayerAnimator => playerAnimator;

        [SerializeField] private ParticleSystem moveParticles;
        private ParticleSystem.EmissionModule moveEmission;

        [SerializeField] private float maxMoveSpeed;
        private float currentMoveSpeed;
        public float CurrentMoveSpeed => currentMoveSpeed;

        [SerializeField] private float rotationSpeed;
        public float RotationSpeed => rotationSpeed;

        private Vector3 moveDirection;
        public Vector3 MoveDirection => moveDirection;

        private bool isMoving;
        public bool IsMoving => isMoving;

        public bool IsControllable { get; set; }

        private void Start()
        {
            IsControllable = true;

            moveEmission = moveParticles.emission;
        }

        private void Update()
        {
            if(IsControllable)
            {
                HandleMovement();
                HandleRotation();
            }
        }

        private void FixedUpdate()
        {
            if(IsControllable)
            {
                Move();
            }
        }

        #region Movement

        private Vector3 SetMovementDirection(Vector2 direction)
        {
            Vector3 newDirection = Vector3.right * direction.x + Vector3.forward * direction.y;
            newDirection.Normalize();

            return new Vector3(newDirection.x, 0f, newDirection.z);
        }

        public void StopMovement()
        {
            currentMoveSpeed = 0f;
            moveEmission.enabled = false;

            isMoving = false;
        }

        private void HandleMovement()
        {
            if(InputManager.Instance.InputAreas[0].IsTouching)
            {
                moveDirection = SetMovementDirection(InputManager.Instance.InputAreas[0].Direction);

                if(moveDirection.sqrMagnitude > 0f)
                {
                    currentMoveSpeed = maxMoveSpeed;
                    moveEmission.enabled = true;

                    isMoving = true;
                }
                else
                {
                    StopMovement();
                }
            }
            else
            {
                StopMovement();
            }

            playerAnimator.SetBool("IsMoving", isMoving);
        }

        private void Move()
        {
            playerRigidbody.MovePosition(playerRigidbody.position + (moveDirection * currentMoveSpeed * Time.fixedDeltaTime));
        }

        #endregion

        #region Rotation

        private void HandleRotation()
        {
            if(InputManager.Instance.InputAreas[0].IsTouching)
            {
                transform.LookAtGradually(transform.position + moveDirection, rotationSpeed * Time.deltaTime, true);
            }
        }

        #endregion
    }
}

