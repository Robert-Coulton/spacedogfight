using UnityEngine;
using System.Collections;

public class CameraFollowCursor : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		{
			//Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			//Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

			// Consider using Vector3.Lerp for neat effects!
			transform.position += Vector3.up * Time.deltaTime * speed;
		}
	}
}
