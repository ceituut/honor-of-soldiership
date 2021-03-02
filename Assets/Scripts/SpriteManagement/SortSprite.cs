using UnityEngine;

public class SortSprite : MonoBehaviour {
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
        float distance = transform.position.y - offset - soldierBottomTransform.position.y;
        if(distance < 0)
            Rise();
        else
            Lower();
    }

    private void Lower()
    {
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder -1;
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder -1;
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder -1;
    }

    private void Rise()
    {
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder +1;
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder +1;
        spriteRenderer.sortingOrder = soldierSpriteInitialSortingOrder +1;
    }
}