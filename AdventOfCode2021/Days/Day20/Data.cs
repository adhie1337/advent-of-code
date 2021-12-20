namespace AdventOfCode2021.Days.Day20
{
    using System.Collections;

    public readonly record struct Image(BitArray Rules, BitMatrix Pixels)
    {
        public bool NextDefault => this.Rules[this.Pixels.DefaultValue ? 511 : 0];

        public static Image Parse(string[] lines)
            => new Image()
            {
                Rules = new BitArray(lines[0].Select(c => c == '#').ToArray()),
                Pixels = new BitMatrix()
                {
                    Width = lines[2].Length,
                    Height = lines.Length - 2,
                    Array = new BitArray(lines.Skip(2).SelectMany(line => line.Select(c => c == '#')).ToArray()),
                    DefaultValue = false,
                },
            };

        public static Image Enhance(Image original)
            => original with
            {
                Pixels = new BitMatrix()
                {
                    Width = original.Pixels.Width + 2,
                    Height = original.Pixels.Height + 2,
                    Array = new BitArray(
                        Enumerable.Range(-1, original.Pixels.Height + 2)
                            .SelectMany(y => Enumerable.Range(-1, original.Pixels.Width + 2).Select(x => original.Rules[GetNextIndex(original, x, y)]))
                            .ToArray()
                    ),
                    DefaultValue = original.NextDefault,
                },
            };

        public static int GetNextIndex(Image image, int x, int y)
            => Enumerable.Range(y - 1, 3)
                .SelectMany(y => Enumerable.Range(x - 1, 3).Select(x => image.Pixels[x, y]))
                .Aggregate(0, (a, n) => a * 2 + (n ? 1 : 0));
    }

    public readonly record struct BitMatrix(int Width, int Height, bool DefaultValue, BitArray Array) : IEnumerable<bool>
    {
        public bool this[int x, int y]
        {
            get => this.Translate(x, y) is int i ? this.Array[i] : this.DefaultValue;
            set => this.Array[this.Translate(x, y) ?? -1] = value;
        }

        public IEnumerator<bool> GetEnumerator() => this.Array.OfType<bool>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.Array.GetEnumerator();

        public int? Translate(int x, int y) => x < 0 || y < 0 || x >= this.Width || y >= this.Height ? default(int?) : this.Width * y + x;
    }
}
