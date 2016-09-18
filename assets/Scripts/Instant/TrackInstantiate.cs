using UnityEngine;
using System.Collections;

public class TrackInstantiate : MonoBehaviour {
	public GameObject track;
	public int        trackInt;
	public Transform  trackPosition;

	void Awake () 
	{
		for(int i = 0; i < trackInt ;i++)
		{
			GameObject clone;
			clone = Instantiate(track,trackPosition.position,trackPosition.rotation) as GameObject;
			clone.GetComponent<TransleteRoad>().roadInstal=gameObject.GetComponent<TrackInstantiate>();
			trackPosition.Translate(0,0,100.0f);
		}
     }

	public void TrackTranslete(Transform objectTranslete)
	{
	objectTranslete.position = trackPosition.position;
		trackPosition.Translate(0,0,100.0f);
	}
	


}
