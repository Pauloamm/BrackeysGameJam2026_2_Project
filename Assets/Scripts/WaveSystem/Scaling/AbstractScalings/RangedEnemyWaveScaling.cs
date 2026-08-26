using UnityEngine;

public abstract class RangedEnemyWaveScaling : WaveScalingBase
{
    [Header("Stop Distance Scaling")]
    [SerializeField] private float stopDistanceIncrementAmount = 0f;
    [SerializeField] private int wavesPerStopDistanceIncrement = 1;

    public float GetScaledStopDistance(float baseStopDistance, int waveNumber)
    {
        return SteppedLinear(baseStopDistance, stopDistanceIncrementAmount, wavesPerStopDistanceIncrement, waveNumber);
    }
}