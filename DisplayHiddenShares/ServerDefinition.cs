using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DisplayHiddenShares
{

    [DataContract]
    public class ServerDefinitions
    {
        [DataMember]
        public List<ServerDefinition> Servers { get; set; }

        public ServerDefinitions()
        {
            Servers = new List<ServerDefinition>();
        }
    }

    [DataContract]
    public class ServerDefinition
    {
        [DataMember]
        public string HostName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
