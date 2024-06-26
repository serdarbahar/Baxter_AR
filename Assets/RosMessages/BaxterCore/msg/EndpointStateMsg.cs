//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.BaxterCore
{
    [Serializable]
    public class EndpointStateMsg : Message
    {
        public const string k_RosMessageName = "baxter_core_msgs/EndpointState";
        public override string RosMessageName => k_RosMessageName;

        public HeaderMsg header;
        public Geometry.PoseMsg pose;
        public Geometry.TwistMsg twist;
        public Geometry.WrenchMsg wrench;

        public EndpointStateMsg()
        {
            this.header = new HeaderMsg();
            this.pose = new Geometry.PoseMsg();
            this.twist = new Geometry.TwistMsg();
            this.wrench = new Geometry.WrenchMsg();
        }

        public EndpointStateMsg(HeaderMsg header, Geometry.PoseMsg pose, Geometry.TwistMsg twist, Geometry.WrenchMsg wrench)
        {
            this.header = header;
            this.pose = pose;
            this.twist = twist;
            this.wrench = wrench;
        }

        public static EndpointStateMsg Deserialize(MessageDeserializer deserializer) => new EndpointStateMsg(deserializer);

        private EndpointStateMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            this.pose = Geometry.PoseMsg.Deserialize(deserializer);
            this.twist = Geometry.TwistMsg.Deserialize(deserializer);
            this.wrench = Geometry.WrenchMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.pose);
            serializer.Write(this.twist);
            serializer.Write(this.wrench);
        }

        public override string ToString()
        {
            return "EndpointStateMsg: " +
            "\nheader: " + header.ToString() +
            "\npose: " + pose.ToString() +
            "\ntwist: " + twist.ToString() +
            "\nwrench: " + wrench.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
