using UnityEngine;

public class BlizzardController : MonoBehaviour
{
    [SerializeField]
    private BlizzardData blizzardData;

    private ParticleSystem particle;

    private void OnValidate()
    {
        // エディタ上でインスペクターの値の変更をリアルタイムに反映（開発用）
        ApplyWind();
    }

    private void Start()
    {
        ApplyWind();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            Vector3 addedVelocity = blizzardData.ParticleWindVelocity.normalized * blizzardData.PlayerPushValue;
            playerController.AddVelocity(addedVelocity);
        }
    }

    private void ApplyWind()
    {
        if (!particle) { particle = GetComponentInChildren<ParticleSystem>(); }

        var main = particle.main;
        main.simulationSpace = ParticleSystemSimulationSpace.Local;

        var shape = particle.shape;
        shape.enabled = true;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = blizzardData.WindAreaScale;

        var velocity = particle.velocityOverLifetime;
        velocity.x = blizzardData.ParticleWindVelocity.x;
        velocity.y = blizzardData.ParticleWindVelocity.y;
        velocity.z = blizzardData.ParticleWindVelocity.z;
        velocity.space = ParticleSystemSimulationSpace.Local;
    }
}
