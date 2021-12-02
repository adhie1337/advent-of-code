namespace AdventOfCode2021
{
    public interface ISolution
    {
        object Apply(string[] input);
    }

    public interface ISolution<T> : ISolution
    {
        new T Apply(string[] input);
    }

    public abstract class Solution<T> : ISolution<T>
    {
        public abstract T Apply(string[] input);

        object ISolution.Apply(string[] input) => ((ISolution<T>)this).Apply(input)!;
    }
}
