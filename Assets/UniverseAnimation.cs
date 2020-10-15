using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseAnimation : MonoBehaviour
{
	[SerializeField]
	private float verticalRotSpeed = 3;
	[SerializeField]
	private float horizontalRotSpeed = 5;
	[SerializeField]
	private List<Sprite> planetSprites;
	[SerializeField]
	private GameObject planetsParent;

	private int activePlanets = 0;

	// Start is called before the first frame update
	void Start()
    {
		//sets all child objects to a random planet sprite
		foreach (RectTransform child in planetsParent.transform)
		{
			child.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count)];
		}
    }

	public void MakeNewPlanet()
	{
		activePlanets++;
		if(activePlanets <= 10)
		{
			for (int i = 0; i < activePlanets; i++)
			{
				//TODO:
				//Animate planets spawning
				planetsParent.transform.GetChild(i).gameObject.SetActive(true);
			}
		}
		else
		{
			Debug.Log("can't add more planets");
			//TODO:
			//Zoom out animation
			//reset counter and start new universe
			return;
		}
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.right, verticalRotSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up, horizontalRotSpeed * Time.deltaTime);

	}
}
