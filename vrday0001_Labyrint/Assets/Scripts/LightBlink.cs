using UnityEngine;
using System.Collections;

public class LightBlink : MonoBehaviour {
    public float minIntensity;
    public float maxIntensity;
    public float speed;

    private bool isEnded;



    private float startPos;
    private float toPos;


    private float newIntensity;
    private Light _l;

    void randomToPos() {
        toPos = Random.Range(minIntensity, maxIntensity);
        isEnded = false;
    }

    void Awake() {
        _l = GetComponent <Light>();
    }

    // Use this for initialization
    void OnEnable() {
        startPos = _l.intensity;       
        randomToPos();
    }



    void Update() {
        if (isEnded) return;
        _l.intensity = Mathf.MoveTowards(_l.intensity, toPos, speed);
        
        if (_l.intensity == toPos) {
            toPos = 0;
        } else {
            isEnded = true;
            randomToPos();
        }
    }
}

