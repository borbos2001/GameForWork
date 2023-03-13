
using UnityEngine;
using UnityEngine.UI;

namespace TestGame.Names
{
    public class BarController : MonoBehaviour
    {
        [SerializeField] private Image _imgBar;
        private void ChangeValueBar(int _currentValue)
        {
            _imgBar.fillAmount = _currentValue / GlobalValues.MaximumNumberBlocks;
        }
    }
}

