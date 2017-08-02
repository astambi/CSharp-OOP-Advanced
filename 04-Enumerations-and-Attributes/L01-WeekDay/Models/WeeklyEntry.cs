using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay => this.weekDay;

    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        var result = this.WeekDay.CompareTo(other.WeekDay);
        //var result = ((int)this.WeekDay).CompareTo((int)other.WeekDay);

        if (result == 0)
        {
            result = this.Notes.CompareTo(other.Notes);
        }
        return result;
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}