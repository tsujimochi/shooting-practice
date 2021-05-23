using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectableMenu : Selectable
{

    [Header("�J�ڂ����ʖ�")]public string nextSceneName;

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
    /// �Ώۂ̍��ڂ��I�΂�Ă��邩�m�F
    /// </summary>
    public bool IsSelect
    {
        get { return GetSprite().enabled; }
    }

    /// <summary>
    /// ���̃V�[�������[�h����
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
