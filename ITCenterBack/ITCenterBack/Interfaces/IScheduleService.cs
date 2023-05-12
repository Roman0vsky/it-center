namespace ITCenterBack.Interfaces
{
    public interface IScheduleService
    {
        Task CreateSchedule(string description, string image);
        Task UpdateSchedule(string description, string image);
    }
}
