using CorporateArena.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Domain
{
    public class UserService: IUserService
    {

        private readonly IUserRepo _uRepo;
        private readonly IPrivilegeRepo _pRepo;
        private readonly IRoleRepo _rRepo;
        private readonly IUserRoleRepo _uRRepo;
        private readonly IEmailSender _eService;

        public UserService(IUserRepo uRepo, IPrivilegeRepo pRepo, IRoleRepo rRepo, IUserRoleRepo uRRepo, IEmailSender eService)
        {
            _uRepo = uRepo;
            _pRepo = pRepo;
            _eService = eService;
            _rRepo = rRepo;
            _uRRepo = uRRepo;


        }

        public async Task<bool> ApproveUserAsync(int ID)
        {
            var status = await _uRepo.ApproveUser(ID);
            return status;
        }

        public async Task<Response> AssignRoletoUserAsync(int roleID, int userID)
        {
            var response = await _uRepo.AssignRoletoUser(roleID, userID);
            return response;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _uRepo.GetAllUsers();
            return users;
        }

        public async Task<User> GetUserWithRoleAsync(int ID)
        {
            var user = await _uRepo.GetUserWithRole(ID);
            //user.Role.Privileges=await _pRepo.get

            return user;
        }

        public async Task<Response> LoginAsync(string username, string password)
        {
            var response = await _uRepo.Login(username, password);
            return response;
        }

        public async Task<SaveResponse> RegisterUserAsync(User data)
        {
            
            // Check for empty fields

            if(!AllFieldsChecked(data))
                return new SaveResponse { Result = "One or more field(s) is/are empty", status = false };



            // check email validity

            if (!ValidateAddress(data.Email))
                return new SaveResponse { Result = "Email Address is Invalid", status = false };

            // check if email is already in use

            var EmailisUsed = await _uRepo.GetUserByEmail(data.Email);
            if(EmailisUsed)
                return new SaveResponse { Result = "Email Address is already in use", status = false };

            // check if username is already in use


            var UsernameisUsed = await _uRepo.GetUserByUsername(data.UserName);
            if (UsernameisUsed)
                return new SaveResponse { Result = "Username is already in use", status = false };


            // check if password is strong 

            if (!IsPasswordStrong(data.Password))
                return new SaveResponse { Result = @"Password must be atleast 8 characters long, 
                                                 must contain atleast one uppercase letter,one lowercase,one 
                                                 number and one symbol", status = false };






            var response = await _uRepo.RegisterUser(data);

            // assign default role to user

            await AssignRoletoUserAsync(data.RoleID, data.ID);

            // send account activation mail to users
             await _eService.ActivateAccountAsync(data.UserName, data.Email,response.ID);

            return response;
        }

        public async Task<Response> LoginWithTokenAsync(string token)
        {
            var response = await _uRepo.LoginWithToken(token);
            return response;

        }

        public async Task<bool> CheckIfUserExist(int ID)
        {
            bool Exist = false;

            var user = await _uRepo.GetUserWithRole(ID);
            if (user!= null && user.IsActive != false)
                Exist = true;

            return Exist;

        }



        public async Task<bool> CheckforPermission(int ID,string name)
        {

            bool isPermitted = false;
            var user = await GetUserWithRoleAsync(ID);

            if (user.Role.Name != "SuperAdmin")

                if(user.Role.Privileges!=null)
                {
                    foreach (var privilege in user.Role.Privileges)
                    {
                        if (privilege.Name == name)
                            isPermitted = true;
                    }
                }
                else
                {
                    isPermitted = false;

                }
                
            else
            {
                isPermitted = true;
            }
            return isPermitted;

        }

        private const int SALT_SIZE = 8;
        private const int NUM_ITERATIONS = 1000;

        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Creates a signature for a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>the "salt:hash" for the password.</returns>
        public static string CreatePasswordSalt(string password)
        {
            byte[] buf = new byte[SALT_SIZE];
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash;
        }

        /// <summary>
        /// Validate if a password will generate the passed in salt:hash.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <param name="saltHash">The "salt:hash" this password should generate.</param>
        /// <returns>true if we have a match.</returns>
        public static bool IsPasswordValid(string password, string saltHash)
        {
            string[] parts = saltHash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)

                return false;
            byte[] buf = Convert.FromBase64String(parts[0]);
            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }



        public bool UptoEight(string password)
        {
            if (password.Length > 7) return true;
            return false;

        }

        public bool ValidateAddress(string address)
        {
            try
            {
                MailAddress m = new MailAddress(address);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool IsPasswordStrong(string password)
        {
            var status = true;
            // check if password is strong 
            bool isLood = password.Any(p => !char.IsLetterOrDigit(p));
            bool isNum = password.Any(p => char.IsNumber(p));
            bool isUpper = password.Any(p => char.IsUpper(p));
            bool isLower = password.Any(p => char.IsLower(p));
            bool isUptoEight = UptoEight(password);

            if (!isLood || !isNum || !isUpper || !isLower || !isUptoEight)
                status = false;
            return status;
        }

        public bool AllFieldsChecked(User data)
        {
            var status = true;

            if (data.UserName == null || data.FirstName == null || data.LastName == null || data.PhoneNumber == null)
                status = false;

            return status;

        }

        public async Task<List<UserRole>> GetUserRoles()
        {
            var result =await _uRepo.GetUserRoles();
            return result;
        }

        public async Task<SaveResponse> ActivateSystemUserAsync()
        {

            // get superUser object

            var user = await _uRepo.GetUserByID(1);

            // update user with hash 

            var hash = CreatePasswordSalt(user.Password);

            user.Password = hash;
            await _uRepo.Update(user);



            return new SaveResponse {  status = true, Result = "System User was activated" };

        }

        public async Task<bool> GetUserByUsername(string username)
        {
            return await _uRepo.GetUserByUsername(username);
        }

        public async Task<User> GetUserByUsernameUser(string username)
        {
            return await _uRepo.GetUserByUsernameUser(username);
        }
    }
}
