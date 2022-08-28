using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoSingleton<LoadingManager>
{
    [SerializeField] private List<string> scenes;

    protected override void Awake()
    {
        base.Awake();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        LoadScenes();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetActiveScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }

    private void LoadScenes()
    {
        foreach(var scene in scenes)
        {
            if(!IsSceneOpen(scene))
            {
                Debug.Log($"Loading {scene}");
                SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            }
        }
    }

    #region Helpers

    private void SetActiveScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.SetActiveScene(scene);
    }

    private bool IsSceneOpen(string name)
    {
        var sceneCount = SceneManager.sceneCount;
        for(int i = 0; i < sceneCount; i++)
        {
            if(SceneManager.GetSceneAt(i).name == name)
            {
                return true;
            }
        }
        return false;
    }

    #endregion
}
