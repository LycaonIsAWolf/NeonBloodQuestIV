using UnityEngine;
using System.Collections;

public class GlitchManager : MonoBehaviour {

	public Kino.AnalogGlitch analogGlitch;

	public static GlitchManager manager;

	void Start(){
		manager = this;
	}

	public void Glitch(){
		StartCoroutine(manager.IGlitch());
	}

	public IEnumerator IGlitch(){

		float val = 1f;

		analogGlitch.scanLineJitter = val;
		analogGlitch.verticalJump = val;
		analogGlitch.horizontalShake = val;
		analogGlitch.colorDrift = val;

		while(val > 0){
			val -= Time.deltaTime;
			analogGlitch.scanLineJitter = val;
			analogGlitch.verticalJump = val;
			analogGlitch.horizontalShake = val;
			analogGlitch.colorDrift = val;
			yield return null;
		}

		val = 0;
		analogGlitch.scanLineJitter = val;
		analogGlitch.verticalJump = val;
		analogGlitch.horizontalShake = val;
		analogGlitch.colorDrift = val;
	}

}
