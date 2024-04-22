using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileManager {
	private string currentWriteFilePath;
	private string dataPath;
	private StreamReader reader;


	public FileManager(string dataPath) {
		this.dataPath = dataPath;
		reader = null;
	}
	
	public string GetNextFileName() {
		var fileNumber = Directory.GetFiles(dataPath).Select(f => int.Parse(f.Split('S', '.')[1])).Prepend(-1).Max();
		return $"S{++fileNumber}";
	}

	public void CreateCSV(string labels) {
		currentWriteFilePath = dataPath + "/" + GetNextFileName() + ".csv";
		File.WriteAllText(currentWriteFilePath, labels);
	}


	//Overwrite already present file
	public void CreateCSV(string filename, string labels) {
		currentWriteFilePath = dataPath + "/" + filename + ".csv";

		File.WriteAllText(currentWriteFilePath, labels);
	}

	public void SaveDataLine(List<object> data, string timestamp) {
		var formatData = data.Aggregate("", (current, d) => current + (d + ";"));

		formatData = Environment.NewLine + formatData + timestamp;
		File.AppendAllText(currentWriteFilePath, formatData);
	}

	public void SaveDataLineFloat(List<float> data, string timestamp) {
		var formatData = data.Aggregate("", (current, d) => current + (d + ";"));

		formatData = Environment.NewLine + formatData + timestamp;
		File.AppendAllText(currentWriteFilePath, formatData);
	}

	public void SaveDataLine(List<object> data) {
		var formatData = data.Aggregate("", (current, d) => current + (d + ";"));

		formatData = formatData.Remove(formatData.Length - 1);

		formatData = Environment.NewLine + formatData;
		File.AppendAllText(currentWriteFilePath, formatData);
	}

	public List<List<string>> ReadAllCSV(string filename) {
		var reader = new StreamReader(dataPath + "/" + filename + ".csv");

		var list = new List<List<string>>();

		while (!reader.EndOfStream) {
			var line = reader.ReadLine();

			list.Add(new(line.Split(";")));
		}

		return list;
	}

	public void OpenCSVRead(string filename) {
		reader = new(dataPath + "/" + filename + ".csv");
	}

	public List<string> ReadCSVLine() {
		if (reader is not {EndOfStream: false}) return null;
		var line = reader.ReadLine();

		if (line != null) return new(line.Split(";"));
		return new();
	}
}
