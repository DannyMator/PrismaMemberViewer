using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Loader : MonoBehaviour
{
    List<Member> members = new List<Member>();

    public TextMeshProUGUI text;
    public Image image;
    void Initialize(){}

    void Start(){Load();}

    public void Load(){
        StartCoroutine(CSVDownloader.DownloadData(AfterDownload));
    }

    public void AfterDownload(string data){
        if (data == null){
            Debug.LogError("Was not able to download data.");
        }
        else {
            Debug.Log("Initializing data processing");
            ProcessData(data);
        }
    }

    public void ProcessData(string data){

        string[] tempData = data.Split(new char[] {'\n'});

        for (int i = 1; i < tempData.Length; i++){
            string[] row = tempData[i].Split(new char[] {','});

            Member m = new Member();
            int.TryParse(row[0], out m.id);
            m.name = row[1];
            m.role = row[2];
            m.image = row[3];

            members.Add(m);
        }

        foreach (Member m in members){
            Debug.Log(m.name);
            text.text += m.name + "\n";
        }

        StartCoroutine(ImageDownloader.DownloadImage(members[0].image ,ProcessImage));
    }

    public void ProcessImage(Texture2D tex){
        //Sprite sprite = Sprite.Create(tex, new Rect(0, 0, image.rectTransform.rect.width, image.rectTransform.rect.height), new Vector2(0.5f,0.5f));
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f,0.5f));
        image.sprite = sprite;
        image.preserveAspect = true;
    }
}
