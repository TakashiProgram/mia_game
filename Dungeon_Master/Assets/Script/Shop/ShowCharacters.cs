using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacters : MonoBehaviour {
    
    [SerializeField]
    private Text m_UiText;   

    [SerializeField]
    private float m_IntervalForDisplay = 0.05f;   
    
    private string m_CurrentSentence = string.Empty;  

    private float m_TimeUntilDisplay = 0;    

    private float m_TimeBeganDisplay = 1;         

    private int m_LastUpdateCharCount = -1;     

    void Update()
    {
        int displayCharCount = (int)(Mathf.Clamp01((Time.time - m_TimeBeganDisplay) / m_TimeUntilDisplay) * m_CurrentSentence.Length);
    
        if (displayCharCount != m_LastUpdateCharCount)
        {
            m_UiText.text = m_CurrentSentence.Substring(0, displayCharCount);
           
            m_LastUpdateCharCount = displayCharCount;
        }
    }
    
    public void SetNextSentence(string text)
    {
        m_CurrentSentence = text;
        m_TimeUntilDisplay = m_CurrentSentence.Length * m_IntervalForDisplay;
        m_TimeBeganDisplay = Time.time;
        m_LastUpdateCharCount = 0;
    }
}
