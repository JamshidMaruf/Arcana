using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.Instructors;
using Arcana.WebApi.Models.Permissions;
using Arcana.WebApi.Models.QuestionAnswers;
using Arcana.WebApi.Models.RolePermissions;
using Arcana.WebApi.Models.Students;
using Arcana.WebApi.Models.UserRoles;
using Arcana.WebApi.Models.Users;
using AutoMapper;

namespace Arcana.WebApi.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetViewModel, Asset>().ReverseMap();

        CreateMap<InstructorViewModel, Instructor>().ReverseMap();
        CreateMap<Instructor, InstructorCreateModel>().ReverseMap();
        CreateMap<Instructor, InstructorUpdateModel>().ReverseMap();

        CreateMap<PermissionViewModel, Permission>().ReverseMap();
        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();

        CreateMap<RolePermissionViewModel, RolePermission>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateModel>().ReverseMap();

        CreateMap<StudentViewModel, Student>().ReverseMap();
        CreateMap<Student, StudentCreateModel>().ReverseMap();
        CreateMap<Student, StudentUpdateModel>().ReverseMap();

        CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();

        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserLoginViewModel, User>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();

        CreateMap<QuestionAnswerViewModel, QuestionAnswer>().ReverseMap();
        CreateMap<QuestionAnswer, QuestionAnswerCreateModel>().ReverseMap();
        CreateMap<QuestionAnswer, QuestionAnswerUpdateModel>().ReverseMap();
    }
}
