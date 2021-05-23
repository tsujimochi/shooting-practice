using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectableMenu : Selectable
{

    [Header("遷移する画面名")]public string nextSceneName;

    private SpriteRenderer sprite;


    public override void OnSelect(BaseEventData eventData)
    {
        GetSprite().enabled = true;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        GetSprite().enabled = false;
    }

    /// <summary>
    /// 対象の項目が選ばれているか確認
    /// </summary>
    public bool IsSelect
    {
        get { return GetSprite().enabled; }
    }

    /// <summary>
    /// 次のシーンをロードする
    /// </summary>
    public void LoadNextScene()
    {
        if (nextSceneName == null)
        {
            return;
        }
        SceneManager.LoadScene(nextSceneName);
    }

    private SpriteRenderer GetSprite()
    {
        if (sprite == null)
        {
            sprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        }
        return sprite;
    }
}
