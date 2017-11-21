using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public float duration = 5;

    void Start ()
    {
        Invoke("Destroy", duration);
    }

    void Destroy(){ Destroy(gameObject); }
}