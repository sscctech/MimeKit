//
// X509CertificateExtensions.cs
//
// Author: Jeffrey Stedfast <jeff@xamarin.com>
//
// Copyright (c) 2013 Jeffrey Stedfast
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;

using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

namespace MimeKit.Cryptography {
	/// <summary>
	/// X509Certificate extension methods.
	/// </summary>
	public static class X509CertificateExtensions
	{
		/// <summary>
		/// Gets the issuer name info.
		/// </summary>
		/// <returns>The issuer name info.</returns>
		/// <param name="certificate">The certificate.</param>
		/// <param name="identifier">The name identifier.</param>
		public static string GetIssuerNameInfo (this X509Certificate certificate, DerObjectIdentifier identifier)
		{
			// FIXME: this should be fixed to return IList<string>
			var list = certificate.IssuerDN.GetValueList (identifier);
			if (list.Count == 0)
				return null;

			return (string) list[0];
		}

		/// <summary>
		/// Gets the issuer name info.
		/// </summary>
		/// <returns>The issuer name info.</returns>
		/// <param name="certificate">The certificate.</param>
		/// <param name="identifier">The name identifier.</param>
		public static string GetSubjectNameInfo (this X509Certificate certificate, DerObjectIdentifier identifier)
		{
			// FIXME: this should be fixed to return IList<string>
			var list = certificate.SubjectDN.GetValueList (identifier);
			if (list.Count == 0)
				return null;

			return (string) list[0];
		}

		/// <summary>
		/// Gets the common name of the certificate.
		/// </summary>
		/// <returns>The common name.</returns>
		/// <param name="certificate">The certificate.</param>
		public static string GetCommonName (this X509Certificate certificate)
		{
			return certificate.GetSubjectNameInfo (X509Name.CN);
		}

		/// <summary>
		/// Gets the subject name of the certificate.
		/// </summary>
		/// <returns>The subject name.</returns>
		/// <param name="certificate">The certificate.</param>
		public static string GetSubjectName (this X509Certificate certificate)
		{
			return certificate.GetSubjectNameInfo (X509Name.Name);
		}

		/// <summary>
		/// Gets the subject email address of the certificate.
		/// </summary>
		/// <returns>The subject email address.</returns>
		/// <param name="certificate">The certificate.</param>
		public static string GetSubjectEmailAddress (this X509Certificate certificate)
		{
			return certificate.GetSubjectNameInfo (X509Name.EmailAddress);
		}
	}
}
