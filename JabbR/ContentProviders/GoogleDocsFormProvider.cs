﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace JabbR.ContentProviders
{
    public class GoogleDocsFormProvider : EmbedContentProvider
    {
        public override string MediaFormatString
        {
            get
            {
                return @"<iframe src='https://docs.google.com/spreadsheet/embeddedform?formkey={0}' width='500' height='500' frameborder='0' marginheight='0' marginwidth='0'>Loading...</iframe>";
            }
        }

        public override IEnumerable<string> Domains
        {
            get
            {
                yield return "https://docs.google.com";
                yield return "http://docs.google.com";
            }
        }

        protected override IEnumerable<object> ExtractParameters(Uri responseUri)
        {
            var queryString = HttpUtility.ParseQueryString(responseUri.Query);
            string formId = queryString["formkey"];
            if (!String.IsNullOrEmpty(formId))
            {
                yield return formId;
            }
        }
    }
}