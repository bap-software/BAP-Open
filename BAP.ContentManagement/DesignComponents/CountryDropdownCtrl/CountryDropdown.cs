// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CountryDropdown.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;

namespace BAP.ContentManagement.DesignComponents.CountryDropdownCtrl
{
    /// <summary>
    /// Class CountryDropdown.
    /// Implements the <see cref="BAP.Common.IContentComponent" />
    /// </summary>
    /// <seealso cref="BAP.Common.IContentComponent" />
    public class CountryDropdown : IContentComponent
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDropdown"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        public CountryDropdown(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        /// <summary>
        /// System name of the component
        /// </summary>
        /// <value>The name.</value>
        public string Name => "CountryDropdown";

        /// <summary>
        /// Description of the component
        /// </summary>
        /// <value>The description.</value>
        public string Description => "CountryDropdown block";

        /// <summary>
        /// Short name shown on design panel
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName => "CountryDropdown";

        /// <summary>
        /// If True, designed will show additonal popup to configure inserted content
        /// </summary>
        /// <value><c>true</c> if this instance has dialog; otherwise, <c>false</c>.</value>
        public bool HasDialog => true;

        /// <summary>
        /// If True, dialog uses CKEditor control for the main input control
        /// </summary>
        /// <value><c>true</c> if this instance has ck editor; otherwise, <c>false</c>.</value>
        public bool HasCKEditor => false;

        /// <summary>
        /// If specified, will be placed before main content on the page
        /// </summary>
        /// <value>The content before.</value>
        public string ContentBefore => "";

        /// <summary>
        /// If specified, will be placed after the main content on the page
        /// </summary>
        /// <value>The content after.</value>
        public string ContentAfter => "";

        /// <summary>
        /// In container tag is specified, this will be added as class to that
        /// </summary>
        /// <value>The main CSS.</value>
        public string MainCss => "";

        /// <summary>
        /// Icon to be used on design panel
        /// </summary>
        /// <value>The icon CSS.</value>
        public string IconCss => "fa fa-film";

        /// <summary>
        /// If specified main content will wrapped with this tag
        /// </summary>
        /// <value>The container tag.</value>
        public string ContainerTag => "";

        /// <summary>
        /// If has dialog, this will shown inside dialog, otherwise will be just placed on the page
        /// </summary>
        /// <value>The content of the dialog.</value>
        public string DialogContent
        {
            get
            {
                var template = new CountryDropdownTemplate();
                return template.TransformText();
            }
        }

        /// <summary>
        /// Input control (can be hidden) used by dialog to store content to be placed on the page
        /// </summary>
        /// <value>The content holder field identifier.</value>
        public string ContentHolderFieldId => "hdnCountryDropdownContent";

