using UnityEngine;
using System.Collections;

public class MarkerVolume : MonoBehaviour {

    private float _max;
    private float _currentMH;
    private float _currentMHnormalized;
    public Transform trObj;
    public Transform trExit;

    public Light L;
    public Color ColorCloth;
    public Color ColorFar;

    public AudioSource aus;
    
 
    public static float ManhattanDistance(Vector3 a, Vector3 b){
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z);
    }

    public void CheckMax(float a) {
        if (a > _max) {
            _max = a;
        }
    }
    
	void Update () {
	   _currentMH = ManhattanDistance(trExit.position, trObj.position);
         CheckMax(_currentMH);
	    _currentMHnormalized = _currentMH / _max;
        L.color = Color.Lerp (ColorCloth, ColorFar,_currentMHnormalized);
	    aus.volume = 0.8f-_currentMHnormalized;
	}
}
