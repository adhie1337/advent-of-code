namespace AdventOfCode2021.Days.Day03
{
    public readonly record struct PowerConsumpltionReport(int GammaRate, int EpsilonRate)
    {
        public int ToInt() => this.GammaRate * this.EpsilonRate;
    }
    
    public readonly record struct LifeSupportReport(int OxigenGeneratorRate, int Co2ScrubberRate)
    {
        public int ToInt() => this.OxigenGeneratorRate * this.Co2ScrubberRate;
    }
}
