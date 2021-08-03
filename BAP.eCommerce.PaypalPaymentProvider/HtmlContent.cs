// ***********************************************************************
// Assembly         : BAP.eCommerce.PaypalPaymentProvider
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-08-2020
// ***********************************************************************
// <copyright file="HtmlContent.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.PaypalPaymentProvider
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Class to produce the template output
    /// </summary>

#line 1 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class HtmlContent : HtmlContentBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string TransformText()
        {
            this.Write("\r\n\r\n<div class=\'");
            
            #line 8 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.ContainerCss));
            
            #line default
            #line hidden
            this.Write("\'>\r\n\t<div id=\"paypal-button-container\"></div>\r\n\r\n    <script>\r\n        paypal.But" +
                    "ton.render({\r\n\r\n            env: \'");
            
            #line 14 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.Environment));
            
            #line default
            #line hidden
            this.Write("\', // sandbox | production\r\n            \r\n            client: {\r\n                " +
                    "sandbox:    \'");
            
            #line 17 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.SandboxClientId));
            
            #line default
            #line hidden
            this.Write("\',\r\n                production: \'");
            
            #line 18 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.ProductionClientId));
            
            #line default
            #line hidden
            this.Write(@"'
            },

            // Show the buyer a 'Pay Now' button in the checkout flow
            commit: true,

            // payment() is called when the button is clicked
            payment: function(data, actions) {

                // Make a call to the REST api to create the payment
                return actions.payment.create({
                    payment: {
                        transactions: [
                            {
                                amount: { total: '");
            
            #line 32 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.OrderTotal));
            
            #line default
            #line hidden
            this.Write("\', currency: \'");
            
            #line 32 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.OrderCurrency));
            
            #line default
            #line hidden
            this.Write(@"' }
                            }
                        ]
                    }
                });
            },

            // onAuthorize() is called when the buyer approves the payment
            onAuthorize: function(data, actions) {				
                // Make a call to the REST api to execute the payment
                return actions.payment.execute().then(function(payment) {      
					var callbackUrl = '");
            
            #line 43 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.CallBackUrl));
            
            #line default
            #line hidden
            this.Write("?orderid=");
            
            #line 43 "D:\Projects\BAP\Platform\Solution\BAP.eCommerce.PaypalPaymentProvider\HtmlContent.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Data.OrderId));
            
            #line default
            #line hidden
            this.Write(@"';
					if(typeof payment.id !== ""undefined"" )
					{
						callbackUrl += '&refid=' + payment.id;
					}
					if(typeof payment.create_time !== ""undefined"" )
					{
						callbackUrl += '&createtime=' + payment.create_time;
					}
					if(typeof payment.update_time !== ""undefined"" )
					{
						callbackUrl += '&updatetime=' + payment.update_time;
					}
					if(typeof payment.state !== ""undefined"" )
					{
						callbackUrl += '&state=' + payment.state;
					}
					if(typeof payment.intent !== ""undefined"" )
					{
						callbackUrl += '&intent=' + payment.intent;
					}
					if(typeof payment.note_to_payer !== ""undefined"" )
					{
						callbackUrl += '&notes=' + payment.note_to_payer;
					}
					if(typeof payment.failure_reason !== ""undefined"" )
					{
						callbackUrl += '&failurereason=' + payment.failure_reason;
					}

					window.location = callbackUrl;
                });
            }

        }, '#paypal-button-container');

    </script>
</div>");
            return this.GenerationEnvironment.ToString();
        }
    }

#line default
#line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class HtmlContentBase
    {
        #region Fields
        /// <summary>
        /// The generation environment field
        /// </summary>
        private global::System.Text.StringBuilder generationEnvironmentField;
        /// <summary>
        /// The errors field
        /// </summary>
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        /// <summary>
        /// The indent lengths field
        /// </summary>
        private global::System.Collections.Generic.List<int> indentLengthsField;
        /// <summary>
        /// The current indent field
        /// </summary>
        private string currentIndentField = "";
        /// <summary>
        /// The ends with newline
        /// </summary>
        private bool endsWithNewline;
        /// <summary>
        /// The session field
        /// </summary>
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        /// <value>The generation environment.</value>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        /// <value>The errors.</value>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        /// <value>The indent lengths.</value>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        /// <value>The current indent.</value>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        /// <value>The session.</value>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        /// <param name="textToAppend">The text to append.</param>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        /// <param name="textToAppend">The text to append.</param>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        /// <param name="indent">The indent.</param>
        /// <exception cref="System.ArgumentNullException">indent</exception>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        /// <returns>System.String.</returns>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            /// <summary>
            /// The format provider field
            /// </summary>
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            /// <value>The format provider.</value>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            /// <param name="objectToConvert">The object to convert.</param>
            /// <returns>System.String.</returns>
            /// <exception cref="System.ArgumentNullException">objectToConvert</exception>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        /// <summary>
        /// To string helper field
        /// </summary>
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        /// <value>To string helper.</value>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
