using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
    public class RemainingTimeText : MonoBehaviour
    {
        [SerializeField] private Text remainingTimeText;

        public void Set(int remainingTime)
        {
            remainingTimeText.text = Adjust(remainingTime);
        }

        public void TurnRed()
        {
            remainingTimeText.color = Color.red;
        }
    
        private string Adjust(int remainingTime)
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime - minutes * 60;
            
            return minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }
    }
}
