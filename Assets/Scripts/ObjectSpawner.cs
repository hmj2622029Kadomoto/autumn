using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] objects;
	[SerializeField] private float interval = 3f;

	[SerializeField] private Vector3 areaCenter;
	[SerializeField] private Vector3 areaSize = new Vector3(20f,0f,20f);

	private void Start()
	{
		StartCoroutine(SpawnObjects());
	}

	private IEnumerator SpawnObjects()
	{
		while(true)
		{
			TeleportRandomPosition();

			int index = Random.Range(0, objects.Length);

			Instantiate(objects[index],transform.position,transform.rotation);
			yield return new WaitForSeconds(interval);
		}
	}

	private void TeleportRandomPosition()
	{
		float x = Random.Range(areaCenter.x - areaSize.x / 2f, areaCenter.x + areaSize.x / 2f);
		float z = Random.Range(areaCenter.z - areaSize.z / 2f, areaCenter.z + areaSize.z / 2f);
		transform.position = new Vector3(x,transform.position.y,z);
	}
}
