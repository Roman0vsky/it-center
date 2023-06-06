using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface IAvaliableTimeService
	{
		//Task CreateSlotsForTimeAsync(long timeId);
		Task SetAvaliableSlotAsync(long id);
		Task DisableSlotAsync(long id);
		Task DisableAllAsync();
		Task<List<AvaliableTime>> GetAllSlotsAsync();
	}
}
