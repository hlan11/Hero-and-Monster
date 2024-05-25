using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TestShake : MonoBehaviour
{
    [SerializeField] private float timeShake;
    private void Start()
    {
        transform.DOShakePosition(timeShake, new Vector3(2, 2, 2));
        
    }
}
