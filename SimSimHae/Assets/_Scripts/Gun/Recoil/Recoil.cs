using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Recoil : MonoBehaviour
{
    public RecoilGraph[] recoils = new RecoilGraph[0];
    private int recoilIdx = 0;

    private Coroutine _routine = null;

    public void GiveRecoil()
    {
        if (_routine != null)
            StopCoroutine(_routine);

        _routine = StartCoroutine(RecoilRoutine());
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, recoils[recoilIdx].localpos, recoils[recoilIdx].t);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(recoils[recoilIdx].localeulerangle), recoils[recoilIdx].t);
    }

    IEnumerator RecoilRoutine()
    {
        for (recoilIdx = 1; recoilIdx < recoils.Length; ++recoilIdx)
        {
            yield return new WaitForSeconds(recoils[recoilIdx].time);
        }

        recoilIdx = 0;

    }
}


[Serializable]
public class RecoilGraph
{
    public float time = 0.0f;
    public Vector3 localpos = Vector3.zero;
    public Vector3 localeulerangle = Vector3.zero;
    public float t = 0.1f;
}