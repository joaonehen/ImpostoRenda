using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command.CustomValidators
{
    public static class MyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> IsGuid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new GuidValidator());
        }

        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator());
        }
    }
}
