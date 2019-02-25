﻿namespace FailToBan.Core
{
    public class Jail : Service
    {
        private readonly Service jailSetting;

        public Jail(ISetting confSetting, ISetting localSetting, string name, Service jailSetting) : base(confSetting, localSetting, name)
        {
            this.jailSetting = jailSetting;
        }

        public override string GetRule(string section, RuleType type)
        {
            var value = localSetting.GetSection(section)?.Get(type) ?? 
                        confSetting.GetSection(section)?.Get(type) ?? 
                        jailSetting.GetRule(section, type) ??
                        jailSetting.GetRule("DEFAULT", type);

            return value;
        }

    }
}