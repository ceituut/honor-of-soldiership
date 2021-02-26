using UnityEngine;

public class LowerSprite : MonoBehaviour {
    [SerializeField] private SoldierSprite soldierSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform soldierBottomTransform;
    [SerializeField] private float offset;
    [SerializeField] private int soldierSpriteInitialSortingOrder;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        soldierSpriteInitialSortingOrder = soldierSprite.HeadSpriteRenderer.sortingOrder;
    }
    private void Update() {
        float distance = soldierBottomTransform.position.y - offset - transform.position.y;
        if(distance < 0)
            LowerSoldierSprite();
        else
            RiseSoldierSprite();
    }

    private void RiseSoldierSprite()
    {
        soldierSprite.HeadSpriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder;
        soldierSprite.BodySpriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder;
        soldierSprite.LegsSpriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder;
    }

    private void LowerSoldierSprite()
    {
        soldierSprite.HeadSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder + 1;
        soldierSprite.BodySpriteRenderer.sortingOrder = spriteRenderer.sortingOrder + 1;
        soldierSprite.LegsSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder + 1;
    }
}