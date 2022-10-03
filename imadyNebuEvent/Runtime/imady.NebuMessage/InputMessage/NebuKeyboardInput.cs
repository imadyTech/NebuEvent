using Newtonsoft.Json;

namespace imady.NebuEvent
{
    /// <summary>
    /// Hardware system level keyboard input (e.g. click, right-click, drag.)
    /// </summary>
    public class NebuKeyboardInput : INebuInput
    {
        [JsonProperty]
        public imadyInputTypeEnum InputType => imadyInputTypeEnum.Key;

        /// <summary>
        /// indicating the specific key clicked
        /// </summary>
        [JsonProperty]
        public string Content { get; set; }

        [JsonProperty]
        public string msg { get; set; }
    }


}
