using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Infinity.UI.Components {
	public class ButtonThemeSwitcherComponent : MonoBehaviour {
		[SerializeField]
		private Image _button;

		[SerializeField]
		private Sprite _enabledTheme;

		[SerializeField]
		private Sprite _disabledTheme;

		[SerializeField]
		private bool _defaultState;

		public bool isActiveState { get; private set; }

		public void Init () {
			isActiveState = PlayerPrefs.GetInt("Sound", 1) == 1;
			SetupTrueSprite();
		}

		public void SwitchTheme () {
			isActiveState = !isActiveState;
			SetupTrueSprite();
		}

		private void SetupTrueSprite () {
			_button.sprite = isActiveState ? _enabledTheme : _disabledTheme;
		}
	}
}
