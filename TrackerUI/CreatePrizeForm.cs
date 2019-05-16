using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }
        
        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel();
                model.PlaceName = PlaceNameValue.Text;
                

            }
        }

        private bool ValidateForm()
        {
            bool OutPut = true;

            if (int.TryParse(PlaceNameValue.Text, out int PlaceNumber))
            {
                OutPut = false;
            }
            if (PlaceNumber < 1)
            {
                OutPut = false;
            }
            if (PlaceNameValue.Text.Length == 0)
            {
                OutPut = false;
            }

            bool PrizeAmountValid = decimal.TryParse(PrizeAmoutValue.Text, out decimal PrizeAmount);
            bool PrizePercentageValid = int.TryParse(PrizePercentageValue.Text, out int PrizePercentage);

            if (PrizePercentageValid==false || PrizeAmountValid == false)
            {
                OutPut = false;
            }
            if (PrizeAmount <=0 && PrizePercentage <=0)
            {
                OutPut = false;
            }
            if (PrizePercentage>100 || PrizePercentage<0)
            {
                OutPut = false;
            }

            return OutPut;
        }
    }
}
