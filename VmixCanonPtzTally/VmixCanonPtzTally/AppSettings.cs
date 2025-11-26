using System.Xml.Serialization;

namespace VmixCanonPtzTally
{
    [XmlRoot("VmixTallySettings")]
    public class AppSettings
    {
        public string VmixIp { get; set; } = "127.0.0.1";
        public int VmixPort { get; set; } = 8099;

        [XmlArray("Cameras")]
        [XmlArrayItem("Camera")]
        public List<CameraConfig> Cameras { get; set; } = new List<CameraConfig>();

        public AppSettings() { }
    }
}
