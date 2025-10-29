using UnityEngine;
using TMPro; // <- thêm dòng này để dùng TextMeshPro

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        // Lấy dữ liệu điểm, kết quả và level từ GameManager
        int finalScore = PlayerPrefs.GetInt("FinalScore");
        string result = PlayerPrefs.GetString("GameResult");
        int scoreGoal  = PlayerPrefs.GetInt("ScoreGoal");
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        // Tìm TextMeshPro có tag "Score"
        GameObject scoreObj = GameObject.FindGameObjectWithTag("Score");

        if (scoreObj != null)
        {
            TMP_Text scoreText = scoreObj.GetComponent<TMP_Text>();
            if (scoreText != null)
            {
                scoreText.text = "Score Star: " + finalScore.ToString() + "/" + scoreGoal;
            }
            else
            {
                Debug.LogWarning("Không tìm thấy TMP_Text trên object có tag 'Score'");
            }
        }
        else
        {
            Debug.LogWarning("Không tìm thấy object nào có tag 'Score'");
        }

        // Nếu bạn có Text hiển thị kết quả (Thắng/Thua)
        GameObject resultObj = GameObject.FindGameObjectWithTag("Results"); // hoặc đặt tag riêng là "Result"
        if (resultObj != null)
        {
            TMP_Text resultText = resultObj.GetComponent<TMP_Text>();
            if (resultText != null)
            {
                resultText.text = (result == "Win") ? "Win" : "Game Over";
            }
        }
        GameObject NextOrReplay = GameObject.FindGameObjectWithTag("NextOrReplay");;
        if (NextOrReplay != null)
        {
            TMP_Text nextOrReplayText = NextOrReplay.GetComponent<TMP_Text>();
            if (nextOrReplayText != null)
            {
                if (result == "Win")
                {
                    nextOrReplayText.text = "Next Level " + currentLevel;
                }
                else
                {
                    nextOrReplayText.text = "Replay Level " + currentLevel;
                }
            }
        }
    }
}
