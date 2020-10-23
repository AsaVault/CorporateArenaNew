using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateArena.Domain
{
    public class Permission
    {
        
        public const string CreateUser = "CreateUser";
        public const string ReadUser = "ReadUser";
        public const string UpdateUser = "UpdateUser";
        public const string DeleteUser = "DeleteUser";
        public const string AssignRoleToUser = "CreateUserRole";
        public const string CreateRole = "CreateRole";
        public const string ReadRole = "ReadRole";
        public const string UpdateRole = "UpdateRole";
        public const string DeleteRole = "DeleteRole";
        public const string AssignPrivilegeToRole = "CreateRolePrivilege";
        public const string CreateBrainTeaser = "CreateBrainTeaser";
        public const string ReadBrainTeaser = "ReadBrainTeaser";
        public const string UpdateBrainTeaser = "UpdateBrainTeaser";
        public const string DeleteBrainTeaser = "DeleteBrainTeaser";
        public const string CreateVacancy = "CreateVacancy";
        public const string ReadVacancy = "ReadVacancy";
        public const string UpdateVacancy = "UpdateVacancy";
        public const string DeleteVacancy = "DeleteVacancy";
        public const string CreateArticle = "CreateArticle";
        public const string ReadArticle = "ReadArticle";
        public const string UpdateArticle = "UpdateArticle";
        public const string DeleteArticle = "DeleteArticle";
        public const string LikeArticle = "LikeArticle";
        public const string CommentArticle = "CommentArticle";
        public const string CreateArticleComment = "CreateArticleComment";
        public const string LikeArticleComment = "LikeArticleComment";
        public const string CreateTrafficUpdate = "CreateTrafficUpdate ";
        public const string ReadTrafficUpdate = "ReadTrafficUpdate";
        public const string UpdateTrafficUpdate = "UpdateTrafficUpdate";
        public const string DeleteTrafficUpdate = "DeleteTrafficUpdate";
    }
}
