using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    private bool isBreath = true;

    public float MinHigh = 0.8f;
    public float MaxHigh = 0.9f;

    [Range (1f,3f)]
    public float Freakness = 1f;

    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBreath) {
            movement = Mathf.Lerp (movement, MaxHigh, Time.deltaTime * 1f * Freakness);
            transform.localPosition = new Vector3(transform.localPosition.x, movement, transform.localPosition.z);
            if (movement >= MaxHigh - 0.01f)
                isBreath = !isBreath;
        } else {
            movement = Mathf.Lerp (movement, MinHigh, Time.deltaTime * 1f * Freakness);
            transform.localPosition = new Vector3(transform.localPosition.x, movement, transform.localPosition.z);
            if (movement <= MinHigh + 0.01f)
                isBreath = !isBreath;
        }

        //restore freakness
        if(Freakness != 0f) Freakness = Mathf.Lerp(Freakness,1f,Time.deltaTime * 0.2f);
    }
}
