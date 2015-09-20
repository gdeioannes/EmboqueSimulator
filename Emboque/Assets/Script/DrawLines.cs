using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLines : MonoBehaviour {

	public List<GameObject> nodesList;

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public Material material;
	void Start() {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = material;
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.05F, 0.05F);
		lineRenderer.SetVertexCount(nodesList.Count);
	}
	void Update() {
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		int i = 0;
		while (i < nodesList.Count) {
			Vector3 pos = nodesList[i].transform.position;
			lineRenderer.SetPosition(i, pos);
			i++;
		}
	}
}


