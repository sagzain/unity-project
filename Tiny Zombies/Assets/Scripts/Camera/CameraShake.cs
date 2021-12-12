using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _shakeVibrato;
    public void ShakeCamera()
    {
        Camera.main.DOShakePosition(_shakeDuration, _shakeStrength, _shakeVibrato);
    }
}
