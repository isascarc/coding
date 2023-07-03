using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                // Load and add users
                var userData = await File.ReadAllTextAsync("data/UserSeedData.json");
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

                foreach (var user in users)
                {
                    using var hmac = new HMACSHA512();

                    user.Username = user.Username.ToString();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("p"));
                    user.PasswordSalt = hmac.Key;

                    context.Users.Add(user);
                }
            }

            // Load and add admins
            if (!await context.Admins.AnyAsync())
            {
                var adminData = await File.ReadAllTextAsync("data/AdminSeedData.json");
                var admins = JsonSerializer.Deserialize<List<AppAdmin>>(adminData);

                foreach (var admin in admins)
                {
                    using var hmac = new HMACSHA512();

                    admin.AdminName = admin.AdminName.ToString();
                    admin.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("p"));
                    admin.PasswordSalt = hmac.Key;

                    context.Admins.Add(admin);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}