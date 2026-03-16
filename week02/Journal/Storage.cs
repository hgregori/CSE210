using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class StorageService
{
    // Uses a custom separator line of "\n|\n" to separate entries.
    public static void SaveTxtWithPipeSeparator(string filePath, List<string> entries)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("\n⚠️ Invalid file name.");
            return;
        }

        {
            filePath = Path.ChangeExtension(filePath, ".txt");
        }
        try
        {
            if (string.IsNullOrWhiteSpace(Path.GetExtension(filePath)))
            {
                filePath = Path.ChangeExtension(filePath, ".txt");
            }

            string NormalizeNewlines(string s) =>
                (s ?? string.Empty).Replace("\r\n", "\n").Replace("\r", "\n");

            var normalized = new List<string>();
            foreach (var e in entries ?? new List<string>())
            {
                normalized.Add(NormalizeNewlines(e));
            }

            string content = string.Join("\n|\n", normalized);

            File.WriteAllText(filePath, content, Encoding.UTF8);
            Console.WriteLine($"\n✅ Journal saved to '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error saving file: {ex.Message}");
        }
    }

    public static List<string> LoadTxtWithPipeSeparator(string filePath)
    {
        var loaded = new List<string>();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("\n⚠️ Invalid file name.");
            return loaded;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"\n⚠️ File '{filePath}' not found. A new one will be created when you save.");
            return loaded;
        }

        try
        {
            string all = File.ReadAllText(filePath, Encoding.UTF8);

            all = all.Replace("\r\n", "\n").Replace("\r", "\n");
            all = all.Trim('\n');

            if (string.IsNullOrEmpty(all))
            {
                Console.WriteLine($"\n✅ Loaded 0 entries from '{filePath}'.");
                return loaded;
            }

            string[] parts = all.Split(new[] { "\n|\n" }, StringSplitOptions.None);

            foreach (var part in parts)
            {
                loaded.Add(part);
            }

            Console.WriteLine($"\n✅ Loaded {loaded.Count} entr{(loaded.Count == 1 ? "y" : "ies")} from '{filePath}'.");
            return loaded;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error loading file: {ex.Message}");
            return new List<string>();
        }
    }
}