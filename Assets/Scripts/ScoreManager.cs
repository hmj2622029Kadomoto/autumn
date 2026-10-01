using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;
	 int score = 0;
	void Awake()
	{
		// ÉVÅ[ÉìÇÇ‹ÇΩÇ¢Ç≈Ç‡écÇ∑
		DontDestroyOnLoad(gameObject);
	}
	void Start()
	{
		UpdateScoreText();
	}

	public void Addscore(int amount)
	{
		score += amount;
		UpdateScoreText();
	}
	void UpdateScoreText()
	{
		scoreText.text ="Score: " + score;
	}
	public int GetScore()
	{
		return score;
	}
}
