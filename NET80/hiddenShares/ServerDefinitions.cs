namespace hiddenShares
{
    public class ServerDefinitions
    {
        public ServerDefinitions()
        {
            Servers = [];
        }        

        public List<ServerDefinition> Servers { get; set; }
    }

    public class ServerDefinition
    {
        public string HostName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}

