﻿using System.Diagnostics;

public class Program {
    static void Main(string[] args) {
        new Benchmarker(1000000000);
    }
}

public class Benchmarker {
    private static int[] collection = new int[0];

    public Benchmarker(int operations) {
        collection = new int[operations];

        Benchmark(For);
        Benchmark(ForWithCache);
        Benchmark(Foreach);
        Benchmark(While);
        Benchmark(WhileWithCache);
        Benchmark(DoWhile);
        Benchmark(DoWhileWithCache);
    }

    private static void Benchmark(Action action) {
        Stopwatch sw = new();
        sw.Start();
        action.Invoke();
        sw.Stop();
        Console.WriteLine($"Benchmarking: {sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}s -> {action.Method.Name}");
    }

    private static void For() {
        for(int i = 0; i < collection.Length; i++) {
            _ = i;
        }
    }

    private static void ForWithCache() {
        for(int i = 0, n = collection.Length; i < n; i++) {
            _ = i;
        }
    }

    private static void Foreach() {
        foreach(int i in collection) {
            _ = collection[i];
        }
    }

    private static void While() {
        int i = 0;
        while(i < collection.Length){
            _ = collection[i];
            i++;
        }
    }

    private static void WhileWithCache() {
        int i = 0;
        int length = collection.Length;
        while(i < length){
            _ = collection[i];
            i++;
        }
    }

    private static void DoWhile() {
        int i = 0;
        do {
            _ = collection[i];
            i++;
        }
        while(i < collection.Length);
    }

    private static void DoWhileWithCache() {
        int i = 0;
        int length = collection.Length;
        do {
            _ = collection[i];
            i++;
        }
        while(i < length);
    }
}