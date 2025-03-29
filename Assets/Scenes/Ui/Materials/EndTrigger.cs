using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("eweeee");
            SceneManager.LoadScene(2);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}