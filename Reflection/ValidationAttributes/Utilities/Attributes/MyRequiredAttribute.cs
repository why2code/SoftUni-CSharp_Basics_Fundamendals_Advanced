namespace ValidationAttributes.Utilities.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        //Validate if there is no null object provided as obj
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                //Additional Validation
                return !string.IsNullOrEmpty(str);
            }

            return obj != null;
        }
    }
}
