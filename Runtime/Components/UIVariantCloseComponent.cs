using Plugins.Modern.DI.Components;
using Plugins.Modern.UI.Api;
using UnityEngine;

namespace Plugins.Modern.UI.Components {
	public class UIVariantCloseComponent : ModernBaseMonoInjectComponent {
		[SerializeField]
		private GameObject _uiVariantRoot;
		
		private readonly IModernUIService _modernUIService;

		public void CloseUIVariant () {
			_modernUIService.RemoveInterfaceVariantFromId(_uiVariantRoot.name);
		}
	}
}
