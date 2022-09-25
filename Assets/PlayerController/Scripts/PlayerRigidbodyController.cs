using UnityEngine;
using AngryKoala.Inputs;

namespace AngryKoala.PlayerControls
{
    public class PlayerRigidbodyController : PlayerController
    {
        [SerializeField] private float maxMoveSpeed;
        private float currentMoveSpeed;
        public float CurrentMoveSpeed => currentMoveSpeed;

        private void FixedUpdate()
        {
            if(IsControllable)
            {
                Move();
            }
        }

        #region Movement

        protected override void HandleMovement()
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

        protected override void StopMovement()
        {
            currentMoveSpeed = 0f;
            moveEmission.enabled = false;

            isMoving = false;
        }

        #endregion
    }
}
