using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    // game parameters
    public static float sensitivity = 3.0f;
    public static int limitedTime = 120;
    public static float maximumSpeed = 15.0f;
    public static float acceleration = 0.050f;
    public static float friction = 0.9990f;

    // experiment parameters
    public static bool fish = true;
    public static bool gameAnimation = true;
    public static bool respawn = true;
    public static bool continuousPlay = false;
    public static float waitTimeNext = 5.0f;

    // for development
    public static bool usePhysics = true;
}
