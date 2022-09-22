
using System;
using Hospital.SharedKernel;

namespace Hospital.Core
{
    public class ShiftEntity : BaseEntity
    {
        public int WorkDay { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Sance { get; set ; }

        public ShiftEntity(int workDay, DateTime start, DateTime end)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            IsDeleted = false;
            WorkDay = workDay;
            Start = start;
            End = end;
        }


    }
   
}