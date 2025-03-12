using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegisterAccount : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI notification;

    public void onRegister()
    {
        StartCoroutine(Resgister());
    }

    IEnumerator Resgister()
    {
        WWWForm form = new WWWForm();
        form.AddField("user" , userName.text);
        form.AddField("passwd" , password.text);
        UnityWebRequest request = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);
        yield return request.SendWebRequest();
        if (!request.isDone)
        {
            Debug.Log("Connect no finish");
        }
        else if(request.isDone)
        {
            string get = request.downloadHandler.text;
            switch (get)
            {
                case "exist":
                    notification.text = "Tài khoản đã tồn tại!";
                    break;
                case "OK":
                    notification.text = "Đăng kí thành công!";
                    break;
                case "ERROR":
                    notification.text = "Đăng kí không thành công!";
                    break;
                default:
                    notification.text = "Không kết nối tới sever";
                    break;


            }
        }
    }
}
