//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.BaxterMaintenance
{
    [Serializable]
    public class UpdateSourcesMsg : Message
    {
        public const string k_RosMessageName = "baxter_maintenance_msgs/UpdateSources";
        public override string RosMessageName => k_RosMessageName;

        public string uuid;
        public UpdateSourceMsg[] sources;

        public UpdateSourcesMsg()
        {
            this.uuid = "";
            this.sources = new UpdateSourceMsg[0];
        }

        public UpdateSourcesMsg(string uuid, UpdateSourceMsg[] sources)
        {
            this.uuid = uuid;
            this.sources = sources;
        }

        public static UpdateSourcesMsg Deserialize(MessageDeserializer deserializer) => new UpdateSourcesMsg(deserializer);

        private UpdateSourcesMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.uuid);
            deserializer.Read(out this.sources, UpdateSourceMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.uuid);
            serializer.WriteLength(this.sources);
            serializer.Write(this.sources);
        }

        public override string ToString()
        {
            return "UpdateSourcesMsg: " +
            "\nuuid: " + uuid.ToString() +
            "\nsources: " + System.String.Join(", ", sources.ToList());
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
