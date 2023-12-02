using System.Xml.Serialization;

namespace Task4;

public class XmlFileSerializer : ICloneable<XmlFileSerializer>, IFileSerializer
{
    private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(DataSet));
    
    public XmlFileSerializer Clone()
    {
        return (XmlFileSerializer)MemberwiseClone();
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public void Save(DataSet data, Stream stream)
    {
        _xmlSerializer.Serialize(stream, data);
    }

    public DataSet? Load(Stream stream)
    {
        return _xmlSerializer.Deserialize(stream) as DataSet;
    }

    public string Extension => "xml";
}