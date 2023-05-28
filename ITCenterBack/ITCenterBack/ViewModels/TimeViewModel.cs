using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
    public class TimeViewModel
    {
        public long Id { get; set; }
        [DataType(DataType.Time)]
        public DateTime From { get; set; }
        [DataType(DataType.Time)]
        public DateTime To { get; set; }
    }
}
