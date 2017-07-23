using System.Text;

public abstract class Car : ICar
{
    private string model;
    private string color;

    public Car(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
    }

    public string Color
    {
        get { return this.color; }
        private set { this.color = value; }
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    protected virtual string GetCarInfo()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model}";
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder
            .AppendLine(this.GetCarInfo())
            .AppendLine(this.Start())
            .AppendLine(this.Stop());
        return builder.ToString().Trim();
    }
}