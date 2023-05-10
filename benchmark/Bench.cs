using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace GetHashCodeBench;

public class Bench
{
    private Data BuildNewData(Random rng, int keyLen)
    {
        const string alphabet = "abcdefghijklmnopqrstuwxyz0123456789";
        var sb = new StringBuilder(keyLen);
        for (int i = 0; i < keyLen; ++i)
        {
            sb.Append(alphabet[rng.Next(0, alphabet.Length-1)]);
        }

        return new(rng.Next(0, 10), sb.ToString());
    }

    private List<Data> left;
    private List<Data> right;
    private readonly ConstHashComparer _constHashComparer = new();
    private readonly FullKeyComparer _fullKeyComparer = new();
    
    [Params(100, 10_000)]
    public int LeftLen { get; set; }

    [Params(100, 10_000)]
    public int RightLen { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var rng = new Random();
        left = new List<Data>(LeftLen);
        for(int i = 0; i<LeftLen; ++i)
            left.Add(BuildNewData(rng, 10));

        right = new List<Data>(RightLen);
        for(int i = 0; i<RightLen; ++i)
            right.Add(BuildNewData(rng, 10));
    }

    [Benchmark]
    public List<Data> ConstHashComparer() => left.Except(right, _constHashComparer).ToList();

    [Benchmark]
    public List<Data> FullKeyComparer() => left.Except(right, _fullKeyComparer).ToList();
}
