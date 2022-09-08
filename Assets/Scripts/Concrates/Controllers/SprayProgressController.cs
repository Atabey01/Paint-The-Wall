using UnityEngine;
using TPSRunerGame.Controllers;

public class SprayProgressController : MonoBehaviour
{
    [SerializeField] ParticleSystem _poofParticle;
    public static float CurrentSprayCount = 0;


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Spray"))
            return;

        CurrentSprayCount++;
        GameManager.Instance.SprayCollected(CurrentSprayCount);
        _poofParticle.transform.position = other.transform.position;
        _poofParticle.Play();
        Destroy(other.gameObject);
    }
}
