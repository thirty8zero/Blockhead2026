using UnityEngine;
using System;
using TMPro;


public class LevelTimer : MonoBehaviour

{
    public float timer = 0f;
    public bool isLevelRunning = true;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;

    //public float GetBestTime();

    void Start()
    {
        //GetBestTime();
        UpdateBestTimeUI();
    }

    void Update()
    {
        if (isLevelRunning)
        {
            timer += Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = FormatTime(timer);
            }
        }
    }

    public void StopTimer(bool saveResult)
    {
        isLevelRunning = false;

        if (!saveResult) return;

        string levelkey = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(levelkey))
        {
            float savedBestTime = PlayerPrefs.GetFloat(levelkey);
            // Save if no previous best or new time is faster
            if (savedBestTime == 0f || timer < savedBestTime)
            {
                PlayerPrefs.SetFloat(levelkey, timer);
                PlayerPrefs.Save();
                Debug.Log("New best time saved: " + timer.ToString("F3"));
            }
        }
        else
        {
            PlayerPrefs.SetFloat(levelkey, timer);
            PlayerPrefs.Save();
            Debug.Log("First best time saved: " + timer.ToString("F3"));
        }
        //Refreshing UI
        UpdateBestTimeUI();
    }
    string FormatTime(float time)
    {
        return time.ToString("F3");
    }

    public float GetBestTime()
    {
        string levelKey = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(levelKey))
        {
            return PlayerPrefs.GetFloat(levelKey);
        }
        else
        {
            return 0f; // Or float.MaxValue if you prefer
        }
    }

    public void UpdateBestTimeUI()
    {
        float bestTime = GetBestTime();

        if (bestTime > 0f)
        {
            // Format as seconds + milliseconds (3 decimal places)
            //bestTimeText.text = $"Best Time: {bestTime:F3}s";

            // Round to 3 decimal places
            //float roundedBest = Mathf.Round(bestTime * 1000f) / 1000f;
            // Format as seconds + milliseconds (3 decimal places)
            //bestTimeText.text = $"Best Time: {roundedBest:F3}s";

            //bestTimeText.text = string.Format("Best Time: {0:0.000}s", bestTime);

            // Convert to decimal and round to 3 decimal places
            //decimal roundedBest = Math.Round((decimal)bestTime, 3);
            // Update UI text
            //bestTimeText.text = $"Best Time: {roundedBest}s";

            string bestTimeString = bestTime.ToString("F3");
            bestTimeText.text = $"Best: {bestTimeString}";

            //Debug.Log("Should be 3 decimal places now");
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }
    }
}
