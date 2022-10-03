using Newtonsoft.Json;

namespace imady.NebuEvent
{
    /// <summary>
    /// App level collision (e.g. mesh collision, mouse raycast collision)
    /// </summary>
    public class NebuUnityCollisionInput : INebuInput
    {
        [JsonProperty]
        public imadyInputTypeEnum InputType => imadyInputTypeEnum.UnityCollision;

        [JsonProperty]
        public string Content { get; set; }

        [JsonProperty]
        public string msg { get; set; }
    }
}
