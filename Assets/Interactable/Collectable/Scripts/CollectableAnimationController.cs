using UnityEngine;
using DG.Tweening;

namespace AngryKoala.Interaction
{
    public class CollectableAnimationController : MonoBehaviour
    {
        [SerializeField] protected Transform visual;

        [Header("Idle")]
        [SerializeField] protected float verticalMovementAmount;
        [SerializeField] protected float verticalMovementDuration;

        [SerializeField] protected float rotationSpeedX;
        [SerializeField] protected float rotationSpeedY;
        [SerializeField] protected float rotationSpeedZ;

        [SerializeField] protected float scaleAmount;
        [SerializeField] protected float scaleDuration;

        [Header("Collection")]
        [SerializeField] protected AnimationCurve collectionCurve;

        [SerializeField] protected Vector2 collectionXAmount;
        [SerializeField] protected Vector2 collectionYAmount;
        [SerializeField] protected Vector2 collectionZAmount;

        [SerializeField] protected float collectionScaleAmount;

        [SerializeField] protected Vector3 collectionTargetOffset;
        [SerializeField] protected float collectionDuration;

        private void Start()
        {
            PlayIdleAnimation();
        }

        protected virtual void PlayIdleAnimation()
        {
            visual.DOMove(visual.position + Vector3.up * verticalMovementAmount, verticalMovementDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);

            visual.DOBlendableLocalRotateBy(Vector3.right, rotationSpeedX, RotateMode.Fast).SetSpeedBased(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
            visual.DOBlendableLocalRotateBy(Vector3.up, rotationSpeedY, RotateMode.Fast).SetSpeedBased(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
            visual.DOBlendableLocalRotateBy(Vector3.forward, rotationSpeedZ, RotateMode.Fast).SetSpeedBased(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);

            visual.DOBlendableScaleBy(Vector3.one * scaleAmount, scaleDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

        public virtual void StopIdleAnimation()
        {
            DOTween.Kill(visual);
        }

        public virtual void PlayCollectionAnimation(Transform target)
        {
            Vector3 initialPosition = visual.position;
            Vector3 initialScale = visual.localScale;

            float posDeltaX = Random.Range(collectionXAmount.x, collectionXAmount.y) * Mathf.Sign(Random.Range(-1f, 1f));
            float posDeltaY = Random.Range(collectionYAmount.x, collectionYAmount.y);
            float posDeltaZ = Random.Range(collectionZAmount.x, collectionZAmount.y) * Mathf.Sign(Random.Range(-1f, 1f));

            float collectionProgress = 0f;

            Sequence collectionSequence = DOTween.Sequence();
            collectionSequence.SetEase(collectionCurve);
            collectionSequence.Append(DOTween.To(() => collectionProgress, x => collectionProgress = x, 1f, collectionDuration / 2f).SetEase(Ease.Linear).OnUpdate(() =>
            {
                visual.position = new Vector3(Mathf.Lerp(initialPosition.x, initialPosition.x + posDeltaX, collectionProgress),
                    Mathf.Lerp(initialPosition.y, initialPosition.y + posDeltaY, collectionProgress),
                    Mathf.Lerp(initialPosition.z, initialPosition.z + posDeltaZ, collectionProgress));

                visual.localScale = Vector3.Lerp(initialScale, Vector3.one * collectionScaleAmount, collectionProgress);
            }));
            collectionSequence.Append(DOTween.To(() => collectionProgress, x => collectionProgress = x, 0f, collectionDuration / 2f).SetEase(Ease.Linear).OnUpdate(() =>
            {
                visual.position = new Vector3(Mathf.Lerp(target.position.x + collectionTargetOffset.x, initialPosition.x + posDeltaX, collectionProgress),
                    Mathf.Lerp(target.position.y + collectionTargetOffset.y, initialPosition.y + posDeltaY, collectionProgress),
                    Mathf.Lerp(target.position.z + collectionTargetOffset.z, initialPosition.z + posDeltaZ, collectionProgress));

                visual.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * collectionScaleAmount, collectionProgress);
            }));
            collectionSequence.AppendCallback(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
