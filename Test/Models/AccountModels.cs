using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using System.Data.SqlClient;
using Test;


namespace Test.Models
{

    #region 模型
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "新密码和确认密码不匹配。")]

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("新密码")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("确认新密码")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        [DisplayName("记住我?")]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "密码和确认密码不匹配。")]
    public class RegisterModel
    {
        [Required(ErrorMessage = "用户名不能为空!")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空!")]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("确认密码")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("用户类型")]
        public string Usertype { get; set; }

    }
    #endregion

    #region Services
    // FormsAuthentication 类型是密封的且包含静态成员，因此很难对
    // 调用其成员的代码进行单元测试。下面的接口和 Helper 类演示
    // 如何围绕这种类型创建一个抽象包装，以便可以对 AccountController
    // 代码进行单元测试。

    public interface IMembershipService
    {
        int MinPasswordLength { get; }
        bool IsUserNameExist(string userName);
        bool ValidateUser(string userName, string password);
        bool CreateUser(string userName, string password, string usertype);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            string un = userName;
            string pw = password;
            string con = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString();

            DataDataContext bdc = new DataDataContext();

            var result = from n in bdc.Users
                         where n.Name == un
                         select n;

            foreach (var n in result)
            {
                if (n.PassWord == pw)
                    return true;
            }
         
            return false;
        }

        public int GetUsersCount()
        {
            int count = 0;
            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.Users
                         select n.ID;

            foreach (var n in result)
                count = n;
            return count;
        }

        public bool CreateUser(string userName, string password, string usertype)
        {
            DataDataContext dbc = new DataDataContext();
            int Uid = GetUsersCount() + 1;

            Users us = new Users
            {
                ID = Uid,
                Name = userName,
                PassWord = password,
                UserType = usertype
            };

            dbc.Log = Console.Out;
            dbc.Users.InsertOnSubmit(us);
            dbc.SubmitChanges();

            return true;
        }

        public bool IsUserNameExist(string userName)
        {
                DataDataContext dbc = new DataDataContext();

                var result = from n in dbc.Users
                             select n.Name;
                foreach (var n in result)
                    if (n == userName) return true;
                return false;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("值不能为 null 或为空。", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("值不能为 null 或为空。", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("值不能为 null 或为空。", "newPassword");

            // 在某些出错情况下，基础 ChangePassword() 将引发异常，
            // 而不是返回 false。
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("值不能为 null 或为空。", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);



        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // 请参见 http://go.microsoft.com/fwlink/?LinkID=177550 以查看
            // 状态代码的完整列表。
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已存在。请另输入一个用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "已存在与该电子邮件地址对应的用户名。请另输入一个电子邮件地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码无效。请输入有效的密码值。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的电子邮件地址无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "提供的密码取回答案无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidQuestion:
                    return "提供的密码取回问题无效。请检查该值并重试。";

                case MembershipCreateStatus.InvalidUserName:
                    return "提供的用户名无效。请检查该值并重试。";

                case MembershipCreateStatus.ProviderError:
                    return "身份验证提供程序返回了错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                case MembershipCreateStatus.UserRejected:
                    return "已取消用户创建请求。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";

                default:
                    return "发生未知错误。请验证您的输入并重试。如果问题仍然存在，请与系统管理员联系。";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' 和 '{1}' 不匹配。";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' 必须至少包含 {1} 个字符。";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion

}
