using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectController : MonoBehaviour
{
    public GameObject[] effects;
    
    public CameraShake shake;

    public void PlayerDeathEffect(Transform transform)
    {
        Instantiate(effects[0], transform.position, Quaternion.identity);

        ShakeTheCamera();
    }
    public void WallBreakEffect(Transform transform)
    {
        Instantiate(effects[1], transform.position, Quaternion.identity);
    }
    public void BossDeathEffect(Transform transform)
    {
        Instantiate(effects[2], transform.position, Quaternion.identity);
    }
    public void GreenBallEffect(Transform transform)
    {
        Instantiate(effects[3], transform.position, Quaternion.identity);
    }
    public void RedBallEffect(Transform transform)
    {
        Instantiate(effects[4], transform.position, Quaternion.identity);
    }
    public void FloatingText(Transform transform, string diamondValue)
    {
        effects[5].GetComponent<TextMeshPro>().text = diamondValue;

        Instantiate(effects[5], transform.position, Quaternion.identity);

    }
    public void ShakeTheCamera()
    {
        StartCoroutine(shake.Shake(.10f, .3f));
    }
}
