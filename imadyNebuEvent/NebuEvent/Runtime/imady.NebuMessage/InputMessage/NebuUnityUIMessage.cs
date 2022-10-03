using Newtonsoft.Json;

namespace imady.NebuEvent
{
    /// <summary>
    /// Messages from Unity UI actions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NebuUnityUIMessage<T> : NebuMessageBase where T : INebuInput
    {
        public virtual T messageBody { get; set; }


        public NebuUnityUIMessage() { }

        public NebuUnityUIMessage(T messageBody)
        {
            this.messageBody = messageBody;
        }
    }


    #region 具象消息的封装定义 - 非扩展需求下此框架冗余，抽象需求下此框架有利于消息响应调度（简单需求慎用）
    #region 场景模式切换相关消息体
    public class StartMsg : NebuUnityButtonInput, INebuInput
    {
        public StartMsg() { msg = "SimulationStartMsg"; }
    }
    public class EndMsg : NebuUnityButtonInput, INebuInput
    {
        public EndMsg() { msg = "SimulationEndMsg"; }
    }
   #endregion

    #region 视角切换相关消息体
    public class RearViewMsg : NebuUnityButtonInput, INebuInput
    {
        public RearViewMsg() { Content = ""; msg = ""; }
    }
    public class SideViewMsg : NebuUnityButtonInput, INebuInput
    {
        public SideViewMsg() { Content = ""; msg = ""; }
    }
    public class FirstViewMsg : NebuUnityButtonInput, INebuInput
    {
        public FirstViewMsg() { Content = ""; msg = "SateEarthView"; }
    }
    #endregion

    #region Play控制相关消息体
    public class PauseMsg : NebuUnityButtonInput, INebuInput
    {
        public int SateSpeedX = 0;
        public PauseMsg() { }
    }
    public class PlayMsg : NebuUnityButtonInput, INebuInput
    {
        public PlayMsg() { }
    }

    #endregion

    #region 3D/2D相关消息体
    public class Mdy3DViewMsg : NebuUnityButtonInput, INebuInput
    {
        public Mdy3DViewMsg() { Content = ""; msg = "3D"; }
    }
    public class Mdy2DViewMsg : NebuUnityButtonInput, INebuInput
    {
        public Mdy2DViewMsg() { Content = ""; msg = "2D"; }
    }
    #endregion

    #region 键盘、鼠标操作相关消息体
    public class MouseDragMsg: NebuMouseInput, INebuInput
    {
        public MouseDragMsg() { }
        public MouseDragMsg(float deltaX, float deltaY, float screenX, float screenY) 
        { 
            base.xDragDeltaRatio = deltaX; 
            base.yDragDeltaRatio = deltaY;
            base.xDragCenterRatio = screenX;
            base.yDragCenterRatio = screenY;
        }
        public MouseDragMsg(float deltaX, float deltaY) { base.xDragDeltaRatio = deltaX; base.yDragDeltaRatio = deltaY; }
        public MouseDragMsg(float scroll) { base.scrollRatio = scroll; }
    }


    public class CameraScrollMsg : NebuMessageBase, INebuInput
    {
        [JsonProperty]
        public imadyInputTypeEnum InputType => imadyInputTypeEnum.App;

        [JsonProperty]
        public float CameraScale { get; set; }

        [JsonProperty]
        public string Content { get; set; }

        [JsonProperty]
        public string msg { get; set; }
    }


    #endregion

    #endregion
}
