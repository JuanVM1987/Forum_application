using System.Text.RegularExpressions;
using Domain.DTOs;

namespace Application.Logic.Validators;

public class ValidatorData
{
    public static void ValidateDataUser(UserCreationDto userCreate)
    {
        //validate username
        var username = userCreate.UserName;
        const string pattern1 = @"^.{4,16}$";
        Regex regex1 = new Regex(pattern1);
        if (!regex1.IsMatch(username))
        {
            throw new Exception("username must be at least 4 characters, and less than 16 characters!");
        }
        
        //validate password
        var password = userCreate.Password;
        const string pattern2 = @"(?=.*[a-z])" + @"(?=.*[A-Z])" + @"(?=.*\d)" + 
                                @"(?=.*[ !""#$%&'()*+,-./:;<=>?@\[\]\^_`{|}~])";
        
        var regex2 = new Regex(pattern2);
       
        if (!regex2.IsMatch(password))
        {
            throw new Exception("Password must contain uppercase and lowercase letters," +
                                " at least one number and special character!");
        }
        const string pattern3 = @"^.{8,32}$";
        var regex3 = new Regex(pattern3);
        if (!regex3.IsMatch(password))
        {
            throw new Exception("Password must be at least 8 characters, and less than 32 characters!");
        }
    }
}