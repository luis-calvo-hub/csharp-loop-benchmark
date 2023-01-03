﻿using System.Diagnostics;

public class Program {
    private static int[] collection = new int[100000000];

    static void Main(string[] args) {
        Benchmark(BenchmarkFor);
        Benchmark(BenchmarkForCacheLength);
        Benchmark(BenchmarkForeach);
        Benchmark(BenchmarkDoWhile);
        Benchmark(BenchmarkDoWhileCacheLength);
    }

    private static void Benchmark(Action action) {
        Stopwatch sw = new();
        sw.Start();
        action.Invoke();
        sw.Stop();
        Console.WriteLine($"{sw.Elapsed.Milliseconds} Milliseconds has passed on: {action.Method.Name}");
    }

    private static void BenchmarkFor() {
        for(int i = 0; i < collection.Length; i++) {
            _ = i;
        }
    }

    private static void BenchmarkForCacheLength() {
        for(int i = 0, n = collection.Length; i < n; i++) {
            _ = i;
        }
    }

    private static void BenchmarkForeach() {
        foreach(int i in collection) {
            _ = collection[i];
        }
    }

    private static void BenchmarkDoWhile() {
        int i = 0;
        do {
            _ = collection[i];
            i++;
        }
        while(i < collection.Length);
    }

    private static void BenchmarkDoWhileCacheLength() {
        int i = 0;
        int length = collection.Length;
        do {
            _ = collection[i];
            i++;
        }
        while(i < length);
    }
}