using CorporateArena.Domain;
using CorporateArena.Presentation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Infrastructure
{
    public class UserRepo:IUserRepo
    {
        private readonly TContext _context;
        private readonly JwtOpt _jwtOpt;
        public UserRepo(TContext context, IOptions<JwtOpt> jwtOpt)
        {
            _context = context;
            _jwtOpt = jwtOpt.Value;
        }

        public async Task<bool> ApproveUser(int ID)
        {
            var user =await  _context.AppUsers.FindAsync(ID);
            try
            {
                user.IsActive = true;
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = await _context.AppUsers.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                var userroles = await _context.UserRoles.ToListAsync();
                return userroles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //private const int SaltByteSize = 24;
        //private const int HashByteSize = 24;
        //private const int HasingIterationsCount = 10101;

        //internal static byte[] GenerateSalt(int saltByteSize = SaltByteSize)
        //{
        //    using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
        //    {
        //        byte[] salt = new byte[saltByteSize];
        //        saltGenerator.GetBytes(salt);
        //        return salt;
        //    }
        //}

        //internal static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        //{
        //    using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
        //    {
        //        hashGenerator.IterationCount = iterations;
        //        return hashGenerator.GetBytes(hashByteSize);
        //    }
        //}

        //public string HashPassword(string password)
        //{




        //    password.PasswordSalt = Convert.ToBase64String(passwordSaltKey);

        //    //To bytes from base64 string
        //    byte[] passwordSalt = Convert.FromBase64String(passwordSaltKey);
        //    //byte[] salt = new byte[128 / 8];
        //    //string hash;


        //    //var rng = new RNGCryptoServiceProvider();


        //    //    rng.GetBytes(salt);
        //    //hash = Convert.ToBase64String(salt);
        //    //var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);

        //    return hash;
        //}


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

        public async Task<SaveResponse> RegisterUser(User data)
        {
            

            
            try
            {

                // Assign the basic role to user if no role is selected
                if (data.RoleID == 0) data.RoleID = 2;  

                // hash password
                var password = CreatePasswordSalt(data.Password);

                var user = new User
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    IsActive = false,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    OtherName = data.OtherName,
                    PhoneNumber = data.PhoneNumber,
                    Password=password,
                    RoleID=data.RoleID

                };
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                data.ID = user.ID;
                return new SaveResponse { Result = "New User created Successfully", status = true,ID=user.ID };
            }
            catch (Exception ex)
            {
                throw ex;
            
            }
        
        }

        public string CreateToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId,user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };
            var stoken = new JwtSecurityToken(
                        issuer: "",
                        audience: "",
                        claims:claims,
                        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtOpt.ExpiryTime)),
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey
                        (Encoding.ASCII.GetBytes(_jwtOpt.Secret)), SecurityAlgorithms.HmacSha256)
                    );
            var token = new JwtSecurityTokenHandler().WriteToken(stoken);
            return token;

        }

        public async Task<Response> Login(string username, string password)
        {
            User user;

            try
            {
                
                
                user = await _context.AppUsers.Where(x => x.UserName == username ).FirstOrDefaultAsync();
                bool isValid = IsPasswordValid(password, user.Password);
                 if (isValid == false) return new Response {status=false,Result="Username and/or password invalid" };

                // create token
                user.Token = CreateToken(user);
                _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();

                return new Response { status = true, Result = user.Token };
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public async Task<Response> LoginWithToken(string token)
        {
            try
            {
                var user = await _context.AppUsers.Where(x => x.Token == token).SingleAsync();
                if (user == null) return new Response { status = false, Result = "Login Failed" };
                return new Response { status = true, Result = "Login Successful" }; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public async Task<Response> AssignRoletoUser(int roleID, int userID)
        {
            

            try
            {

                var userRole = await _context.UserRoles.Where(x => x.UserID == userID).FirstOrDefaultAsync();
                if (userRole != null)
                {
                    var user = await _context.AppUsers.FindAsync(userID);
                    user.RoleID = roleID;

                    userRole.RoleID = roleID;
                    _context.AppUsers.Update(user);
                    _context.UserRoles.Update(userRole);
                    await _context.SaveChangesAsync();
                    return new Response { status = true, Result = "User updated with new role" };
                }


                else
                {
                    UserRole data = new UserRole
                    {
                        RoleID = roleID,
                        UserID = userID
                    };

                    await _context.UserRoles.AddAsync(data);
                    await _context.SaveChangesAsync();
                    return new Response { status = true, Result = "Successful" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //    var userRole = await _context.UserRoles.Where(x => x.RoleID == roleID && x.UserID == userID).FirstOrDefaultAsync();
            //    if (userRole != null)
            //        return new Response { status = false, Result = "Role has already been assigned to this user" };


            //    UserRole data = new UserRole
            //    {
            //        RoleID = roleID,
            //        UserID = userID
            //    };

            //    await _context.UserRoles.AddAsync(data);
            //    await _context.SaveChangesAsync();
            //    return new Response { status = true, Result = "Successful" };
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public async Task<User> GetUserWithRole(int ID)
        {
            try
            {
                var user = await _context.AppUsers.FindAsync(ID);
                //var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

                //if (userRole != null) user.Role = await _context.Roles.Where(x => x.ID == userRole.RoleID).SingleAsync();


                //return user;

                user = await _context.AppUsers.FindAsync(ID);
                var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

                // this needs to be optimized
                if (userRole != null)
                {
                    user.Role = await _context.Roles.Where(x => x.ID == userRole.RoleID).SingleAsync();
                    var rolePrivileges = await _context.RolePrivileges.Where(x => x.RoleID ==/*roleId must be updated in user*/ user.RoleID).ToListAsync();
                    if (rolePrivileges != null)
                    {
                        var privs = new List<Privilege>();
                        foreach(var rp in rolePrivileges)
                        {
                            var priv = await _context.Privileges.Where(x => x.ID == rp.PrivilegeID).SingleAsync();

                            privs.Add(priv);
                        }
                        user.Role.Privileges = privs;
                        //user.Role.Privileges = await _context.Privileges.Where(x => x.ID == user.RoleID).ToListAsync();
                    }
                }// this needs to be optimized
                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            //user = await _context.AppUsers.FindAsync(ID);
            //var userRole = await _context.UserRoles.Where(x => x.UserID == ID).SingleOrDefaultAsync();

            //if (userRole != null)
            //{
            //    user.Role = await _context.Roles.Where(x => x.ID == userRole.RoleID).SingleAsync();
            //    if (user.Role.Privileges != null)
            //    {
            //        user.Role.Privileges = await _context.Privileges.Where(x => x.ID == user.RoleID).ToListAsync();
            //    }
            //}




            //return user;
        }

        public async Task<bool> GetUserByEmail(string email)
        {
            var status = false;
            try
            {
               var user = await _context.AppUsers.Where(x => x.Email == email).SingleOrDefaultAsync();
                if (user != null)
                    return status=true;

            }
            catch
            {
                return status;
            }
            return status;
        }

        public async Task<User> GetUserByID(int ID)
        {
            try
            {
                var user = await _context.AppUsers.Where(x => x.ID == ID).SingleOrDefaultAsync();
                return user;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // return true if username is already used, false if otherwise
        public async Task<bool> GetUserByUsername(string username)
        {
            var status = false;
            
            try
            {
                var user = await _context.AppUsers.Where(x => x.UserName == username).SingleOrDefaultAsync();
                if (user != null)
                    return status=true;

            }
            catch
            {
                return status;
            }
            return status;
        }

        // return true if username is already used, false if otherwise
        public async Task<User> GetUserByUsernameUser(string username)
        {
            try
            {
                var user = await _context.AppUsers.Where(x => x.UserName == username).SingleOrDefaultAsync();
                    return user;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateSystemUserAsync(int roleID)
        {
            try
            {
                var user = new User
                {
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    Email = "tkolawole@inspirecoders.com",
                    FirstName = "System",
                    LastName = "User",
                    Password = "Inspirecoders1@",
                    RoleID = roleID,
                    UserName = "SystemUser",
                    PhoneNumber = "080373762728"
                };
                await _context.AppUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return user.ID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(User data)
        {
            try 
            {
                var user = await _context.AppUsers.FindAsync(data.ID);
                if (data.Password != null) user.Password = data.Password;

                 _context.AppUsers.Update(user);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
