using eidng8.SpaceFlight.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;


// A behaviour that is attached to a playable
namespace Startup {
    public class Startup : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            GameManager.SceneLoaded(scene, mode);
        }
    }
}
