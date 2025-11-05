public class GridData
{
	private int[,] Data { get; }
	private int Width { get; }
	private int Height { get; }

	public GridData(int[,] data, int width, int height)
	{
		Data = data;
		Width = width;
		Height = height;
	}

	public int GetValueWrapped(int x, int y)
	{
		x = WrapCoordinate(x, Width);
		y = WrapCoordinate(y, Height);
		return Data[x, y];
	}

	private static int WrapCoordinate(int value, int max)
	{
		while (value < 0)
			value += max;

		while (value >= max)
			value -= max;

		return value;
	}
}