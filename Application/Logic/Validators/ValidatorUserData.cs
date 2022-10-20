using System.Net.Mail;
using System.Text.RegularExpressions;
using Domain.DTOs;

namespace Application.Logic.Validators;

public class ValidatorUserData
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
        //validate Email
        var emailAddress = new MailAddress(userCreate.Email);
        if (string.IsNullOrEmpty(userCreate.Email))
        {
            throw new Exception("Email can not be empty");
        }
        string patterEmail = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|dk|es)$";
        Regex regexEmail = new Regex(patterEmail,RegexOptions.IgnoreCase);
        if (!regexEmail.IsMatch(userCreate.Email))
        {
            throw new Exception("Email is not valid");
        }
        
        //validate password
        var password = userCreate.Password;
        const string pattern2 = @"(?=.*[a-z])" + @"(?=.*[A-Z])" + @"(?=.*\d)" + 
                                @"(?=.*[ !""#$%&'()*+,-./:;<=>?@\[\]\^_`{|}~])";
        
        var regex2 = new Regex(pattern2,RegexOptions.IgnoreCase);
       
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