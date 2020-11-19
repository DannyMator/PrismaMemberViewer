using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class CSVDownloader
{
    private const string googleSheetDocID = "1FOGo059GpsF5qh8UnjwRlPIywnAlfJv-bQ9ydiu8VRg";
    private const string url = "https://docs.google.com/spreadsheets/d/" + googleSheetDocID + "/export?format=csv";

    internal static IEnumerator DownloadData (System.Action<string> onCompleted){
        yield return new WaitForEndOfFrame();

        string downloadData = null;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)){
            Debug.Log("Starting Download...");
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError){
                Debug.Log("Download Error: " + webRequest.error);
            }
            else
            {
                downloadData = webRequest.downloadHandler.text.Substring(0);
                Debug.Log("CSV Downloaded successfully");
            }
        }
        onCompleted(downloadData);
    }
}
