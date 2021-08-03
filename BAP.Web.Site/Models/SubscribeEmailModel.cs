using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAP.Web.Models
{
	public class SubscribeEmailModel
	{
		public string RecaptchaResponse { get; set; }
		public string Email { get; set; }
	}
}