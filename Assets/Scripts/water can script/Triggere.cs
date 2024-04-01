using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform object1;
    public Transform object2;
    public float activationDistance = 2f; // Adjust this value to change when the particles should start emitting

    private void Update()
    {
        if (Vector3.Distance(object1.position, object2.position) < activationDistance)
        {
            particles.Play();
        }
        else
        {
            particles.Stop();
        }
    }
}
