using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCard : Card
{
    private GameObject img;
    private GameObject preview;
    public new void Awake()
    {
        base.Awake();
        img = cardSO.gameObject.transform.Find("image").gameObject;
        if (img == null)
            Debug.Log("image missing!");
        //img = cardSO.gameObject.GetComponent<Transform>();
    }
    public override void Use()
    {
        if (FightManager.Instance.GetCostUI().GetCost() < cardSO.cost)
        {
            Debug.Log("��������");
            return;
        }
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPos = mainCamera.ScreenToWorldPoint(mousePos);
        preview = Instantiate(img, screenPos, Quaternion.identity);
        Debug.Log(preview+"���ɷ�����Ӱ��");
        SpriteRenderer MagicSpriteRenderer = preview.GetComponent<SpriteRenderer>();
        Color  newColor = new Color(MagicSpriteRenderer.color.r, MagicSpriteRenderer.color.g, MagicSpriteRenderer.color.b,MagicSpriteRenderer.color.a - 0.5f );//��͸����-50
        preview.GetComponent<SpriteRenderer>().color = newColor;
        preview.transform.localScale *= img.transform.parent.localScale.x;//scale�ǹ��ڸ�����ģ�����ֱ�ӻ�ȡ����������ʹ�ߴ粻��
        StartCoroutine(GetNextClickPos());
    }
    //Э�̻�ȡ�´��������λ��
    public override IEnumerator GetNextClickPos()
    {
        while (true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 screenPos = mainCamera.ScreenToWorldPoint(mousePos);
            preview.transform.position = screenPos;
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(GetNextClickPos());
                DestroyImmediate(preview);
                // Debug.Log("�����������");
                mousePos = Input.mousePosition;
                mousePos.z = 10;
                screenPos = mainCamera.ScreenToWorldPoint(mousePos);
                RaycastHit2D[] hit = Physics2D.RaycastAll(screenPos, Vector2.zero);
                foreach (RaycastHit2D h in hit)
                {
                    if (h.collider.CompareTag("Map"))
                    {
                         //Debug.Log("��Ч���");
                        UseAction(screenPos);
                        yield break;
                    }
                }
                //Debug.Log("��Ч���");
                
            }
            yield return null;
        }
    }
    public void UseAction(Vector3 target)
    {
        GameObject go = Instantiate(cardSO.gameObject, target, Quaternion.identity);
        FightManager.Instance.GetCostUI().SetCost(-cardSO.cost);
        CardManager.Instance.RemoveCard(this);
    }
}
