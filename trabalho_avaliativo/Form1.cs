using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trabalho_avaliativo
{
    public partial class Form1 : Form
    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;
        int tentativas = 1;





        public Form1()
        {
            InitializeComponent();
            servidor = "Server=localhost;Database=bd_avaliacao;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();

        }
        private void atualiza_lista()
        {
           
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonENTRAR_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "SELECT usuario, senha FROM tbl_avaliativaa WHERE usuario = '" + textBoxusuario.Text + "' AND senha = '" + textBoxsenha.Text + "';";

                MySqlDataReader resultado = comando.ExecuteReader();


                if (resultado.Read())
                {
                    this.Hide();
                    Form telamenu = new cadastro();
                    telamenu.Closed += (s, args) => this.Close();
                    telamenu.Show();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou Senha incorretos!\n\nVocê usou " + tentativas + "/3 Tentativas");
                    tentativas++;
                }

                if (tentativas > 3)
                {
                    MessageBox.Show("Acesso Negado!");
                    this.Close();
                }


            }
            catch (Exception erro_mysql)
            {
                //MessageBox.Show(erro_mysql.Message);
                MessageBox.Show("Erro de Sistema. Informe o suporte");

            }
            finally
            {
                conexao.Close();
            }
        }

        private void textBoxusuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
