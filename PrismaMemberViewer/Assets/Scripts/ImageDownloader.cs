using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class ImageDownloader
{
    internal static IEnumerator DownloadImage(string url, System.Action<Texture2D> onCompleted)
    {   
        yield return new WaitForEndOfFrame();

        Texture2D downloadImage = null;
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url)){
            Debug.Log("Starting Image Download...");
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError || webRequest.isHttpError){
                Debug.Log("Image Download Error: " + webRequest.error);
            }
            else{
                downloadImage = ((DownloadHandlerTexture) webRequest.downloadHandler).texture;
                Debug.Log("Image Downloaded successfully");
            }
        }
        onCompleted(downloadImage);
    } 
}
