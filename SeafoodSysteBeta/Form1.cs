using SeafoodSysteBeta.Models;
using SeafoodSysteBeta.Managers;
using SeafoodSysteBeta.Enums;

namespace SeafoodSysteBeta
{
    public partial class Form1 : Form
    {
        SeafoodItem[] menu = new SeafoodItem[50];
        int menuCount = 0;

        OrderManager orderManager = new OrderManager();
        PromoManager promoManager = new PromoManager();
        FileManager fileManager = new FileManager();

        double discount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listViewOrder.View = View.Details;
            listViewOrder.FullRowSelect = true;
            listViewOrder.GridLines = true;


            listViewOrder.Columns.Add("Item", 200);
            listViewOrder.Columns.Add("Quantity", 130);
            listViewOrder.Columns.Add("Price", 100);
            listViewOrder.Columns.Add("Total", 150);

            menu[menuCount++] = new SeafoodItem { Name = "Fish", Price = 50, Category = Category.Fish };
            menu[menuCount++] = new SeafoodItem { Name = "Shrimp", Price = 80, Category = Category.Shrimp };
            menu[menuCount++] = new SeafoodItem { Name = "Crab", Price = 120, Category = Category.Crab };

            menu[menuCount++] = new SeafoodItem { Name = "Lemon Juice", Price = 25, Category = Category.Drink };
            menu[menuCount++] = new SeafoodItem { Name = "Cola", Price = 20, Category = Category.Drink };
            menu[menuCount++] = new SeafoodItem { Name = "Water", Price = 10, Category = Category.Drink };

            menu[menuCount++] = new SeafoodItem { Name = "Fish Fillet", Price = 70, Category = Category.Fish };
            menu[menuCount++] = new SeafoodItem { Name = "Salmon Steak", Price = 150, Category = Category.Fish };

            for (int i = 0; i < menuCount; i++)
            {
                comboItem.Items.Add(menu[i].Name);
            }


        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        void UpdateTotals()
        {
            double subtotal = orderManager.GetSubtotal();
            double tax = orderManager.GetTax(subtotal);
            double total = subtotal + tax - discount;
            lblSubtotal.Text = subtotal.ToString();
            lblTax.Text = tax.ToString();
            lblTotal.Text = total.ToString();
        }


        private void buttonAdditem_click(object sender, EventArgs e)
        {
            //If user does not enter a value(comboItem)
            if (comboItem.SelectedIndex == -1)
            {
                MessageBox.Show("Select item first!");
                return;
            }

            //index comboitem
            int index = comboItem.SelectedIndex;

            //If user does not enter a value(comboQty)
            if (comboQty.SelectedIndex == -1)
            {
                MessageBox.Show("Select quantity!");
                return;
            }
            int qty = int.Parse(comboQty.Text);


            SeafoodItem selectedItem = menu[index];

            OrderItem order = new OrderItem()
            {
                Item = selectedItem,
                Quantity = qty
            };

            orderManager.AddOrder(order);

            ListViewItem row = new ListViewItem(selectedItem.Name);
            row.SubItems.Add(qty.ToString());
            row.SubItems.Add(selectedItem.Price.ToString());
            row.SubItems.Add(order.GetTotal().ToString());

            listViewOrder.Items.Add(row);

            UpdateTotals();
        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewOrder.View = View.Details;
            listViewOrder.FullRowSelect = true;
            listViewOrder.GridLines = true;
        }

        private void buttonApplyCode_click(object sender, EventArgs e)
        {
            double subtotal = orderManager.GetSubtotal();

            discount = promoManager.GetDiscount(txtPromo.Text, subtotal);

            if (discount > 0)
            {
                lblDiscount.Text = discount.ToString();
                MessageBox.Show("Promo Applied ✅");
            }
            else
            {
                lblDiscount.Text = "0";
                MessageBox.Show("Invalid Promo Code ❌");
            }

            UpdateTotals();
        }

        private void buttonGenerateInvoice_Click(object sender, EventArgs e)
        {
            string invoice = "==== INVOICE ====\n";

            for (int i = 0; i < orderManager.Count; i++)
            {
                var o = orderManager.GetOrders()[i];
                invoice += $"{o.Item.Name} x{o.Quantity} = {o.GetTotal()}\n";
            }

            fileManager.SaveInvoice(invoice);

            MessageBox.Show("Invoice Saved!");
        }

        private void buttoncClear_Click(object sender, EventArgs e)
        {
            orderManager.Clear();
            listViewOrder.Items.Clear();

            lblSubtotal.Text = "0";
            lblTax.Text = "0";
            lblTotal.Text = "0";
            lblDiscount.Text = "0";
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < menuCount; i++)
            {
                if (menu[i].Name == comboItem.Text)
                {
                    txtPrice.Text = menu[i].Price.ToString();


                    break;
                }
            }


        }

        private void txtPromo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
