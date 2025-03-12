using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAccount : MonoBehaviour
{
    public TMP_InputField userName;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI notification;


    public void onLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", userName.text);
        form.AddField("passwd", password.text);
        UnityWebRequest request = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return request.SendWebRequest();
        if (!request.isDone)
        {
            Debug.Log("Connect no finish");
        }
        else if (request.isDone)
        {
            string get = request.downloadHandler.text;
            if(get == "empty")
            {
                notification.text = "Vui lòng nhập đầy đủ thông tin";
            }else if(get == "" || get == null)
            {
                notification.text = "Tài khoản hoặc mật khẩu không chính xác";
            }else if (get.Contains("Lỗi"))
            {
                notification.text = "Không kết nối được sever";
            }
            else
            {
                notification.text = "Đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
                Debug.Log(get);
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
