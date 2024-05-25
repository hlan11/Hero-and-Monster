using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestBoss : MonoBehaviour
{
    [SerializeField] private float timeScale;
    [SerializeField] private Vector3 targetScale;
   
    private void Start()
    {
        transform.DOScale(targetScale, timeScale);
        
    }
}
