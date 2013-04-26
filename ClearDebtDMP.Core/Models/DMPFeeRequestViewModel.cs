using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ClearDebtDMP.Core.Utility;

namespace ClearDebtDMP.Core.Models
{

    public class DMPFeeRequestViewModel
    {

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Surname")]
        [StringLength(30, ErrorMessage = "Max 30 characters.")]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Firstname")]
        [StringLength(20, ErrorMessage = "Max 20 characters.")]
        public string CustomerFirstname { get; set; }

        public SelectList CustomerDebtManagementCompanyIdSelectList { get; set; }
        private List<SelectListItem> _customerDebtManagementCompanyIdList { get; set; }

        [DataType(DataType.Text)]
        public string CustomerDebtManagementCompanyIdListSelectedValue
        {
            get
            {
                if (CustomerDebtManagementCompanyId.IsNotNullOrBlank())
                {
                    SelectListItem i = _customerDebtManagementCompanyIdList.Find(x => x.Value == CustomerDebtManagementCompanyId);

                    if (i.IsNotNull())
                        return (i.Text);
                }

                return (String.Empty);
            }
        }

        [Required(AllowEmptyStrings=false, ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [Display(Name = "Debt Management Company")]
        public string CustomerDebtManagementCompanyId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Debt 1 Description")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string Debt1Desctiption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Debt 1 Amount")]
        public decimal Debt1Value { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Debt 2 Description")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string Debt2Desctiption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Debt 2 Amount")]
        public decimal Debt2Value { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Debt 3 Description")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string Debt3Desctiption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Debt 3 Amount")]
        public decimal Debt3Value { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Debt 4 Description")]
        [StringLength(50, ErrorMessage = "MAx 50 characters.")]
        public string Debt4Desctiption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Debt 4 Amount")]
        public decimal Debt4Value { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Debt 5 Description")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string Debt5Desctiption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Debt 5 Amount")]
        public decimal Debt5Value { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Income")]
        public decimal Income { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        [Display(Name = "Expenses")]
        public decimal Expenses { get; set; }

        public DMPFeeRequestViewModel()
        {

            _customerDebtManagementCompanyIdList = new List<SelectListItem>();

            _customerDebtManagementCompanyIdList.Add(new SelectListItem { Selected = false, Text = "Please select", Value = "" });
            _customerDebtManagementCompanyIdList.Add(new SelectListItem { Selected = false, Text = "McDermott and Godfrey", Value = DebtServiceProviderEnumerator.McDermottGodfrey.ToString() });
            _customerDebtManagementCompanyIdList.Add(new SelectListItem { Selected = false, Text = "Money Helper", Value = DebtServiceProviderEnumerator.MoneyHelper.ToString() });
            _customerDebtManagementCompanyIdList.Add(new SelectListItem { Selected = false, Text = "Debt Destructor", Value = DebtServiceProviderEnumerator.DebtDestructor.ToString() });

            CustomerDebtManagementCompanyIdSelectList = new SelectList(_customerDebtManagementCompanyIdList, "Value", "Text", CustomerDebtManagementCompanyIdListSelectedValue);

        }
    }
}
