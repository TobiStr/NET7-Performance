using System.Text.Json;

namespace Performance.NET7.Benchmarks.Model;

public class SnakeCasePropertyNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        int upperCaseLength = 0;

        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] >= 'A' && name[i] <= 'Z' && name[i] != name[0])
            {
                upperCaseLength++;
            }
        }

        int bufferSize = name.Length + upperCaseLength;

        Span<char> buffer = new char[bufferSize];

        int bufferPosition = 0;

        int namePosition = 0;

        while (bufferPosition < buffer.Length)
        {
            if (namePosition > 0 && name[namePosition] >= 'A' && name[namePosition] <= 'Z')
            {
                buffer[bufferPosition] = '_';
                buffer[bufferPosition + 1] = name[namePosition];
                bufferPosition += 2;
                namePosition++;
                continue;
            }

            buffer[bufferPosition] = name[namePosition];

            bufferPosition++;

            namePosition++;
        }

        return buffer.ToString();
    }
}