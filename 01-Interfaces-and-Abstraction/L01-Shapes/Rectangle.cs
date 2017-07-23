using System;
using System.Text;

class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    public int Height
    {
        get { return this.height; }
        private set { this.height = value; }
    }

    //public void Draw()
    //{
    //    DrawLine(this.Width, '*', '*');
    //    for (int i = 1; i < this.Height - 1; ++i)
    //    {
    //        DrawLine(this.Width, '*', ' ');
    //    }
    //    DrawLine(this.Width, '*', '*');
    //}

    //private void DrawLine(int width, char end, char mid)
    //{
    //    Console.Write(end);
    //    for (int i = 1; i < width - 1; ++i)
    //    {
    //        Console.Write(mid);
    //    }
    //    Console.WriteLine(end);
    //}

    public void Draw()
    {
        var drawingSymbol = '*';
        var emptySymbol = ' ';

        var builder = new StringBuilder();
        for (int row = 0; row < this.height; row++)
        {
            builder.Append(drawingSymbol);
            if (row == 0 || row == this.height - 1)
            {
                builder.Append(DrawLine(this.width - 2, drawingSymbol));
            }
            else
            {
                builder.Append(DrawLine(this.width - 2, emptySymbol));
            }
            if (this.width >= 2)
            {
                builder.Append(drawingSymbol);
            }
            builder.AppendLine();
        }
        Console.WriteLine(builder.ToString().Trim());
    }

    private string DrawLine(int lineWidth, char symbol)
    {
        var lineBuilder = new StringBuilder();
        for (int i = 0; i < lineWidth; i++)
        {
            lineBuilder.Append(symbol);
        }
        return lineBuilder.ToString();
    }
}