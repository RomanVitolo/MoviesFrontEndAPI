using UnityEngine;

namespace ServerSettings
{
    [CreateAssetMenu(menuName = "ServerSetting/ApiController", fileName = "CMDKey")]
    public class ApiControllerSettings : ScriptableObject
    {
        [field: SerializeField] public string ApiControllerCMD { get; private set; }
    }
}