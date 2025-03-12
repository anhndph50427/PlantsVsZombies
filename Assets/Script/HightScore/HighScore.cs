using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    public List<HighScoreContent> highScoreContents = new List<HighScoreContent>();
    public Transform Content;
    public GameObject scoreObj;
    private void Start()
    {
        StartCoroutine(GetHightScore());       
    }


    IEnumerator GetHightScore()
    {
        WWWForm formGetScore = new WWWForm();
        formGetScore.AddField("token", PlayerPrefs.GetString("token"));
        UnityWebRequest request = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php" , formGetScore);
        yield return request.SendWebRequest();
        if (!request.isDone)
        {
            Debug.Log("Không kết nối được với sever");
        }
        else
        {
            Debug.Log("Kết nối thành công");
            string[] getScore = request.downloadHandler.text.Split('\n');
            for (int i = 0; i < getScore.Length - 1; i++)
            {
                HighScoreContent dataPlayer = new HighScoreContent();
                string[] cols = getScore[i].Split('\t');
                Debug.Log($"{cols[0]} - {cols[1]}");
                dataPlayer.name = cols[0];
                dataPlayer.Time = float.Parse(cols[1]);
                highScoreContents.Add(dataPlayer);
            }

            foreach (Transform t in Content.transform)
            {
                Destroy(t.gameObject);
            }

            if (highScoreContents.Count > 0)
            {
                var getHighScore = highScoreContents.OrderBy(x => x.Time).Take(3).ToList();
                for(int i = 0; i < getHighScore.Count ; i++)
                {
                    getHighScore[i].rank = i + 1;
                    GameObject lineObj = Instantiate(scoreObj , Content.transform);
                    lineObj.GetComponent<ScoreController>().SetDataText(getHighScore[i]);
                }
            }
        }
    }
}

[System.Serializable]
public class HighScoreContent
{
    public int rank;
    public string name;
    public float Time;
}
