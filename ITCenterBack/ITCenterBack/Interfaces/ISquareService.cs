using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface ISquareService
	{
		Task AddSquareAsync(string title, string textPreview, string content, string image);
		Task DeleteSquareAsync(long id);
		Task<Square> GetSquareAsync(long id);
		Task<List<Square>> GetAllSquares();
	}
}
