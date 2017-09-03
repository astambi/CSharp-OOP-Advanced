using System;

public class Engine : IEngine
{
    public const string InputOverCommand = "Enough! Pull back!";

    private IWriter writer;
    private IReader reader;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();
            if (input == InputOverCommand)
            {
                break;
            }

            try
            {
                this.gameController.ProcessInput(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.AppendMessage(arg.Message);
            }
        }

        this.gameController.RequestGameResult();
        this.writer.WriteResult();
    }
}
