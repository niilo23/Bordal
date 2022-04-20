using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;

    private void Start()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Loading scene" + sceneToLoad);
    }
}
