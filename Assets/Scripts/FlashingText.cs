using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour {

    public float flashSpeed = 1;
    public enum FlashType { opacityPulse, crazyColors }
    public FlashType TypeOfFlashing = FlashType.opacityPulse;
    private Text myText;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
	}

    //! Opacity pulse
    private void OpacityFlash()
    {
        Color newColor = myText.color;
        float newAlpha = Mathf.PingPong(Time.time * flashSpeed, 1f);
        newColor.a = newAlpha;
        myText.color = newColor;
    }

    //! Crazy colors
    private void CrazyColors()
    {
        Color crazyColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        myText.color = crazyColor;
    }

	// Update is called once per frame
	void Update () {
	    switch(TypeOfFlashing)
        {
            case FlashType.opacityPulse:
                OpacityFlash();
                break;
            case FlashType.crazyColors:
                CrazyColors();
                break;
        }
	}
}
