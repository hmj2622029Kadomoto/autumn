using ithappy.Animals_FREE;
using UnityEngine;

public class ScoreField : MonoBehaviour
{
	[SerializeField] private string correctTag;
	[SerializeField] private int correctScore = 10;
	[SerializeField] private int wrongScore = -5;
		
	private ScoreManager scoreManager;

	private void Start()
	{
		scoreManager = FindFirstObjectByType<ScoreManager>();
	}
	private void OnTriggerEnter(Collider other)
	{
		// プレイヤーなら何もしない
		if(other.GetComponentInParent<MovePlayerInput>() != null)
		{
			return;
		}

		// PickupObjectを持っているオブジェクトを削除
		PickupObject pickupObject = other.GetComponentInParent<PickupObject>();
		if(pickupObject == null )
		{
			return;
		}
		// 入ったオブジェクトのTagを確認
		if(other.CompareTag(correctTag))
		{
			// 正解
			if(scoreManager != null)
			{
				scoreManager.Addscore(correctScore);
			}
			Debug.Log("正解"+correctScore);
		}
		else
		{
			// 不正解
			if(scoreManager != null)
			{
				scoreManager.Addscore(wrongScore);
			}
			Debug.Log("不正解"+wrongScore);
			// オブジェクトを削除
		}
		Destroy(pickupObject.gameObject);
	}
}
