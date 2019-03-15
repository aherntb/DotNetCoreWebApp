using System;

namespace DotNetCoreWebApp.BusinessRules.ClaimBusinessRules
{
    /*
     *Some basic rules to exercise the composite of business rule specifications 
     *
     */
    public class RuleOne : CompositeSpecification<Claim>
    {
        public override bool IsSatisfiedBy(Claim candidate)
        {
            return (DateTime.Now.Year - candidate.PatientBirthDate.Year) > 21;
        }
    }

    public class RuleTwo : CompositeSpecification<Claim>
    {
        public override bool IsSatisfiedBy(Claim candidate)
        {
            return string.Equals("Ahern", candidate.PatientLastName, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    public class RuleThree : CompositeSpecification<Claim>
    {
        public override bool IsSatisfiedBy(Claim candidate)
        {
            return string.Equals("Thomas", candidate.PatientFirstName, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
