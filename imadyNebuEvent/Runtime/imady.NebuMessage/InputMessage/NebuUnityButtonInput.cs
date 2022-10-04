using Newtonsoft.Json;

namespace imady.NebuEvent
{
    /// <summary>
    /// App level virtual button (gameobject attched with a 'Button' component)
    /// </summary>
    public class NebuUnityButtonInput : INebuInput
    {
        [JsonProperty]
        public imadyInputTypeEnum InputType => imadyInputTypeEnum.UnityButton;


        [JsonProperty]
        public string Content { get; set; }

        [JsonProperty]
        public string msg { get; set; }

        public object actionItem { get; set; }
    }
}
