using UnityEngine.EventSystems;

namespace Charix.YandexGames.Samples
{
    public class WebEventSystem : EventSystem
    {
        protected override void OnApplicationFocus(bool hasFocus) => base.OnApplicationFocus(true);
    }
}
