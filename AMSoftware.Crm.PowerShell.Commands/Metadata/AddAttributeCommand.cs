/*
CRM PowerShell Library
Copyright (C) 2017 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Commands.Models;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Add, "CrmAttribute", HelpUri = HelpUrlConstants.AddAttributeHelpUrl)]
    [OutputType(typeof(AttributeMetadata))]
    public sealed class AddAttributeCommand : CrmOrganizationCmdlet
    {
        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [Alias("Attribute")]
        [ValidateNotNull]
        public AttributeMetadata InputObject { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Guid id = _repository.AddAttribute(Entity, InputObject);
            if (PassThru)
            {
                WriteObject(_repository.GetAttribute(id));
            }
        }
    }

    [OutputType(typeof(AttributeMetadata))]
    public abstract class AddAttributeCommandBase : CrmOrganizationCmdlet
    {
        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName", "LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool CanModifyAdditionalSettings { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsAuditEnabled { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsCustomizable { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsRenameable { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsSecured { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsValidForAdvancedFind { get; set; }

        [Parameter]
        [PSDefaultValue(Value = CrmRequiredLevel.Required)]
        public CrmRequiredLevel Required { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string SchemaName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string ExternalName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsGlobalFilterEnabled { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool IsSortableEnabled { get; set; }

        [Parameter]
        public SwitchParameter IsDataSourceSecret { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected void WriteAttribute(AttributeMetadata attribute)
        {
            attribute.LogicalName = Name;
            attribute.SchemaName = !string.IsNullOrWhiteSpace(SchemaName) ? SchemaName : Name;
            attribute.DisplayName = new Label(DisplayName, CrmContext.Session.Language);
            attribute.Description = new Label(Description ?? string.Empty, CrmContext.Session.Language);

            AttributeRequiredLevel requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (Required == CrmRequiredLevel.Required) requiredLevel = AttributeRequiredLevel.ApplicationRequired;
            if (Required == CrmRequiredLevel.Recommended) requiredLevel = AttributeRequiredLevel.Recommended;
            if (Required == CrmRequiredLevel.Optional) requiredLevel = AttributeRequiredLevel.None;
            attribute.RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanModifyAdditionalSettings))) 
                attribute.CanModifyAdditionalSettings = new BooleanManagedProperty(CanModifyAdditionalSettings);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsAuditEnabled))) 
                attribute.IsAuditEnabled = new BooleanManagedProperty(IsAuditEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsCustomizable))) 
                attribute.IsCustomizable = new BooleanManagedProperty(IsCustomizable);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsRenameable))) 
                attribute.IsRenameable = new BooleanManagedProperty(IsRenameable);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsSecured))) 
                attribute.IsSecured = IsSecured;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsValidForAdvancedFind))) 
                attribute.IsValidForAdvancedFind = new BooleanManagedProperty(IsValidForAdvancedFind);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsGlobalFilterEnabled))) 
                attribute.IsGlobalFilterEnabled = new BooleanManagedProperty(IsGlobalFilterEnabled);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsSortableEnabled))) 
                attribute.IsSortableEnabled = new BooleanManagedProperty(IsSortableEnabled);

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(IsDataSourceSecret))) 
                attribute.IsDataSourceSecret = IsDataSourceSecret.ToBool();

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(ExternalName)) && !string.IsNullOrWhiteSpace(ExternalName))
                attribute.ExternalName = ExternalName;

            Guid id = _repository.AddAttribute(Entity, attribute);
            if (PassThru)
            {
                WriteObject(_repository.GetAttribute(id));
            }
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmStringAttribute", HelpUri = HelpUrlConstants.AddStringAttributeHelpUrl)]
    [OutputType(typeof(StringAttributeMetadata))]
    public sealed class AddStringAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmStringAttributeFormat.Text)]
        public CrmStringAttributeFormat Format { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateRange(StringAttributeMetadata.MinSupportedLength, StringAttributeMetadata.MaxSupportedLength)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 100)]
        public int Length { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            StringAttributeMetadata attribute = new StringAttributeMetadata();

            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            switch (Format)
            {
                case CrmStringAttributeFormat.Email:
                    attribute.FormatName = StringFormatName.Email;
                    break;
                case CrmStringAttributeFormat.Phone:
                    attribute.FormatName = StringFormatName.Phone;
                    break;
                case CrmStringAttributeFormat.PhoneticGuide:
                    attribute.FormatName = StringFormatName.PhoneticGuide;
                    break;
                case CrmStringAttributeFormat.TextArea:
                    attribute.FormatName = StringFormatName.TextArea;
                    break;
                case CrmStringAttributeFormat.TickerSymbol:
                    attribute.FormatName = StringFormatName.TickerSymbol;
                    break;
                case CrmStringAttributeFormat.Url:
                    attribute.FormatName = StringFormatName.Url;
                    break;
                case CrmStringAttributeFormat.VersionNumber:
                    attribute.FormatName = StringFormatName.VersionNumber;
                    break;
                default:
                    attribute.FormatName = StringFormatName.Text;
                    break;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Length))) 
                attribute.MaxLength = Length;
            else 
                attribute.MaxLength = 100;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmMemoAttribute", HelpUri = HelpUrlConstants.AddMemoAttributeHelpUrl)]
    [OutputType(typeof(MemoAttributeMetadata))]
    public sealed class AddMemoAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateRange(MemoAttributeMetadata.MinSupportedLength, MemoAttributeMetadata.MaxSupportedLength)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 100)]
        public int Length { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            MemoAttributeMetadata attribute = new MemoAttributeMetadata();
            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Length)))
                attribute.MaxLength = Length;
            else
                attribute.MaxLength = 100;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmIntegerAttribute", HelpUri = HelpUrlConstants.AddIntegerAttributeHelpUrl)]
    [OutputType(typeof(IntegerAttributeMetadata))]
    public sealed class AddIntegerAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmIntegerAttributeFormat.None)]
        public CrmIntegerAttributeFormat Format { get; set; }

        [Parameter]
        [ValidateRange(int.MinValue, int.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = int.MaxValue)]
        public int MaxValue { get; set; }

        [Parameter]
        [ValidateRange(int.MinValue, int.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = int.MinValue)]
        public int MinValue { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            IntegerAttributeMetadata attribute = new IntegerAttributeMetadata();

            switch (Format)
            {
                case CrmIntegerAttributeFormat.Duration:
                    attribute.Format = IntegerFormat.Duration;
                    break;
                case CrmIntegerAttributeFormat.Language:
                    attribute.Format = IntegerFormat.Language;
                    break;
                case CrmIntegerAttributeFormat.Locale:
                    attribute.Format = IntegerFormat.Locale;
                    break;
                case CrmIntegerAttributeFormat.TimeZone:
                    attribute.Format = IntegerFormat.TimeZone;
                    break;
                default:
                    attribute.Format = IntegerFormat.None;
                    break;
            }
           
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MaxValue))) 
                attribute.MaxValue = MaxValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MinValue)))
                attribute.MinValue = MinValue;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmBigIntAttribute", HelpUri = HelpUrlConstants.AddBigIntAttributeHelpUrl)]
    [OutputType(typeof(BigIntAttributeMetadata))]
    public sealed class AddBigIntAttributeCommand : AddAttributeCommandBase
    {
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            BigIntAttributeMetadata attribute = new BigIntAttributeMetadata();

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmDecimalAttribute", HelpUri = HelpUrlConstants.AddDecimalAttributeHelpUrl)]
    [OutputType(typeof(DecimalAttributeMetadata))]
    public sealed class AddDecimalAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateNotNull]
        public decimal MaxValue { get; set; }

        [Parameter]
        [ValidateNotNull]
        public decimal MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int Precision { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DecimalAttributeMetadata attribute = new DecimalAttributeMetadata();

            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MaxValue))) 
                attribute.MaxValue = MaxValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MinValue))) 
                attribute.MinValue = MinValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Precision)))
                attribute.Precision = Precision;
            else
                attribute.Precision = 2;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmDoubleAttribute", HelpUri = HelpUrlConstants.AddDoubleAttributeHelpUrl)]
    [OutputType(typeof(DoubleAttributeMetadata))]
    public sealed class AddDoubleAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = double.MaxValue)]
        public double MaxValue { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = double.MinValue)]
        public double MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int Precision { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DoubleAttributeMetadata attribute = new DoubleAttributeMetadata();

            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MaxValue))) 
                attribute.MaxValue = MaxValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MinValue))) 
                attribute.MinValue = MinValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Precision)))
                attribute.Precision = Precision;
            else
                attribute.Precision = 2;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmMoneyAttribute", HelpUri = HelpUrlConstants.AddMoneyAttributeHelpUrl)]
    [OutputType(typeof(MoneyAttributeMetadata))]
    public sealed class AddMoneyAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 1000000000)]
        public double MaxValue { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 0)]
        public double MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int Precision { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmMoneyPrecisionType.Attribute)]
        public CrmMoneyPrecisionType PrecisionType { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            MoneyAttributeMetadata attribute = new MoneyAttributeMetadata();
            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MaxValue))) 
                attribute.MaxValue = MaxValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(MinValue))) 
                attribute.MinValue = MinValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(Precision)))
                attribute.Precision = Precision;
            else 
                attribute.Precision = 2;

            if (PrecisionType == CrmMoneyPrecisionType.OrganizationPricing) attribute.PrecisionSource = 1;
            if (PrecisionType == CrmMoneyPrecisionType.Currency) attribute.PrecisionSource = 2;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmDateTimeAttribute", HelpUri = HelpUrlConstants.AddDateTimeAttributeHelpUrl)]
    [OutputType(typeof(DateTimeAttributeMetadata))]
    public sealed class AddDateTimeAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmDateTimeAttributeFormat.DateOnly)]
        public CrmDateTimeAttributeFormat Format { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType ImeType { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool CanChangeBehavior { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmDateTimeBehavior.UserSettings)]
        public CrmDateTimeBehavior Behavior { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DateTimeAttributeMetadata attribute = new DateTimeAttributeMetadata();
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(CanChangeBehavior))) 
                attribute.CanChangeDateTimeBehavior = new BooleanManagedProperty(CanChangeBehavior);

            switch (ImeType)
            {
                case CrmImeType.Active:
                    attribute.ImeMode = ImeMode.Active;
                    break;
                case CrmImeType.Disabled:
                    attribute.ImeMode = ImeMode.Disabled;
                    break;
                case CrmImeType.Inactive:
                    attribute.ImeMode = ImeMode.Inactive;
                    break;
                default:
                    attribute.ImeMode = ImeMode.Auto;
                    break;
            }

            attribute.Format = DateTimeFormat.DateAndTime;
            if (Format == CrmDateTimeAttributeFormat.DateOnly) attribute.Format = DateTimeFormat.DateOnly;

            attribute.DateTimeBehavior = DateTimeBehavior.UserLocal;
            if (Behavior == CrmDateTimeBehavior.DateOnly) attribute.DateTimeBehavior = DateTimeBehavior.DateOnly;
            if (Behavior == CrmDateTimeBehavior.TimeZoneIndependent) attribute.DateTimeBehavior = DateTimeBehavior.TimeZoneIndependent;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmBooleanAttribute", HelpUri = HelpUrlConstants.AddBooleanAttributeHelpUrl)]
    [OutputType(typeof(BooleanAttributeMetadata))]
    public sealed class AddBooleanAttributeCommand : AddAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        public bool DefaultValue { get; set; }

        [Parameter]
        [ValidateNotNull]
        public PSOptionSetValue TrueValue { get; set; }

        [Parameter]
        [ValidateNotNull]
        public PSOptionSetValue FalseValue { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            BooleanAttributeMetadata attribute = new BooleanAttributeMetadata()
            {
                OptionSet = new BooleanOptionSetMetadata()
            };

            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DefaultValue))) 
                attribute.DefaultValue = DefaultValue;
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(TrueValue))) 
                attribute.OptionSet.TrueOption = new OptionMetadata(new Label(TrueValue.DisplayName, CrmContext.Session.Language), TrueValue.Value);
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(FalseValue))) 
                attribute.OptionSet.FalseOption = new OptionMetadata(new Label(FalseValue.DisplayName, CrmContext.Session.Language), FalseValue.Value);

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmOptionSetAttribute", HelpUri = HelpUrlConstants.AddOptionSetAttributeHelpUrl, DefaultParameterSetName = AddOptionSetNewParameterSet)]
    [OutputType(typeof(PicklistAttributeMetadata))]
    public sealed class AddOptionSetAttributeCommand : AddAttributeCommandBase
    {
        private const string AddOptionSetExistingParameterSet = "AddOptionSetExisting";
        private const string AddOptionSetNewParameterSet = "AddOptionSetNew";

        [Parameter(ParameterSetName = AddOptionSetNewParameterSet)]
        [ValidateNotNull]
        public int DefaultValue { get; set; }

        [Parameter(ParameterSetName = AddOptionSetNewParameterSet)]
        [ValidateNotNull]
        public PSOptionSetValue[] Values { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddOptionSetExistingParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OptionSet { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PicklistAttributeMetadata attribute = new PicklistAttributeMetadata();
            if (this.MyInvocation.BoundParameters.ContainsKey(nameof(DefaultValue))) 
                attribute.DefaultFormValue = DefaultValue;

            switch (this.ParameterSetName)
            {
                case AddOptionSetNewParameterSet:
                    attribute.OptionSet = new OptionSetMetadata()
                    {
                        IsGlobal = false
                    };
                    foreach (PSOptionSetValue item in Values)
                    {
                        OptionMetadata option = new OptionMetadata(new Label(item.DisplayName, CrmContext.Session.Language), item.Value);
                        attribute.OptionSet.Options.Add(option);
                    }
                    break;
                case AddOptionSetExistingParameterSet:
                    MetadataRepository repository = new MetadataRepository();
                    if (repository.GetOptionSet(OptionSet) is OptionSetMetadata optionset && optionset.IsGlobal.GetValueOrDefault())
                    {
                        attribute.OptionSet = optionset;
                        attribute.OptionSet.Options.Clear();
                    }
                    else
                    {
                        throw new Exception($"No global optionset found with name: {OptionSet}");
                    }
                    break;
                default:
                    break;
            }

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Add, "CrmImageAttribute", HelpUri = HelpUrlConstants.AddImageAttributeHelpUrl)]
    [OutputType(typeof(ImageAttributeMetadata))]
    public sealed class AddImageAttributeCommand : AddAttributeCommandBase
    {
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ImageAttributeMetadata attribute = new ImageAttributeMetadata();
            WriteAttribute(attribute);
        }
    }
}
