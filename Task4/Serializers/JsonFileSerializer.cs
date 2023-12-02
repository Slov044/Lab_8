using System.Text.Json;

namespace Task4;

public class JsonFileSerializer : ICloneable<JsonFileSerializer>, IFileSerializer
{
    public JsonFileSerializer Clone()
    {
        return (JsonFileSerializer)MemberwiseClone();
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public void Save(DataSet data, Stream stream)
    {
        JsonSerializer.Serialize(stream, data);
    }

    public DataSet? Load(Stream stream)
    {
        return JsonSerializer.Deserialize<DataSet>(stream);
    }

    public string Extension => "json";
}