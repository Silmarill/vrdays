using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour {

    public float minAngle;
    public float maxAngle;
    public float speedRotate;
    private bool isEnded = true;
    private Transform _tr;
    private Quaternion _endRot;
    private bool isLeft= true;
    // Use this for initialization
    void Awake() {
        _tr = GetComponent <Transform>();
    }

    void OnEnable() {
        _tr.rotation = Quaternion.Euler(minAngle, 0, 0);
         _endRot = Quaternion.Euler(maxAngle, 0, 0);
        isEnded = false;
    }

    void Generate() {
        isLeft = !isLeft;
        if (isLeft) {
            _endRot = Quaternion.Euler(maxAngle, 0, 0);
        } else {
            _endRot = Quaternion.Euler(minAngle, 0, 0);
        }
        isEnded = false;
    }


    // Update is called once per frame
    void Update() {
        if (isEnded) return;
        _tr.rotation = Quaternion.RotateTowards(_tr.rotation, _endRot, speedRotate * Time.deltaTime);
        if (_tr.rotation == _endRot) {
            isEnded = true;
           Generate();
        }
    }
}
