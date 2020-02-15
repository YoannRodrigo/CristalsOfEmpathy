using UnityEngine;

public class Face : MonoBehaviour
{
    [Header("Assets")]
    public Sprite eyeOpenSprite;
    public Sprite eyeClosedSprite;
    public Sprite eyeBrowSprite;
    public Sprite mouthSprite;
    public Sprite[] speakingMouths;

    [Header("References")]
    public SpriteRenderer leftEye;
    public SpriteRenderer rightEye;
    public SpriteRenderer leftEyeBrow;
    public SpriteRenderer rightEyeBrow;
    public SpriteRenderer mouth;

    // CONST SETTINGS
    private Vector3 eyeOriginPosition = new Vector3(-0.03f, 0f, -0.035f);
    private float leftEyeOriginDistance = -0.0005f;
    private float rightEyeOriginDistance = 0.0055f;
    private Vector3 eyebrowOriginPosition = new Vector3(-0.04f, 0f, -0.0375f);
    private float leftEyebrowOriginDistance = -0.0005f;
    private float rightEyebrowOriginDistance = 0.0055f;
    private Vector3 mouthOriginPosition = new Vector3(-0.01f, 0.002f, -0.0375f);

    [Header("Eyes")]
    [Range(0f, 1f)]public float eyeSize;
    [Range(0f, 1f)]public float eyeSeparation;
    [Range(0f, 1f)]public float eyeHeight;
    [Range(0f, 1f)]public float eyeDepth;
    public bool eyeFlip = false;
    [Header("Eyebrows")]
    [Range(0f, 1f)]public float eyeBrowSize;
    [Range(0f, 1f)]public float eyeBrowSeparation;
    [Range(0f, 1f)]public float eyeBrowHeight;
    [Range(0f, 1f)]public float eyeBrowDepth;
    public bool eyebrowFlip = false;
    public Color eyebrowColor;
    [Header("Mouth")]
    [Range(0f, 1f)]public float mouthSize;
    [Range(0f, 1f)]public float mouthHeight;
    [Range(0f, 1f)]public float mouthDepth;

    private float blinkTimer = 0f;
    private bool blinked = false;
    private float speakTimer = 0f;
    private bool speaking;
    

    // The OnValidate function is executed whenever a value is changed in the inspector of this component
    void OnValidate()
    {
        SetEyes();
        SetEyebrows();
        SetMouth();
    }

    void Update()
    {
        if(blinkTimer > 0) blinkTimer -= Time.deltaTime;
        else
        {
            if(blinked)
            {
                blinkTimer = Random.Range(2f, 5f);
                leftEye.sprite = eyeOpenSprite;
                rightEye.sprite = eyeOpenSprite;
            }
            else
            {
                blinkTimer = 0.25f;
                leftEye.sprite = eyeClosedSprite;
                rightEye.sprite = eyeClosedSprite;
            }
            blinked = !blinked;
        }

        if(speaking)
        {
            if(speakTimer > 0) speakTimer -= Time.deltaTime;
            else
            {
                mouth.sprite = speakingMouths[Random.Range(0, speakingMouths.Length)];
                speakTimer = Random.Range(0.1f, 0.25f);
            }
        }
    }

    public void Speak()
    {
        speaking = true;
    }

    public void ShutUp()
    {
        speaking = false;
        mouth.sprite = mouthSprite;
    }

    public void SetMouth()
    {
        float sizeRatio = 0.05f + (mouthSize * 0.1f);
        float heightRatio = 0.01f + (mouthHeight * -0.02f);
        float depthRatio = -0.01f + (mouthDepth * 0.02f);

        mouth.transform.localScale = Vector3.one * 0.1f * sizeRatio;
        mouth.transform.localPosition = mouthOriginPosition + new Vector3(heightRatio, 0f, depthRatio);

        if(mouthSprite != null) mouth.sprite = mouthSprite;
        else mouth.sprite = null;
    }
    public void SetEyebrows()
    {
        float sizeRatio = 0.05f + (eyeBrowSize * 0.1f);
        float heightRatio = 0.01f + (eyeBrowHeight * -0.02f);
        float separationRatio = 0.01f + (eyeBrowSeparation * 0.02f);
        float depthRatio = -0.01f + (eyeBrowDepth * 0.02f);

        int flip = eyebrowFlip ? -1 : 1;

        leftEyeBrow.transform.localScale = new Vector3(-1f * flip, 1f, 1f) * 0.1f * sizeRatio;
        rightEyeBrow.transform.localScale =  new Vector3(1f * flip, 1f, 1f)  * 0.1f * sizeRatio;
        leftEyeBrow.transform.localPosition = eyebrowOriginPosition + new Vector3(heightRatio, leftEyebrowOriginDistance + separationRatio, depthRatio);
        rightEyeBrow.transform.localPosition = eyebrowOriginPosition + new Vector3(heightRatio, rightEyebrowOriginDistance - separationRatio, depthRatio);
    
        if(eyeOpenSprite != null)
        {
            leftEyeBrow.sprite = eyeBrowSprite;
            rightEyeBrow.sprite = eyeBrowSprite;
        }
        else
        {
            leftEyeBrow.sprite = null;
            rightEyeBrow.sprite = null;
        }

        leftEyeBrow.color = eyebrowColor;
        rightEyeBrow.color = eyebrowColor;
    }
    public void SetEyes()
    {
        float sizeRatio = 0.05f + (eyeSize * 0.1f);
        float heightRatio = 0.01f + (eyeHeight * -0.02f);
        float separationRatio = 0.01f + (eyeSeparation * 0.02f);
        float depthRatio = -0.01f + (eyeDepth * 0.02f);

        int flip = eyeFlip ? -1 : 1;

        leftEye.transform.localScale = new Vector3(-1f * flip, 1f, 1f) * 0.1f * sizeRatio;
        rightEye.transform.localScale = new Vector3(1f * flip, 1f, 1f) * 0.1f * sizeRatio;
        leftEye.transform.localPosition = eyeOriginPosition + new Vector3(heightRatio, leftEyeOriginDistance + separationRatio, depthRatio);
        rightEye.transform.localPosition = eyeOriginPosition + new Vector3(heightRatio, rightEyeOriginDistance - separationRatio, depthRatio);
    
        if(eyeOpenSprite != null)
        {
            leftEye.sprite = eyeOpenSprite;
            rightEye.sprite = eyeOpenSprite;
        }
        else
        {
            leftEye.sprite = null;
            rightEye.sprite = null;
        }
    }
}
