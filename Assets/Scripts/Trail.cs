using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {
	
	private static Vector3 speed = new Vector3(-0.09f,0,0.01f);
	private float startTime;
	private static float fadeTime = 2f;
	private SpriteRenderer spriteRenderer;

	private float originalScale;

	void Start() {
		this.transform.position = new Vector3(0,0,-1000);
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		originalScale = this.transform.localScale.x;
	}
	
	public void SpawnAt(Vector3 location) {
		this.transform.position = location;
		startTime = Time.time;

		spriteRenderer.color = Color.white;
		SetScale (1);

	}
	
	void Update() {
		this.transform.position += speed;
		UpdateAlpha();
	}
	
	private void UpdateAlpha() {
		float fraction = 1-(Time.time - startTime)/fadeTime;
		if (fraction < 0) fraction = 0;
		
		SetScale (Mathf.Pow (fraction, 2));
		
		spriteRenderer.color = new Color(1f,1f,1f,Mathf.Pow (fraction, 5));
	}

	private void SetScale(float scale) {
		transform.localScale = Vector3.one * (scale * 0.7f + 0.3f) * originalScale;
	}
	
}
