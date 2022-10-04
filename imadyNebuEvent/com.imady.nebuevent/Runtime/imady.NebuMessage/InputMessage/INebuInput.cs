
namespace imady.NebuEvent
{
    /// <summary>
    /// These message bodies are designed for Unity Engine.
    /// 用于描述硬件层或者Unity层的输入事件。
    /// 释义：Input - 特指各种输入（键盘、鼠标、虚拟按钮等）；NebuEvent（或简写为Msg）-- 通过imadyEventSystem发出的应用层消息。
    /// </summary>
    public interface INebuInput
    {
        /// <summary>
        /// Indicating the type of an inputMessage
        /// </summary>
        imadyInputTypeEnum InputType { get; }

        /// <summary>
        /// 指明输入的具体数据（例如button名称、Keycode等）
        /// Indicating the specific information of an inputMessage (e.g. button name, keycode)
        /// </summary>
        string Content { get; set; }


        /// <summary>
        /// 额外信息（可选）
        /// (optional) additional information for the message
        /// </summary>
        string msg { get; set; }
    }


    public enum imadyInputTypeEnum
    {
        FunctionKey = 0,
        WASD = 1,
        Key = 2,
        ArrowKey = 3,
        Mouse = 4,
        Gamepad = 5,
        VR = 6,
        UnityButton = 7,
        UnityCollision = 8,
        App =9
    }

}
