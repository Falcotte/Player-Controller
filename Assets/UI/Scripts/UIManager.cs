using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Camera uICamera;
    public Camera UICamera => uICamera;

    [SerializeField] private TextMeshProUGUI collectableText;

    private void Start()
    {
        collectableText.text = "0";
    }

    public void UpdateCollectableText(int collectableAmount)
    {
        DOTween.Kill(collectableText.transform);

        collectableText.transform.localScale = Vector3.one;
        collectableText.transform.DOPunchScale(Vector3.one * 1.2f, .2f, 1, 1);

        collectableText.text = collectableAmount.ToString();
    }
}
