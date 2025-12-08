using UnityEngine;
using UnityEngine.SceneManagement;
/* 
 * This script allows a GameObject to load a specified scene when a method is called.
*/

public class GoToSceneByClick : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public void LoadGameScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No scene name assigned in the Inspector!");
        }
    }
}
