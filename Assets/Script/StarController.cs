using UnityEngine;

[System.Serializable]
public class StarType
{
    public Sprite sprite;
    public int points;
}

public class StarController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int experienceToGive = 1;
    [SerializeField] private StarType[] starTypes; // Mảng các loại sao với sprite và điểm
    public int pointValue; // Giá trị điểm của ngôi sao hiện tại

    private Vector3 targetPosition;
    private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Fix: ensure the sprite isn't visually flipped by a negative scale in the prefab
        Vector3 s = transform.localScale;
        s.x = Mathf.Abs(s.x);
        s.y = Mathf.Abs(s.y);
        transform.localScale = s;
        // Also reset SpriteRenderer flip flags to be safe
        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false;

        if (starTypes.Length == 0)
        {
            Debug.LogError("Chưa cấu hình các loại sao!");
            return;
        }

        // Chọn ngẫu nhiên một loại sao
        int randomIndex = Random.Range(0, starTypes.Length);
        StarType selectedStar = starTypes[randomIndex];
        
        // Áp dụng sprite và điểm tương ứng
        spriteRenderer.sprite = selectedStar.sprite;
        pointValue = selectedStar.points;
        
        moveSpeed = Random.Range(0.5f, 3f);
        generateRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        float moveX = GameManager.Instance.worldSpeed  * Time.deltaTime;
        transform.position += new Vector3(-moveX, 0f, 0f);

        if(transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
    private void generateRandomPosition()
    {
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-5f, 5f);
        targetPosition = new Vector3(randomX, randomY, 0f);
        moveSpeed = Random.Range(0.1f, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.GetExperience(pointValue);
            // Cộng điểm theo giá trị của ngôi sao
            GameManager.Instance.AddScore(pointValue);
            if (AudioManager.Instance != null && AudioManager.Instance.collectStarSource != null)
            {
                AudioManager.Instance.PlaySoundOneShot(AudioManager.Instance.collectStarSource);
            }
            Destroy(gameObject);
        }
    }
}
