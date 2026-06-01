using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] leaderboardTexts;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnEnable()
    {
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        for (int i = 0; i < leaderboardTexts.Length; i++)
        {
            if (i < GameData.Instance.bestTimes.Count)
            {
                leaderboardTexts[i].text =
                    $"{i + 1}. {GameData.Instance.bestTimes[i]:F2}s";
            }
            else
            {
                leaderboardTexts[i].text = $"{i + 1}. ---";
            }
        }
    }
}
