using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text tx;
    string m_text = "오리가 갈 수 있도록 퍼즐을 풀어주세요!!";

    void Start()
    {
        if (tx == null)
        {
            Debug.LogError("TMP_Text가 할당되지 않았습니다.");
            return;
        }
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);
            yield return new WaitForSeconds(0.15f);
        }
    }
}
