namespace _01.Stream_Progress
{
    public interface IStreamable
    {
        int Length { get;  }

        int BytesSent { get;  }
    }
}