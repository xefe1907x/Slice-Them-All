using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    int currentLevel;
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            RestartLevel();
            Invoke(nameof(LoadScene),1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(currentLevel);
    }

    void RestartLevel()
    {
        GameController.isGameStarted = false;
        KnifePool.isknifeInstantiated = false;
        KnifeBar.isBarInstantiated = true;
    }
}
