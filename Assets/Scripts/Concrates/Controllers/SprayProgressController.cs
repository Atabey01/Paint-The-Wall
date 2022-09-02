using UnityEngine;
using TPSRunerGame.Controllers;

public class SprayProgressController : MonoBehaviour
{
    public static int CurrentSprayCount = 0;


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spray"))
            return;

        CurrentSprayCount++;
        GameManager.Instance.SprayCollected(CurrentSprayCount);
        Destroy(other.gameObject);
    }
}
