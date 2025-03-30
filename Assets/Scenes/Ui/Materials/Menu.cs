using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // ฟังก์ชันสำหรับปุ่ม Start
    public void StartGame()
    {
        Debug.Log("Start button clicked!");
        SceneManager.LoadScene("Gameplay"); 
    }

    // ฟังก์ชันสำหรับปุ่ม Quit
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}