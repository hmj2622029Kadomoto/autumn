using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;

	private void Start()
	{
		ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
		if(scoreManager != null )
		{
			int score = scoreManager.GetScore();
			scoreText.text = "Score: " + score;
		}
	}
	private void Update()
	{
		if(Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("TitleScene");
		}
	}
}
