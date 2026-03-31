using UnityEngine;

[System.Serializable]
public class BlizzardData
{
    [SerializeField]
    private float playerPushValue;
    [SerializeField]
    private Vector3 particleWindVelocity;
    [SerializeField]
    private Vector3 windAreaScale;
    
    public float PlayerPushValue => playerPushValue;
    public Vector3 ParticleWindVelocity => particleWindVelocity;
    public Vector3 WindAreaScale => windAreaScale;
}
