using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		const string projectId = "999897d6-b247-46b6-9c8f-234bc8c33844";
		UnityAnalytics.StartSDK (projectId);
		
	}
	
}