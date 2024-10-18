using Plugins.Infinity.DI.Components;
using Plugins.Infinity.UI.Api;
using UnityEngine;

namespace Plugins.Infinity.UI.Components {
	public class UIVariantCloseComponent : BaseMonoInjectComponent {
		[SerializeField]
		private GameObject _uiVariantRoot;
		
		private readonly IInfinityUIService _infinityUIService;

		public void CloseUIVariant () {
			_infinityUIService.RemoveInterfaceVariantFromId(_uiVariantRoot.name);
		}
	}
}
