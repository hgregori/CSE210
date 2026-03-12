using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Saving
{
    public static void SaveTxtWithPipeSeparator(string filePath, List<string> entries)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("\n⚠️ Invalid file name.");
            return;
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
}

class Loading
{
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

            // Normalize line endings
            all = all.Replace("\r\n", "\n").Replace("\r", "\n");

            // Split by a line that is exactly '|'
            // We can split on "\n|\n" to ensure it's a standalone separator line.
            // Also trim leading/trailing newlines for cleaner splits.
            all = all.Trim('\n');

            // Handle empty file gracefully
            if (string.IsNullOrEmpty(all))
                return loaded;

            string[] parts = all.Split(new[] { "\n|\n" }, StringSplitOptions.None);

            foreach (var part in parts)
            {
                // Rebuild using the same text; keep as-is
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