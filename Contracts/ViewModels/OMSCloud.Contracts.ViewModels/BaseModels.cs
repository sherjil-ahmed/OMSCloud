using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public interface IModel
    {
    }

    public class BasicUriModel : BaseModel
    {
        public string UriParams { get; set; }
    }
    public class GenericModel<T> : BaseModel
    {
        public T Value { get; set; }
    }

    public class DictionaryModel<TKey, TSource> : BaseModel
    {
        public TKey Key { get; set; }

        public TSource Value { get; set; }
    }

    public abstract class BaseModel : IModel
    {
        public long RequestedByProfileId { get; set; }        

        #region CommentedCode
        /*
        public Dictionary<string, object> GetDictionaryOfValues()
        {
            Dictionary<string, object> _dict = new Dictionary<string, object>();

            PropertyInfo[] props = this.GetType().GetProperties();  //typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DescriptionAttribute descAttr = attr as DescriptionAttribute;
                    if (descAttr != null)
                    {
                        object propValue = prop.GetValue(this, null);
                        string description = descAttr.Description;
                        if (propValue is bool)
                        {
                            if (((bool)propValue) == true)
                                _dict.Add(description, propValue);
                        }
                        else
                        {
                            _dict.Add(description, propValue);
                        }
                        break;
                    }
                }
            }
            return _dict;
        }*/
        #endregion CommentedCode
    }

    public partial class FilterAttributeInfoModel : BaseModel
    {
        public string Area { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public object[] RouteValues { get; set; }
        public string RouteName { get; set; }
        public string Namespace { get; set; }
        public Type ControllerType { get; set; }
        public string EventName { get; set; }
        public string SecurityKey { get; set; }
    }
    public class ConcurrencyBaseModel : BaseModel
    {
        public virtual long CreatedBy { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual long ModifiedBy { get; set; }

        public virtual DateTime ModifiedOn { get; set; }
    }

    public class AuthenticationModel<T> : IModel
    {
        public long UserId { get; set; }
        public Guid AuthCode { get; set; }
        public T Model { get; set; }
    }

    public class TokenRequestModel : BaseModel
    {
        public TokenRequestModel(string _userName, string _password)
        {
            UserName = _userName;
            Password = _password;
            grant_type = "password";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
    }
    public class TokenResponseModel : BaseModel
    {
		public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public DateTime expiredTime { get; set; }
        public int expires_in { get; set; }
	}

	public class PushNotificationRequestModel : BaseModel
    {

    }
    public class PushNotificationResponseModel : BaseModel
    {

    }
    public class FirebaseNotificationRequestModel : PushNotificationRequestModel
    {
        /*public FirebaseNotificationRequestModel(string _DeviceToken, string _NotificationTitle, string _NotificationBody, string _FirebaseAppKey)
        {
            DeviceToken = _DeviceToken;
            NotificationTitle = _NotificationTitle;
            NotificationBody = _NotificationBody;
            FirebaseAppKey = _FirebaseAppKey;
        }*/
        
        //Same user could have multiple active device tokens
        public List<string> DeviceTokenList { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationBody { get; set; }
        public string FirebaseAppKey { get; set; }
    }
    public class FirebaseNotificationResponseModel : PushNotificationResponseModel
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FirebaseResultMessageId> results { get; set; }
    }

    public class FirebaseResultMessageId {
        public string message_id { get; set; }
    }
}
