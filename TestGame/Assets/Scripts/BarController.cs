
using UnityEngine;
using UnityEngine.UI;

namespace TestGame.Names
{
    public class BarController : MonoBehaviour
    {
        [SerializeField] private Image _imgBar;
        public void ChangeValueBar(float _currentValue)
        {
            _imgBar.fillAmount = _currentValue / GlobalValues.MaximumNumberBlocks;
            Debug.Log(_currentValue + +  GlobalValues.MaximumNumberBlocks);
        }
    }
}

