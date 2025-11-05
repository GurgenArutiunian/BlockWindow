using System.IO;
using System.Linq;

public static class GridFileLoader
{
	public static GridData LoadGrid(string filePath)
	{
		if (!File.Exists(filePath))
			throw new FileNotFoundException($"Grid file not found: {filePath}");

		var lines = File.ReadAllLines(filePath);
			
		//check empty lines
		var validLines = (from line in lines
			where !string.IsNullOrWhiteSpace(line)
			select line.Trim()).ToList();

		var height = validLines.Count;
		var width = validLines[0].Length;
		var grid = new int[width, height];

		for (var y = 0; y < height; y++)
		{
			var topY = height - y - 1;
			var line = validLines[topY];
			for (var x = 0; x < width; x++)
			{
				var c = line[x];
				//if char isn't number or <1 || >4 grid[x,y] force equals to 1
				if (char.IsDigit(c) && c - '0' is >= 1 and <= 4)
				{
					grid[x, y] = c - '0';
				}
				else
				{
					grid[x, y] = 1;
				}
			}
		}
		return new GridData(grid,width,height);
	}

	public static GridData CreateDefaultGrid(int width, int height)
	{
		var grid = new int[width, height];
		for (var y = 0; y < height; y++)
			for (var x = 0; x < width; x++)
				grid[x, y] = ((x + y) % 4) + 1;
		return new GridData(grid, width, height);
	}
}