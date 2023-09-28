using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DS
{
    public class Timer : MonoBehaviour
    {

        [SerializeField] private Image uiFill;
        [SerializeField] private Text uiText;

        public int Duration;

        private int remainingDuration;

        public bool Pause;

        public GameObject DialogueManager;

        public bool Pelea;
        private void Start()
        {
            Being(Duration);
            Pause = false;
        }

        private void Being(int Second)
        {
            remainingDuration = Second;
            StartCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while (remainingDuration > 0)
            {
                if (!Pause)
                {
                    uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration--;
                    yield return new WaitForSeconds(1f);
                }
            }
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            OnEnd();
        }

        private void OnEnd()
        {
            //End Time , if want Do something
            print("End");
            //DialogueManager.GetComponent<DialogueManagerAlcohol3>().escogerDecision(-1);
            if (Pelea)
            {
                //Pierde la pelea, DialogueManager es Mojojojo
                DialogueManager.GetComponent<MojojojoController>().Golpear();
            }

        }

    }
}