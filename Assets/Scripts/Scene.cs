using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
	// クリックされたら呼び出す関数
	public void SelectAnimal(int animalID)
	{
		// 選択された動物の番号を「AnimalSelected」という名前で保存
		PlayerPrefs.SetInt("AnimalSelected", animalID);
		PlayerPrefs.Save();

		// ゲーム画面（シーン名：GameScene）をロード
		SceneManager.LoadScene("GameScene");
	}
}
