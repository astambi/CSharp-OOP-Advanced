using System;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
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
            if (input.Equals(OutputMessages.InputOverCommand))
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

        this.gameController.RequestFinalSummary();
        this.writer.WriteMessages();
    }
}
