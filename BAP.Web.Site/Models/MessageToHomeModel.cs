namespace BAP.Web.Models
{
	public class MessageToHomeModel
	{
		public string RecaptchaResponse { get; set; }
		public string FromName { get; set; }
		public string FromEmail { get; set; }
		public string FromMsg { get; set; }
	}
}