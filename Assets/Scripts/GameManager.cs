using UnityEngine;
using ithappy.Animals_FREE;

public class GameManager : MonoBehaviour
{
	// インスペクターで選べる動物のプレファブを配列で登録する
	[SerializeField] private GameObject[] m_AnimalPrefabs;

	// 動物を生み出す場所
	[SerializeField] private Transform m_SpawnPoint;

	private void Start()
	{
		// タイトルで保存された動物のIDを読み込む
		int selectedID = PlayerPrefs.GetInt("AnimalSelected", 0);

		// 指定された動物のプレファブを、スポーン位置に生み出す
		GameObject spawnedAnimal = Instantiate(m_AnimalPrefabs[selectedID],m_SpawnPoint.position,m_SpawnPoint.rotation);

		// シーン内にある3人称カメラを探す
		ThirdPersonCamera cameraScript = FindAnyObjectByType<ThirdPersonCamera>();

		if (cameraScript != null)
		{
			// 生み出した動物の「Transform」をカメラの追従対象として自動登録する
			cameraScript.setplayer
		}
	}
}
