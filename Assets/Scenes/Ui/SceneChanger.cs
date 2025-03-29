using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // ชื่อซีนที่คุณต้องการให้เปลี่ยนไป

    void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าวัตถุที่ชนเป็นตัวละครหรือไม่ (คุณอาจต้องปรับแต่งเงื่อนไขนี้)
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2); // เปลี่ยนไปซีนที่ระบุ
        }
    }
}