using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBox_Done : MonoBehaviour
{
    [SerializeField] Loot[] m_Loots;
    [Space(20)]
    [SerializeField] Transform m_LootObjectParent;
    [SerializeField] Animator m_Aniamtor;
    [SerializeField] GameObject m_OpenAgainBoxButton;
    [SerializeField] GameObject m_OpenBoxButton;
    [SerializeField] GameObject m_ItemInfo;
    [SerializeField] Text m_ItemNameText;
    [SerializeField] Text m_ItemDescribeText;

    GameObject[] m_LootObjects;

    int m_CurrentSelectedIndex;

    // Use this for initialization
    void Start()
    {
        m_LootObjects = new GameObject[m_Loots.Length];
        for (int i = 0; i < m_Loots.Length; i++)
        {
            GameObject obj = Instantiate(m_Loots[i]._prefab, Vector3.zero, Quaternion.identity, m_LootObjectParent);
            obj.SetActive(false);
            m_LootObjects[i] = obj;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    int Choose()
    {
        float total = 0;

        for (int i = 0; i < m_Loots.Length; i++)
        {

            total += m_Loots[i]._probability;
        }
        Debug.Log("total:" + total);
        float randomPoint = Random.value * total;
        Debug.Log("randomPoint" + randomPoint);

        for (int i = 0; i < m_Loots.Length; i++)
        {
            if (randomPoint < m_Loots[i]._probability)
            {
                Debug.Log("i" + i);
                return i;

            }
            else
            {
                randomPoint -= m_Loots[i]._probability;
                Debug.Log("randomPoint" + randomPoint);
            }
        }
        Debug.Log("m_Loots.Length - 1" + (m_Loots.Length - 1));
        return m_Loots.Length - 1;
    }


    public void OpenBox()
    {
        m_Aniamtor.SetBool("Open", true);
        m_CurrentSelectedIndex = Choose();
        m_LootObjects[m_CurrentSelectedIndex].SetActive(true);

    }

    public void ShowOpenAgainButton()
    {
        m_OpenAgainBoxButton.SetActive(true);

        m_ItemNameText.text = m_Loots[m_CurrentSelectedIndex]._name;
        m_ItemDescribeText.text = m_Loots[m_CurrentSelectedIndex]._describe;
        m_ItemInfo.SetActive(true);
    }
    public void ShowOpenButton()
    {
        m_OpenBoxButton.SetActive(true);
    }

    public void ResetBox()
    {
        m_Aniamtor.SetBool("Open", false);
        m_LootObjects[m_CurrentSelectedIndex].SetActive(false);
        m_ItemInfo.SetActive(false);
    }
}

[System.Serializable]
public class Loot
{
    [Header("物品設定")]
    public int _probability;
    public GameObject _prefab;
    [Header("物品資料")]
    public string _name;
    public string _describe;
}
