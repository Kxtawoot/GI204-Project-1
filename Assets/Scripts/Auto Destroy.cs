using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int time;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
