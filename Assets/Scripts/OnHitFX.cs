using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitFX : MonoBehaviour
{
    [SerializeField] private Material onHitMaterial;
    [SerializeField] private Material originalMaterial;
    private SpriteRenderer sr;
    private void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
    }
    private IEnumerator FlashFX()
    {
        sr.material = onHitMaterial;
        yield return new WaitForSeconds(0.2f);
        sr.material=originalMaterial;
    }
}
