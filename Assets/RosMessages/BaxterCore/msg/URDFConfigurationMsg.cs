//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.BuiltinInterfaces;

namespace RosMessageTypes.BaxterCore
{
    [Serializable]
    public class URDFConfigurationMsg : Message
    {
        public const string k_RosMessageName = "baxter_core_msgs/URDFConfiguration";
        public override string RosMessageName => k_RosMessageName;

        // # URDF Configuration
        public TimeMsg time;
        //  time the message was created, serves as a sequence number
        //  time should be changed only when the content changes.
        public string link;
        //  parent link name
        public string joint;
        //  joint to configure
        //  link + joint + time uniquely identifies a configuration.
        public string urdf;
        //  XML or JSON-encoded URDF data.  This should be a URDF fragment
        //  describing the entire subtree for the given joint attached
        //  to the given parent link. If this field is empty the joint
        //  is removed from the parent link.

        public URDFConfigurationMsg()
        {
            this.time = new TimeMsg();
            this.link = "";
            this.joint = "";
            this.urdf = "";
        }

        public URDFConfigurationMsg(TimeMsg time, string link, string joint, string urdf)
        {
            this.time = time;
            this.link = link;
            this.joint = joint;
            this.urdf = urdf;
        }

        public static URDFConfigurationMsg Deserialize(MessageDeserializer deserializer) => new URDFConfigurationMsg(deserializer);

        private URDFConfigurationMsg(MessageDeserializer deserializer)
        {
            this.time = TimeMsg.Deserialize(deserializer);
            deserializer.Read(out this.link);
            deserializer.Read(out this.joint);
            deserializer.Read(out this.urdf);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.time);
            serializer.Write(this.link);
            serializer.Write(this.joint);
            serializer.Write(this.urdf);
        }

        public override string ToString()
        {
            return "URDFConfigurationMsg: " +
            "\ntime: " + time.ToString() +
            "\nlink: " + link.ToString() +
            "\njoint: " + joint.ToString() +
            "\nurdf: " + urdf.ToString();
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
