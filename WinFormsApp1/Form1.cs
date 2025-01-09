using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        public double Item(TextBox item1, TextBox itemamount1, TextBox item2, TextBox itemamount2, CheckBox item_check1, CheckBox item_check2)
        {


            string inCofprice = item1.Text;
            string inamount = itemamount1.Text;
            string inTeaprice = item2.Text;
            string inTeaAmount = itemamount2.Text;

            int Cofprice = 0;
            int amount = 0;
            int teaAmount = 0;
            int teaprice = 0;

            try
            {
                if (item_check1.Checked)
                    Cofprice = int.Parse(inCofprice);
                amount = int.Parse(inamount);

            }
            catch (FormatException) { }
            try
            {
                if (item_check2.Checked)
                    teaprice = int.Parse(inTeaprice);
                teaAmount = int.Parse(inTeaAmount);
            }
            catch (FormatException)
            {

            }
            double sum1 = Cofprice * amount;
            double sum2 = teaprice * teaAmount;
            double sum = sum1 + sum2;
            return sum;
        }
        public double DiscountAll(double Drink, double Food)
        {
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisAll.Text);
                    double all = Drink + Food;
                    all = all - (all * discountvalue / 100);
                    sum1 += all;

                }
                catch (FormatException)
                {
                    double all = Drink + Food;
                    sum1 += all;
                }


            }
            return sum1;
        }
        public double DiscountDrink(double Drink)
        {
            if (Discount_Drink.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisDrink.Text);
                    Drink = Drink - (Drink * discountvalue / 100);

                }
                catch (FormatException)
                { Drink = Drink - (Drink * discountvalue / 100); }

            }
            return Drink;
        }
        public double DiscountFood(double Food)
        {
            if (Discount_Food.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = int.Parse(Tb_DisFood.Text);
                    Food = Food - (Food * discountvalue / 100);

                }
                catch (FormatException)
                {
                    Food = Food - (Food * discountvalue / 100);

                }
            }

            return Food;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Cof_check.Checked == false)
            {
                CoffeePrice.Enabled = false;
                HowManyCoffee.Enabled = false;
            }
            if (Cof_check.Checked == true)
            {
                CoffeePrice.Enabled = true;
                HowManyCoffee.Enabled = true;
            }

        }

        private void CoffeePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Drink = Item(CoffeePrice, HowManyCoffee, TeaPrice, HowManyTea, Cof_check, Tea_check);
            double Food = Item(Pizza_Price, Pizza_Amount, Burger_Price, Burger_Amount, Pizza_Check, Burger_Check);
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                sum1 += DiscountAll(Drink, Food);

            }
            else if (Discount_Drink.Checked)
            {
                Drink = DiscountDrink(Drink);
                sum1 += Drink + Food;

            }

            else if (Discount_Food.Checked)
            {
                Food = DiscountFood(Food);
                sum1 += Food + Drink;



            }
            else
            {
                sum1 += Drink + Food;
            }
            Total.Text = Math.Floor(sum1).ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int total = 0;
            int cash = 0;
            try
            {

                cash = int.Parse(Cash.Text);

            }
            catch (FormatException) { }

            try
            {
                total = int.Parse(Total.Text);
            }
            catch (FormatException) { }
            int change = cash - total;
            Change.Text = change.ToString();

            int OneT = 0;
            int FiveH = 0;
            int oneH = 0;
            int fifty = 0;
            int twenty = 0;
            int ten = 0;
            int five = 0;
            int one = 0;
            while (change > 0)
            {
                if (change >= 1000)
                {
                    change -= 1000;
                    OneT++;
                }
                else if (change >= 500)
                {
                    change -= 500;
                    FiveH++;
                }
                else if (change >= 100)
                {
                    change -= 100;
                    oneH++;
                }
                else if (change >= 50)
                {
                    change -= 50;
                    fifty++;
                }
                else if (change >= 20)
                {
                    change -= 20;
                    twenty++;
                }
                else if (change >= 10)
                {
                    change -= 10;
                    ten++;
                }
                else if (change >= 5)
                {
                    change -= 5;
                    five++;
                }
                else if (change >= 1)
                {
                    change -= 1;
                    one++;
                }
            }
            OneThousand.Text = OneT.ToString();
            FiveHundred.Text = FiveH.ToString();
            OneHundred.Text = oneH.ToString();
            Fifty.Text = fifty.ToString();
            Twenty.Text = twenty.ToString();
            Ten.Text = ten.ToString();
            Five.Text = five.ToString();
            One.Text = one.ToString();

        }

        private void Tea_check_CheckedChanged(object sender, EventArgs e)
        {
            if (Tea_check.Checked == true)
            {
                TeaPrice.Enabled = true;
                HowManyTea.Enabled = true;
            }
            if (Tea_check.Checked == false)
            {
                TeaPrice.Enabled = false;
                HowManyTea.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Drink.Checked == true)
            {
                Discount_All.Checked = false;
                Discount_Food.Checked = false;
                Tb_DisDrink.Enabled = true;
            }
            else
            {
                Tb_DisDrink.Enabled = false;
            }
        }

        private void Discount_Food_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Food.Checked)
            {
                Discount_All.Checked = false;
                Discount_Drink.Checked = false;
                Tb_DisFood.Enabled = true;
            }
            else
            {
                Tb_DisFood.Enabled = false;
            }
        }

        private void Discount_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_All.Checked)
            {
                Discount_Drink.Checked = false;
                Discount_Food.Checked = false;
                Discount_All.Checked = true;
                Tb_DisAll.Enabled = true;
            }
            else
            {
                Tb_DisAll.Enabled = false;
            }

        }


        private void Pizza_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Pizza_Check.Checked)
            {
                Pizza_Price.Enabled = true;
                Pizza_Amount.Enabled = true;
            }
            else
            {
                Pizza_Price.Enabled = false;
                Pizza_Amount.Enabled = false;
            }

        }

        private void Burger_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Burger_Check.Checked == true)
            {
                Burger_Price.Enabled = true;
                Burger_Amount.Enabled = true;
            }
            else
            {
                Burger_Price.Enabled = false;
                Burger_Amount.Enabled = false;
            }

        }

        private void Tb_DisDrink_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

