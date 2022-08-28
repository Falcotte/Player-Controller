using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Camera uICamera;
    public Camera UICamera => uICamera;
}
