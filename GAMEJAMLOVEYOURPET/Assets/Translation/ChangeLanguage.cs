using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public TextAsset English;
    public TextAsset Japanese;
    private TextAsset textAsset;
    public TMP_FontAsset _ENGFontAsset;
    public TMP_FontAsset _JPFontAsset;
    public int lineNumber;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        string language = PlayerPrefs.GetString("Language");
        if (language == "Japanese")
        {
            textMeshProUGUI.font = _JPFontAsset;
            textAsset = Japanese;
        }
        if(language == "English")
        {
            textMeshProUGUI.font = _ENGFontAsset;
            textAsset = English;
        }
        else
        {
            textAsset = English;
        }
        lineNumber = lineNumber - 1;
        string line = null;
        string[] lines = textAsset.text.Split('\n');
        if (lineNumber >= 0 && lineNumber < lines.Length)
        {
            line = lines[lineNumber];
        }
        // Set the text in the TextMeshPro component
        if (line != null)
        {
            textMeshProUGUI.text = line;
            Debug.Log(line);
        }
        else
        {
            Debug.LogError($"Line number {lineNumber} is out of range for text asset {textAsset.name}");
        }
    }
}
