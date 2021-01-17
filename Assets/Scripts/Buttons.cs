using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	public Sprite button, pressed;

	private Image img;
	private float yPos;
	private Transform child;

	public bool music;

	// Start is called before the first frame update
	private void Start()
	{
		img = GetComponent<Image>();
		child = transform.GetChild(0).transform;
		CheckMusic();
	}

	private void CheckMusic()
	{
		if (PlayerPrefs.GetString("Music") == "no")
		{
			transform.GetChild(0).gameObject.SetActive(true);
			//transform.GetChild(1).gameObject.SetActive(false);
		}
		else
		{
			transform.GetChild(0).gameObject.SetActive(false);
			//transform.GetChild(1).gameObject.SetActive(true);
		}
	}

	private void OnMouseDown()
	{
		img.sprite = pressed;
		yPos = child.transform.localPosition.y;
		child.localPosition = new Vector3(child.localPosition.x, 0, child.localPosition.z);
	}

	// Update is called once per frame
	private void OnMouseUp()
	{
		img.sprite = button;
		child.localPosition = new Vector3(child.localPosition.x, yPos, child.localPosition.z);
	}

	private void OnMouseUpAsButton()
	{
		switch (gameObject.name)
		{
			case "Music":
				CheckMusic();
				break;
			case "Play":
				StartCoroutine(LoadScene("game"));
				break;
			default: 
				break;
		}
	}

	private IEnumerator LoadScene(string scene)
	{
		float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(scene);
	}
}