        /// <summary>
        /// Gets the content of the java script.
        /// </summary>
        /// <value>The content of the java script.</value>
        public string JavaScriptContent
        {
            get
            {
                var template = new CountryDropdownJavaScript
                {
                    CountryDropdownContent = "<select id=\"<%0%>\" name=\"<%0%>\" class=\"input-medium bfh-countries form-control valid\" data-country=\"UA\" aria-invalid=\"false\"><option value=\"\"></option><option value=\"AF\">Afghanistan</option><option value=\"AL\">Albania</option><option value=\"DZ\">Algeria</option><option value=\"AS\">American Samoa</option><option value=\"AD\">Andorra</option><option value=\"AO\">Angola</option><option value=\"AI\">Anguilla</option><option value=\"AQ\">Antarctica</option><option value=\"AG\">Antigua and Barbuda</option><option value=\"AR\">Argentina</option><option value=\"AM\">Armenia</option><option value=\"AW\">Aruba</option><option value=\"AU\">Australia</option><option value=\"AT\">Austria</option><option value=\"AZ\">Azerbaijan</option><option value=\"BH\">Bahrain</option><option value=\"BD\">Bangladesh</option><option value=\"BB\">Barbados</option><option value=\"BY\">Belarus</option><option value=\"BE\">Belgium</option><option value=\"BZ\">Belize</option><option value=\"BJ\">Benin</option><option value=\"BM\">Bermuda</option><option value=\"BT\">Bhutan</option><option value=\"BO\">Bolivia</option><option value=\"BA\">Bosnia and Herzegovina</option><option value=\"BW\">Botswana</option><option value=\"BV\">Bouvet Island</option><option value=\"BR\">Brazil</option><option value=\"IO\">British Indian Ocean Territory</option><option value=\"VG\">British Virgin Islands</option><option value=\"BN\">Brunei</option><option value=\"BG\">Bulgaria</option><option value=\"BF\">Burkina Faso</option><option value=\"BI\">Burundi</option><option value=\"CI\">Côte d\\'Ivoire</option><option value=\"KH\">Cambodia</option><option value=\"CM\">Cameroon</option><option value=\"CA\">Canada</option><option value=\"CV\">Cape Verde</option><option value=\"KY\">Cayman Islands</option><option value=\"CF\">Central African Republic</option><option value=\"TD\">Chad</option><option value=\"CL\">Chile</option><option value=\"CN\">China</option><option value=\"CX\">Christmas Island</option><option value=\"CC\">Cocos (Keeling) Islands</option><option value=\"CO\">Colombia</option><option value=\"KM\">Comoros</option><option value=\"CG\">Congo</option><option value=\"CK\">Cook Islands</option><option value=\"CR\">Costa Rica</option><option value=\"HR\">Croatia</option><option value=\"CU\">Cuba</option><option value=\"CY\">Cyprus</option><option value=\"CZ\">Czech Republic</option><option value=\"CD\">Democratic Republic of the Congo</option><option value=\"DK\">Denmark</option><option value=\"DJ\">Djibouti</option><option value=\"DM\">Dominica</option><option value=\"DO\">Dominican Republic</option><option value=\"TP\">East Timor</option><option value=\"EC\">Ecuador</option><option value=\"EG\">Egypt</option><option value=\"SV\">El Salvador</option><option value=\"GQ\">Equatorial Guinea</option><option value=\"ER\">Eritrea</option><option value=\"EE\">Estonia</option><option value=\"ET\">Ethiopia</option><option value=\"FO\">Faeroe Islands</option><option value=\"FK\">Falkland Islands</option><option value=\"FJ\">Fiji</option><option value=\"FI\">Finland</option><option value=\"MK\">Former Yugoslav Republic of Macedonia</option><option value=\"FR\">France</option><option value=\"FX\">France, Metropolitan</option><option value=\"GF\">French Guiana</option><option value=\"PF\">French Polynesia</option><option value=\"TF\">French Southern Territories</option><option value=\"GA\">Gabon</option><option value=\"GE\">Georgia</option><option value=\"DE\">Germany</option><option value=\"GH\">Ghana</option><option value=\"GI\">Gibraltar</option><option value=\"GR\">Greece</option><option value=\"GL\">Greenland</option><option value=\"GD\">Grenada</option><option value=\"GP\">Guadeloupe</option><option value=\"GU\">Guam</option><option value=\"GT\">Guatemala</option><option value=\"GN\">Guinea</option><option value=\"GW\">Guinea-Bissau</option><option value=\"GY\">Guyana</option><option value=\"HT\">Haiti</option><option value=\"HM\">Heard and Mc Donald Islands</option><option value=\"HN\">Honduras</option><option value=\"HK\">Hong Kong</option><option value=\"HU\">Hungary</option><option value=\"IS\">Iceland</option><option value=\"IN\">India</option><option value=\"ID\">Indonesia</option><option value=\"IR\">Iran</option><option value=\"IQ\">Iraq</option><option value=\"IE\">Ireland</option><option value=\"IL\">Israel</option><option value=\"IT\">Italy</option><option value=\"JM\">Jamaica</option><option value=\"JP\">Japan</option><option value=\"JO\">Jordan</option><option value=\"KZ\">Kazakhstan</option><option value=\"KE\">Kenya</option><option value=\"KI\">Kiribati</option><option value=\"KW\">Kuwait</option><option value=\"KG\">Kyrgyzstan</option><option value=\"LA\">Laos</option><option value=\"LV\">Latvia</option><option value=\"LB\">Lebanon</option><option value=\"LS\">Lesotho</option><option value=\"LR\">Liberia</option><option value=\"LY\">Libya</option><option value=\"LI\">Liechtenstein</option><option value=\"LT\">Lithuania</option><option value=\"LU\">Luxembourg</option><option value=\"MO\">Macau</option><option value=\"MG\">Madagascar</option><option value=\"MW\">Malawi</option><option value=\"MY\">Malaysia</option><option value=\"MV\">Maldives</option><option value=\"ML\">Mali</option><option value=\"MT\">Malta</option><option value=\"MH\">Marshall Islands</option><option value=\"MQ\">Martinique</option><option value=\"MR\">Mauritania</option><option value=\"MU\">Mauritius</option><option value=\"YT\">Mayotte</option><option value=\"MX\">Mexico</option><option value=\"FM\">Micronesia</option><option value=\"MD\">Moldova</option><option value=\"MC\">Monaco</option><option value=\"MN\">Mongolia</option><option value=\"ME\">Montenegro</option><option value=\"MS\">Montserrat</option><option value=\"MA\">Morocco</option><option value=\"MZ\">Mozambique</option><option value=\"MM\">Myanmar</option><option value=\"NA\">Namibia</option><option value=\"NR\">Nauru</option><option value=\"NP\">Nepal</option><option value=\"NL\">Netherlands</option><option value=\"AN\">Netherlands Antilles</option><option value=\"NC\">New Caledonia</option><option value=\"NZ\">New Zealand</option><option value=\"NI\">Nicaragua</option><option value=\"NE\">Niger</option><option value=\"NG\">Nigeria</option><option value=\"NU\">Niue</option><option value=\"NF\">Norfolk Island</option><option value=\"KP\">North Korea</option><option value=\"MP\">Northern Marianas</option><option value=\"NO\">Norway</option><option value=\"OM\">Oman</option><option value=\"PK\">Pakistan</option><option value=\"PW\">Palau</option><option value=\"PS\">Palestine</option><option value=\"PA\">Panama</option><option value=\"PG\">Papua New Guinea</option><option value=\"PY\">Paraguay</option><option value=\"PE\">Peru</option><option value=\"PH\">Philippines</option><option value=\"PN\">Pitcairn Islands</option><option value=\"PL\">Poland</option><option value=\"PT\">Portugal</option><option value=\"PR\">Puerto Rico</option><option value=\"QA\">Qatar</option><option value=\"RE\">Reunion</option><option value=\"RO\">Romania</option><option value=\"RU\">Russia</option><option value=\"RW\">Rwanda</option><option value=\"ST\">São Tomé and Príncipe</option><option value=\"SH\">Saint Helena</option><option value=\"PM\">St. Pierre and Miquelon</option><option value=\"KN\">Saint Kitts and Nevis</option><option value=\"LC\">Saint Lucia</option><option value=\"VC\">Saint Vincent and the Grenadines</option><option value=\"WS\">Samoa</option><option value=\"SM\">San Marino</option><option value=\"SA\">Saudi Arabia</option><option value=\"SN\">Senegal</option><option value=\"RS\">Serbia</option><option value=\"SC\">Seychelles</option><option value=\"SL\">Sierra Leone</option><option value=\"SG\">Singapore</option><option value=\"SK\">Slovakia</option><option value=\"SI\">Slovenia</option><option value=\"SB\">Solomon Islands</option><option value=\"SO\">Somalia</option><option value=\"ZA\">South Africa</option><option value=\"GS\">South Georgia and the South Sandwich Islands</option><option value=\"KR\">South Korea</option><option value=\"ES\">Spain</option><option value=\"LK\">Sri Lanka</option><option value=\"SD\">Sudan</option><option value=\"SR\">Suriname</option><option value=\"SJ\">Svalbard and Jan Mayen Islands</option><option value=\"SZ\">Swaziland</option><option value=\"SE\">Sweden</option><option value=\"CH\">Switzerland</option><option value=\"SY\">Syria</option><option value=\"TW\">Taiwan</option><option value=\"TJ\">Tajikistan</option><option value=\"TZ\">Tanzania</option><option value=\"TH\">Thailand</option><option value=\"BS\">The Bahamas</option><option value=\"GM\">The Gambia</option><option value=\"TG\">Togo</option><option value=\"TK\">Tokelau</option><option value=\"TO\">Tonga</option><option value=\"TT\">Trinidad and Tobago</option><option value=\"TN\">Tunisia</option><option value=\"TR\">Turkey</option><option value=\"TM\">Turkmenistan</option><option value=\"TC\">Turks and Caicos Islands</option><option value=\"TV\">Tuvalu</option><option value=\"VI\">US Virgin Islands</option><option value=\"UG\">Uganda</option><option value=\"UA\">Ukraine</option><option value=\"AE\">United Arab Emirates</option><option value=\"GB\">United Kingdom</option><option value=\"US\">United States</option><option value=\"UM\">United States Minor Outlying Islands</option><option value=\"UY\">Uruguay</option><option value=\"UZ\">Uzbekistan</option><option value=\"VU\">Vanuatu</option><option value=\"VA\">Vatican City</option><option value=\"VE\">Venezuela</option><option value=\"VN\">Vietnam</option><option value=\"WF\">Wallis and Futuna Islands</option><option value=\"EH\">Western Sahara</option><option value=\"YE\">Yemen</option><option value=\"ZM\">Zambia</option><option value=\"ZW\">Zimbabwe</option></select>"
                };
                return template.TransformText();
            }
        }
    }
}
