using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour 
{
    public static CameraShake Camera;
    private CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin virtualCameraParameters;

    private void Awake()
    {
        Camera = this;

        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        virtualCameraParameters = 
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        virtualCameraParameters.m_AmplitudeGain = magnitude;
        yield return new WaitForSeconds(duration);
        virtualCameraParameters.m_AmplitudeGain = 0f;

    }

    public void Explosion (Transform explosionPosition, float maxMagnitude, float duration)
    {
        GameObject player = GameObject.Find("Player");
        float distanceToPlayer = (player.transform.position - explosionPosition.position).magnitude;
        float shakeMagnitude = maxMagnitude - (distanceToPlayer / 2);
        StartCoroutine(CameraShake.Camera.Shake(duration, shakeMagnitude));
    }
}
