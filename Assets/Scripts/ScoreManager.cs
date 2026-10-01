using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	private int score = 0;
	private void Start()
	{
		UpdateScoreText();
	}

	public void Addscore(int amount)
	{
		score += amount;
		UpdateScoreText();
	}
	private void UpdateScoreText()
	{
		scoreText.text ="Score: " + score;
	}
	public int GetScore()
	{
		return score;
	}
}
