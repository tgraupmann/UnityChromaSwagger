/* 
 * Razer REST API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RazerSDK.ChromaPackage.Model
{
    /// <summary>
    /// PostChromaSdkResponse
    /// </summary>
    [DataContract]
    public partial class PostChromaSdkResponse :  IEquatable<PostChromaSdkResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostChromaSdkResponse" /> class.
        /// </summary>
        /// <param name="Sessionid">Sessionid.</param>
        /// <param name="Uri">Uri.</param>
        public PostChromaSdkResponse(string Sessionid = default(string), string Uri = default(string))
        {
            this.Sessionid = Sessionid;
            this.Uri = Uri;
        }
        
        /// <summary>
        /// Gets or Sets Sessionid
        /// </summary>
        [DataMember(Name="sessionid")]
		[JsonProperty(PropertyName = "sessionid")]
        public string Sessionid { get; set; }
        /// <summary>
        /// Gets or Sets Uri
        /// </summary>
        [DataMember(Name="uri")]
		[JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PostChromaSdkResponse {\n");
            sb.Append("  Sessionid: ").Append(Sessionid).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as PostChromaSdkResponse);
        }

        /// <summary>
        /// Returns true if PostChromaSdkResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PostChromaSdkResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PostChromaSdkResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Sessionid == other.Sessionid ||
                    this.Sessionid != null &&
                    this.Sessionid.Equals(other.Sessionid)
                ) && 
                (
                    this.Uri == other.Uri ||
                    this.Uri != null &&
                    this.Uri.Equals(other.Uri)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Sessionid != null)
                    hash = hash * 59 + this.Sessionid.GetHashCode();
                if (this.Uri != null)
                    hash = hash * 59 + this.Uri.GetHashCode();
                return hash;
            }
        }
    }

}
