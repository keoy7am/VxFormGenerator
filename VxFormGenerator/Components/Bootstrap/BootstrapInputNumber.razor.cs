﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VxFormGenerator.Components.Bootstrap
{
    public class BootstrapInputNumberComponent<TValue> : Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>
    {
        protected string fixClassNames(string inputClassNames)
        {
            //NOTE: Notice the space in front of the class name, this is to ensure we get
            // the suffix to our existing form-control class set from the mark up and NOT
            // half of an invalid tag.  We could use a reg-ex but that might be a bit
            // too slow for the UI renedering to stay smooth.

            // The invalid string shall always be fixed up, as we can never get it until the
            // element has chacked at least once by an attempted submit.
            string result = inputClassNames.Replace(" invalid", " is-invalid");

            // The valid tag is on by default, and to keep consistancy with BS4 we only want
            // it to appear either when our field is modified, or we've tried a submit
            if (inputClassNames.Contains("modified"))
            {
                result = result.Replace(" valid", " is-valid");
            }

            return result;
        }
    }
}
