using UnityEngine;

public class SpinParticles : MonoBehaviour
{

    [SerializeField] private ParticleSystem ps;
    public PlayerController pC;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var rotationModule = ps.rotationOverLifetime;
        rotationModule.enabled = false;
    }

    void Update()
    {
        if (pC.isGrounded == false)
        {
            AddPsRotation();
        }
        else
        {
            StopPsRotation();
        }
    }

    void AddPsRotation()
    {
        var rotationModule = ps.rotationOverLifetime;
        rotationModule.enabled = true;
    }

    void StopPsRotation()
    {
        var rotationModule = ps.rotationOverLifetime;
        rotationModule.enabled = false;
    }
}
