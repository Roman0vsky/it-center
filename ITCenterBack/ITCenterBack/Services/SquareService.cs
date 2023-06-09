using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
	public class SquareService : ISquareService
	{
		private readonly IRepository<Square> _squareRepository;

		public SquareService(IRepository<Square> squareRepository)
		{
			_squareRepository = squareRepository;
		}

		public async Task AddSquareAsync(string title, string textPreview, string content, string image)
		{
			if(!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(textPreview) && !string.IsNullOrWhiteSpace(image))
			{
				var square = new Square
				{
					Title = title,
					TextPreview = textPreview,
					Content = content,
					Image = image
				};

				await _squareRepository.CreateAsync(square);
			}
		}

		public async Task DeleteSquareAsync(long id)
		{
			var square = await _squareRepository.GetByIdAsync(id);

			if(square != null)
			{
				await _squareRepository.DeleteAsync(id);
			}
		}

		public async Task<List<Square>> GetAllSquares()
		{
			return await _squareRepository.GetAllAsync();
		}

		public async Task<Square> GetSquareAsync(long id)
		{
			return await _squareRepository.GetByIdAsync(id);
		}
	}
}
