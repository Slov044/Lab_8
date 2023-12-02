namespace Task4;

public interface IFileSerializer
{
    void Save(DataSet data, Stream stream);
    DataSet? Load(Stream stream);
    
    string Extension { get; }
}