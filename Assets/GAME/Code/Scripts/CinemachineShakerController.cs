using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
public class CinemachineShakerController : MonoBehaviour
{
    private CinemachineCamera _camera;
    private CinemachineBasicMultiChannelPerlin m_MultiChannelPerlin;

    private void Awake()
    {
        _camera = GetComponent<CinemachineCamera>();
        m_MultiChannelPerlin = _camera != null ? m_MultiChannelPerlin = GetComponent<CinemachineBasicMultiChannelPerlin>() : null;
        ResetIntensity();
    }

    public void ShakeCamera(float intensity, float shakeTime)
    {
        m_MultiChannelPerlin.AmplitudeGain = intensity;
        StartCoroutine(WaitTime(shakeTime));
    }

    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();
    }

    void ResetIntensity()
    {
        m_MultiChannelPerlin.AmplitudeGain = 0f;
    }

}
