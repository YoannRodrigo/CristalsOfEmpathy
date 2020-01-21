using UnityEngine;

public class PipeController : MonoBehaviour
{
    public ParticleSystem particlesSystem;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ParticleSystem.MainModule main = particlesSystem.main;
            particlesSystem.GetComponent<Renderer>().enabled = true;
            main.loop = true;
            particlesSystem.Clear();
            particlesSystem.Play();
        }
        else if(Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            ParticleSystem.MainModule main = particlesSystem.main;
            main.loop = false;
        }
    }
}