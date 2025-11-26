namespace VmixCanonPtzTally
{
    public class CameraConfig
    {
        public int Number { get; set; }
        public string IpAddress { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public CameraConfig() { }

        public CameraConfig(int number, string ip, string username, string password)
        {
            Number = number;
            IpAddress = ip;
            Username = username;
            Password = password;
        }
    }
}
