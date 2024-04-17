using UnityEngine;

public static class ExtensionUtilityClass
{
    public static void CopyText(string text)
    {
        TextEditor textEditor = new TextEditor
        {
            text = text
        };
        textEditor.SelectAll();
        textEditor.Copy();
        Debug.Log(textEditor.text);
    }
    
    
    public static void PasteText()
    {
        TextEditor textEditor = new TextEditor
        {
            multiline = true
        };
        textEditor.Paste();
        Debug.Log(textEditor.text);
    }
}
