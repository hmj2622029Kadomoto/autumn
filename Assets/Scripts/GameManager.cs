using UnityEngine;
using ithappy.Animals_FREE; // カメラのネームスペースを使えるようにする

public class GameManager : MonoBehaviour
{
	// インスペクターで選べる動物のプレハブを配列で登録する
	[SerializeField] private GameObject[] m_AnimalPrefabs;

	// 動物を生み出す場所（シーン内に空のGameObjectを作って配置しておく）
	[SerializeField] private Transform m_SpawnPoint;

	void Start()
	{
		int selectedID = PlayerPrefs.GetInt("AnimalSelected", 0);

		GameObject spawnedAnimal = Instantiate(m_AnimalPrefabs[selectedID], m_SpawnPoint.position, m_SpawnPoint.rotation);

		ThirdPersonCamera cameraScript = FindObjectOfType<ThirdPersonCamera>();

		if (cameraScript != null)
		{
			cameraScript.SetPlayer(spawnedAnimal.transform);

			MovePlayerInput playerInput = spawnedAnimal.GetComponent<MovePlayerInput>();

			if (playerInput != null)
			{
				playerInput.BindCamera(cameraScript);
			}
		}
	}
}
