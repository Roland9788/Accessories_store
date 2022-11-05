namespace Прога_для_DNS
{
    public partial class Form1 : Form
    {
        int sizefont = 28;
        double price = 0;
        Products _products = new Products();
        ListBox listProducts = new ListBox();
        
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            listSales.HorizontalScrollbar = true;
            this.Text = "Продажи";
        }

        private void label2_Click(object sender, EventArgs e){ }

        private void lbprice_TextChanged(object sender, EventArgs e)
        {
            if (lbprice.Size.Width >= this.Size.Width - 20)
            {
                lbprice.Font = new Font("Default", sizefont--);
            }
        }

        private void InitForm2(ref Form f)
        {
            f.MaximizeBox = false;
            f.Size = this.Size;
            f.Text = "Окно редактирования";
            TextBox txbname = new TextBox();
            TextBox txbpar = new TextBox();
            TextBox txbDescr = new TextBox();
            TextBox txbPrice = new TextBox();
            Button addbut = new Button();
            Button editbut = new Button();
            bool flag = true;
            listProducts.Size = new Size(350, this.Height-50);
            listProducts.Location = new Point(this.Width / 2, 0);
            listProducts.HorizontalScrollbar = true;
            listProducts.SelectedIndexChanged += ListProducts_SelectedIndexChanged;
            void ListProducts_SelectedIndexChanged(object? sender, EventArgs e)
            {
                txbname.Text = _products.GetProducts()[listProducts.SelectedIndex].Getname();
                txbpar.Text = _products.GetProducts()[listProducts.SelectedIndex].Getparam();
                txbDescr.Text = _products.GetProducts()[listProducts.SelectedIndex].Getdis();
                txbPrice.Text = _products.GetProducts()[listProducts.SelectedIndex].Getprice();
            }

            f.Controls.Add(listProducts);


            txbname.Text = "Название товара";
            txbname.ForeColor = Color.Gray;
            txbname.Enter += Txbname_Enter;
            void Txbname_Enter(object? sender, EventArgs e)
            {
                txbname.BackColor = Color.White;
                txbname.Text = null;
                txbname.ForeColor = Color.Black;
            }
            txbname.Leave += Txbname_Leave;
            void Txbname_Leave(object? sender, EventArgs e)
            {
                if (txbname.Text == "")
                {
                    txbname.Text = "Название товара";
                    txbname.ForeColor = Color.Gray;
                }
            }
            txbname.Size = new Size(350,100);
            txbname.Location = new Point(10, this.Height / 2 - 200);
            f.Controls.Add(txbname);


            txbpar.Text = "Характеристики";
            txbpar.ForeColor = Color.Gray;
            txbpar.Enter += Txbpar_Enter;
            void Txbpar_Enter(object? sender, EventArgs e)
            {
                txbpar.BackColor = Color.White;
                txbpar.Text = null;
                txbpar.ForeColor = Color.Black;
            }
            txbpar.Leave += Txbpar_Leave;
            void Txbpar_Leave(object? sender, EventArgs e)
            {
                if (txbpar.Text == "")
                {
                    txbpar.Text = "Характеристики";
                    txbpar.ForeColor = Color.Gray;
                }
            }
            txbpar.Size = new Size(350, 100);
            txbpar.Location = new Point(10, this.Height / 2 - 150);
            f.Controls.Add(txbpar);


            txbDescr.Text = "Описание";
            txbDescr.ForeColor = Color.Gray;
            txbDescr.Enter += TxbDescr_Enter;
            void TxbDescr_Enter(object? sender, EventArgs e)
            {
                txbDescr.BackColor = Color.White;
                txbDescr.Text = null;
                txbDescr.ForeColor = Color.Black;
            }
            txbDescr.Leave += TxbDescr_Leave;
            void TxbDescr_Leave(object? sender, EventArgs e)
            {
                if (txbDescr.Text == "")
                {
                    txbDescr.Text = "Описание";
                    txbDescr.ForeColor = Color.Gray;
                }
            }
            txbDescr.Size = new Size(350, 100);
            txbDescr.Location = new Point(10, this.Height / 2 - 100);
            f.Controls.Add(txbDescr);


            txbPrice.Text = "Цена";
            txbPrice.ForeColor = Color.Gray;
            txbPrice.Enter += TxbPrice_Enter;
            void TxbPrice_Enter(object? sender, EventArgs e)
            {
                txbPrice.BackColor = Color.White;
                txbPrice.Text = null;
                txbPrice.ForeColor = Color.Black;
            }
            txbPrice.Leave += TxbPrice_Leave;
            void TxbPrice_Leave(object? sender, EventArgs e)
            {
                if (txbPrice.Text == "")
                {
                    txbPrice.Text = "Цена";
                    txbPrice.ForeColor = Color.Gray;
                }
            }
            txbPrice.Size = new Size(350, 100);
            txbPrice.Location = new Point(10, this.Height / 2 - 50);
            f.Controls.Add(txbPrice);


            addbut.Text = "Добавить";
            addbut.Location = new Point(10, this.Height / 2);
            addbut.Size = new Size(80,40);
            addbut.Click += Addbut_Click;
            void Addbut_Click(object? sender, EventArgs e)
            {
                flag = true;
                if (txbname.Text[0] == ' ' || txbname.Text == "Название товара") 
                {
                    txbname.BackColor = Color.Red;
                    flag = false;
                }
                else
                {
                    txbname.BackColor = Color.White;
                }

                if (txbpar.Text[0] == ' ' || txbpar.Text == "Характеристики")
                {
                    txbpar.BackColor = Color.Red;
                    flag = false;
                }
                else
                {
                    txbpar.BackColor = Color.White;
                }

                if (txbDescr.Text[0] == ' ' || txbDescr.Text == "Описание")
                {
                    txbDescr.BackColor = Color.Red;
                    flag = false;
                }
                else
                {
                    txbDescr.BackColor = Color.White;
                }

                if (int.TryParse(txbPrice.Text, out var parsedNumber) == false)
                {
                    txbPrice.BackColor = Color.Red;
                    flag = false;
                }
                else
                {
                    txbPrice.BackColor = Color.White;
                }

                if (flag)
                {
                    _products.Addproduct(txbname.Text, txbpar.Text, txbDescr.Text, txbPrice.Text);
                    listProducts.Items.Add(_products.ToString());

                    comboBox1.Items.Clear();
                    foreach (var item in _products.GetProducts())
                    {
                        comboBox1.Items.Add(item.Getname());
                    }
                }
                else
                {
                    MessageBox.Show("ERROR!");
                }
            }
            f.Controls.Add(addbut);


            editbut.Text = "Редактировать";
            editbut.Location = new Point(260, this.Height / 2);
            editbut.Size = new Size(100, 40);
            editbut.Click += Editbut_Click;
            void Editbut_Click(object? sender, EventArgs e)
            {
                if (listProducts.SelectedItems.Count == 0) 
                {
                    MessageBox.Show("Вы не выбали объект для редактирования!");
                }
                else
                {
                    listProducts.Items[listProducts.SelectedIndex] = _products.EditProduct(listProducts.SelectedIndex, new Product(txbname.Text, txbpar.Text, txbDescr.Text, txbPrice.Text));
                }
            }
            f.Controls.Add(editbut);
        }


        private void btedit_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            InitForm2(ref form2);
            form2.ShowDialog();

        }

        private void listSales_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                listSales.Items.Add(_products.GetProducts()[comboBox1.SelectedIndex].ToString());
                price += Convert.ToInt32(textBox1.Text);
                lbprice.Text = price.ToString();
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _products.GetProducts().Count; i++)
            {
                if (comboBox1.SelectedItem.ToString() == _products.GetProducts()[i].Getname())
                {
                    textBox1.Text = _products.GetProducts()[i].Getprice();
                }
            }
        }

        private void btdel_Click(object sender, EventArgs e)
        {
            try
            {
                price -= Convert.ToInt32(_products.GetProduct(_products.GetIndex(listSales.SelectedItem.ToString())).Getprice());
                lbprice.Text = price.ToString();
                listSales.Items.Remove(listSales.SelectedItem);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            lbprice.Text = "";
            listSales.Items.Clear();
            price = 0;
        }
    }
}