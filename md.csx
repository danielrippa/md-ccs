//css_nuget Markdig
//cs_winapp

using System;
using System.IO;
using Markdig;

class Program {

  static void Fail(string Message, int error = 1) {

    Console.Error.WriteLine("Usage: ");
    Environment.Exit(error);

  }

  static void Main(string[] args) {

    if (args.Length < 1) {

      Fail("Usage");

    }

    var filename = args[0];

    if (!File.Exists(filename)) {

      Fail($"File '{filename}' not found.");

    }

    try {

      var content = File.ReadAllText(filename);

      var pipeline = new MarkdownPipelineBuilder()

        .UseAdvancedExtensions()
        .UseYamlFrontMatter()
        .Build();

      var colorizedHtml = Markdown.ToHtml(content, pipeline);

      Console.WriteLine(colorizedHtml);

    } catch (Exception e) {
      Fail($"Error: {e.Message}");
    }

  }

}