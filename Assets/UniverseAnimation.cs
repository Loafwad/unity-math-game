using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseAnimation : MonoBehaviour
{
	[Header("Rotation Speed")]
	[SerializeField]
	private float verticalRotSpeed = 3;
	[SerializeField]
	private float horizontalRotSpeed = 5;

	[Header("Misc")]
	[SerializeField]
	private List<Sprite> planetSprites;
	[SerializeField]
	private GameObject planetsParent;

	[Header("Planet Spawn Animation")]
	public AnimationCurve spawnAnimCurve;
	public float spawnAnimDuration;
	public float spawnAnimDelay;
	public float planetMinSize, planetMaxSize;

	[Header("Zoom Animation")]
	public AnimationCurve zoomAnimCurve;
	public float zoomAnimDuration;
	public float zoomAnimDelay;
	public float zoomDistance;

	private int activePlanets = 0;

	float tempVerticalRotSpeed;
	float tempHorizontalRotSpeed;
	// Start is called before the first frame update
	void Start()
    {
		chooseRandomSprites();
		tempVerticalRotSpeed = verticalRotSpeed;
		tempHorizontalRotSpeed = horizontalRotSpeed;

	}

	void chooseRandomSprites()
	{
		//sets all child objects to a random planet sprite
		foreach (RectTransform child in planetsParent.transform)
		{
			child.transform.localScale = new Vector2(0, 0);
			child.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count)];
		}
	}

	public void MakeNewPlanet()
	{
		activePlanets++;
		if (activePlanets <= 10)
		{
			Transform child = planetsParent.transform.GetChild(activePlanets -1);
			child.gameObject.SetActive(true);

			float spawnSize = Random.Range(planetMinSize, planetMaxSize);
			LeanTween.scale(child.gameObject, new Vector3(spawnSize, spawnSize, 0), spawnAnimDuration).setDelay(spawnAnimDelay).setLoopOnce().setEase(spawnAnimCurve);
		}
		else if (activePlanets == 11)
		{
			Debug.Log("can't add more planets");
			verticalRotSpeed = 0;
			horizontalRotSpeed = 0;
			foreach (RectTransform child in planetsParent.transform)
			{
				LeanTween.moveZ(child.gameObject, child.gameObject.transform.position.z + zoomDistance, zoomAnimDuration).setDelay(zoomAnimDelay).setLoopOnce().setEase(zoomAnimCurve).setOnComplete(TogglePlanets);
			}
		}
	}

	bool toggle = false;
	void TogglePlanets()
	{
		toggle = !toggle;
		if (toggle)
		{
			foreach (RectTransform child in planetsParent.transform)
			{
				child.gameObject.SetActive(true);
			}
		}
		else
		{
			foreach (RectTransform child in planetsParent.transform)
			{
				child.gameObject.SetActive(false);
				child.position = new Vector3(child.position.x, child.position.y, Random.Range(-3, 3));
				activePlanets = 0;
				chooseRandomSprites();
				verticalRotSpeed = tempVerticalRotSpeed;
				horizontalRotSpeed = tempHorizontalRotSpeed;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(Vector3.right, verticalRotSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up, horizontalRotSpeed * Time.deltaTime);

	}
}
