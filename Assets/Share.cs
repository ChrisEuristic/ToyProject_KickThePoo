using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour
{
    string subject = "Best Score : ";
	//private const string body = "https://play.google.com/store/apps/details?id=com.CEREALLAB.FruitsLoop&showAllReviews=true";
    private const string body = "https://play.google.com/store/apps/details?id=com.EuristicGames.KickThePoo";
	
    // 외부에서 Share메서드를 가져다 사용한다.
	public void ShareGame() {
        subject += Score.bestscore.ToString();
        subject += "  |  당근을 먹고 똥을 차세요!  |  Eat carrots, Avoid poo and kick it!  |  Coman zanahorias, evite la caca y patea!  |  吃胡萝卜，避免便便并踢它!";
#if UNITY_ANDROID && !UNITY_EDITOR
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);
#endif
	}
}
