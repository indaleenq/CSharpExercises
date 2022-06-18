using Common;
using System;

namespace ApplicationLayer
{
    public class DataValidator
    {
        public static bool ValidateData(string data, EnumDataName dataType)
        {
            bool isValid = false;

            switch (dataType)
            {
                case EnumDataName.StudentNumber:
                    isValid = ValidateStudentNumber(data);
                    break;
                case EnumDataName.SubjectCode:
                    isValid = ValidateSubjectCode(data);
                    break;
                default:
                    break;
            }

            return isValid;
        }

        static internal bool ValidateStudentNumber(string data)
        {
            return data.Length == 15 && data.StartsWith("20") && data.EndsWith("BN-0");
        }

        static internal bool ValidateSubjectCode(string data)
        {
            return data.Length != 0 && data.StartsWith("INTE") || data.StartsWith("COMP");
        }

    }
}
