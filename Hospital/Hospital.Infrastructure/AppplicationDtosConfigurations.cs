using Hospital.Core;
using Hospital.DtoModels;
using Hospital.DtoModels.UserDtos;
using Hospital.SharedKernel.Commands;
using Hospital.Web.DtoModels;
using Mapster;

namespace Hospital.Infrastructure
{
    public class AppplicationDtosConfigurations
    {

        static AppplicationDtosConfigurations _instance;
        public static AppplicationDtosConfigurations Instance => _instance ?? (_instance = new AppplicationDtosConfigurations());

        public void Initialize()
        {
            ConfigFor_CreateCommentDto_CommentEntity();
            ConfigFor_RegisteDoctorDto_CreateDoctorCommand();
            ConfigFor_CreateShiftDto_CreateShiftCommand();
            ConfigFor_ShiftEntity_CreateShiftCommand();
            ConfigFor_MakeReservationInputDto_MakeReservationCommand();
            ConfigFor_DoctorEntity_DoctorsResultDto();
            ConfigFor_ShiftEntity_ShiftReserveshionResultDto();
        }

        private AppplicationDtosConfigurations ConfigFor_CreateCommentDto_CommentEntity()
        {
            TypeAdapterConfig<RegisterUserDto, CreateUserCommand>
                .NewConfig()
                .Map(x => x.FirstName, x => x.FirstName)
                .Map(x => x.LastName, x => x.LastName)
                .Map(x => x.NationaCode, x => x.NationaCode)
                .Map(x => x.PassWord, x => x.PassWord);
            return this;
        }

        private AppplicationDtosConfigurations ConfigFor_RegisteDoctorDto_CreateDoctorCommand()
        {
            TypeAdapterConfig<RegisteDoctorDto, CreateDoctorCommand>
                .NewConfig()
                .Map(x => x.FirstName, x => x.FirstName)
                .Map(x => x.LastName, x => x.LastName)
                .Map(x => x.Specialty, x => x.Specialty);
            return this;
        }


        private AppplicationDtosConfigurations ConfigFor_CreateShiftDto_CreateShiftCommand()
        {
            TypeAdapterConfig<CreateShiftDto, CreateShiftCommand>
                .NewConfig()
                .Map(x => x.WorkDay, x => x.WorkDay)
                .Map(x => x.Start, x => x.Start)
                .Map(x => x.End, x => x.End);
            return this;
        }


        private AppplicationDtosConfigurations ConfigFor_ShiftEntity_CreateShiftCommand()
        {
            TypeAdapterConfig<ShiftEntity, ShiftResultDto>
                .NewConfig()
                .Map(x => x.WorkDay, x => x.WorkDay)
                .Map(x => x.Start, x => x.Start)
                .Map(x => x.End, x => x.End)
                .Map(x => x.CreateAt, x => x.CreateAt)
                .Map(x => x.Id, x => x.Id)
                .Map(x => x.Sance, x => x.Sance);
            return this;

        }



        private AppplicationDtosConfigurations ConfigFor_ShiftEntity_ShiftReserveshionResultDto()
        {
            TypeAdapterConfig<ShiftEntity, ShiftReserveshionResultDto>
                .NewConfig()
                .Map(x => x.WorkDay, x => x.WorkDay)
                .Map(x => x.Start, x => x.Start)
                .Map(x => x.End, x => x.End)
                .Map(x => x.Sance, x => x.Sance);
            return this;
        }


        private AppplicationDtosConfigurations ConfigFor_MakeReservationInputDto_MakeReservationCommand()
        {
            TypeAdapterConfig<MakeReservationInputDto, MakeReservationCommand>
                .NewConfig()
                .Map(x => x.UserId, x => x.UserId)
                .Map(x => x.DoctorId, x => x.DoctorId)
                .Map(x => x.ShiftId, x => x.ShiftId)
                ;
            return this;
        }




        private AppplicationDtosConfigurations ConfigFor_DoctorEntity_DoctorsResultDto()
        {
            TypeAdapterConfig<DoctorEntity, DoctorsResultDto>
                .NewConfig()
                .Map(x => x.Id, x => x.Id)
                .Map(x => x.FirstName, x => x.FirstName)
                .Map(x => x.LastName, x => x.LastName)
                .Map(x => x.Specialty, x => x.Specialty)
                ;
            return this;
        }

    }
}