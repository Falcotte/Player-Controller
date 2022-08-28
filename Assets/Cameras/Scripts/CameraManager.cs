using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private Camera mainCamera;
    public Camera MainCamera => mainCamera;

    private UniversalAdditionalCameraData cameraData;

    private void Start()
    {
        SetCameraStack();
    }

    private void SetCameraStack()
    {
        cameraData = mainCamera.GetUniversalAdditionalCameraData();

        AddCameraToStack(UIManager.Instance.UICamera);
    }

    private void AddCameraToStack(Camera camera)
    {
        var cameraData = camera.GetUniversalAdditionalCameraData();
        cameraData.renderType = CameraRenderType.Overlay;

        this.cameraData.cameraStack.Add(camera);
    }
}
