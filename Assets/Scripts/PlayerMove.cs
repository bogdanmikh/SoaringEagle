using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    public Text gameOverText;
    public Image fuelUI;
    public Sprite gasOnSprite;
    public Sprite gasOffSprite;
    public float horizontalSpeed;
    public float verticalSpeed;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start() {
        gameOverText.gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        float y = 0f;
        if (inputUp() && fuelUI.fillAmount > 0 && horizontalSpeed != 0) {
            y += verticalSpeed;
            fuelUI.fillAmount -= 0.003f;
            spriteRenderer.sprite = gasOnSprite;
        } else {
            y -= verticalSpeed;
            spriteRenderer.sprite = gasOffSprite;
        }
        if (horizontalSpeed != 0) {
            horizontalSpeed += 0.00005f;
            transform.Translate(horizontalSpeed, y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Fuel") {
            fuelUI.fillAmount += 0.3f;
            GameObject.Destroy(collision.gameObject);
            return;
        }
        gameOverText.gameObject.SetActive(true);
        horizontalSpeed = 0;
        verticalSpeed = 0;
    }

    bool inputUp() {
        return Input.GetKey(KeyCode.Space) || Input.touchCount > 0;
    }
}
