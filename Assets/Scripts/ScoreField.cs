using ithappy.Animals_FREE;
using UnityEngine;

public class ScoreField : MonoBehaviour
{
	[SerializeField] string correctTag;

	[SerializeField] int correctScore = 10;
	[SerializeField] int wrongScore = -5;
	
	[SerializeField] ParticleSystem correctEffect;
	
	[SerializeField] AudioClip correctSE;
	[SerializeField] AudioClip wrongSE;
	
	AudioSource audioSource;

	ScoreManager scoreManager;

	void Start()
	{
		scoreManager = FindFirstObjectByType<ScoreManager>();
		audioSource = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider other)
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
			// 正解エフェクトを再生
			if(correctEffect != null)
			{
				correctEffect.Play();
			}
			if(correctSE != null)
			{
				audioSource.PlayOneShot(correctSE);
			}
		}
		else
		{
			// 不正解
			if(scoreManager != null)
			{
				scoreManager.Addscore(wrongScore);
			}
			if(wrongSE != null)
			{
				audioSource.PlayOneShot(wrongSE);
			}
		}
		// オブジェクトを削除
		Destroy(pickupObject.gameObject);
	}
}
