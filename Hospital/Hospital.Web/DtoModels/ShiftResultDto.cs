namespace Hospital.DtoModels;

public class ShiftResultDto
    {
        public DateTime CreateAt { get; set; }    
        public string Id { get; set; }    
        public int WorkDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Sance { get; set ; }

    }
