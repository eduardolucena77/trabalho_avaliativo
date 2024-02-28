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

namespace trabalho_avaliativo
{
    public partial class cadastro : Form

    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;
        string id;

        public cadastro()

        {
            InitializeComponent();
            servidor = "Server=localhost;Database=bd_avaliacao;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();

            atualiza_lista();
        }

        private void atualiza_lista()
        {
            try
            {

                conexao.Open();

                comando.CommandText = "SELECT * FROM tbl_avaliativaa;";
                MySqlDataAdapter adaptadoruser = new MySqlDataAdapter(comando);
                DataTable tabelauser = new DataTable();
                adaptadoruser.Fill(tabelauser);
                dataGridViewusers.DataSource = tabelauser;



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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                conexao.Open();
                comando.CommandText = "UPDATE tbl_avaliativaa SET usuario = '" + user.Text + "', senha = '" + senha.Text + "', nivel = '" + comboBoxnível.Text + "', email = '" + textBoxemail.Text + "', celular = '" + textBoxcelular.Text + "', cpf = '" + textBoxcpf.Text + "', endereco = '" + textBoxendereco.Text + "' WHERE  id = " + id + ";";
                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Contato(s) Atualizado(s) com Sucesso! - " + resultado + " Registro(s) Alterado(s)...");
                }
                else
                {
                    MessageBox.Show("Contato não encontrado");
                }

            }
            catch (Exception erro_mysql)
            {

                MessageBox.Show(erro_mysql.Message);

            }
            finally
            {

                user.Clear(); senha.Clear(); textBoxemail.Clear(); textBoxemail.Clear(); textBoxcelular.Clear(); textBoxemail.Clear(); textBoxcpf.Clear(); textBoxendereco.Clear();
                conexao.Close();

            }
            atualiza_lista();
        }

        private void buttonCADASTRAR_Click(object sender, EventArgs e)
        {
            try
            {

                if (user.Text != "" && textBoxcpf.Text != "")
                {
                    conexao.Open();
                    comando.CommandText = "INSERT INTO tbl_avaliativaa(usuario,senha,nivel,email,celular,cpf,endereco) VALUES('" + user.Text + "', '" + senha.Text + "', '" + comboBoxnível.Text + "', '" + textBoxemail.Text + "', '" + textBoxcelular.Text + "', '" + textBoxcpf.Text + "', '" + textBoxendereco.Text + "');";
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastrado");

                }
                else
                {
                    MessageBox.Show("Campos Usuário e CPF obrigatórios.");
                }


            }
            catch (Exception erro_mysql)
            {
                //MessageBox.Show(erro_mysql.Message);
                MessageBox.Show("Erro de Sistema. Informe o suporte");
            }
            finally
            {
                user.Clear(); senha.Clear(); textBoxemail.Clear(); textBoxemail.Clear(); textBoxcelular.Clear(); textBoxemail.Clear(); textBoxcpf.Clear(); textBoxendereco.Clear();
                conexao.Close();
            }
            atualiza_lista();


        }

        private void buttonEXCLUIR_Click(object sender, EventArgs e)
        {
            try
            {

                conexao.Open();
                comando.CommandText = "DELETE FROM tbl_avaliativaa WHERE id = " + id + ";";
                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Usuário(s) Removido(s) com Sucesso! - " + resultado + "Registros Removidos...");
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado");
                }

            }
            catch (Exception erro_mysql)
            {

                MessageBox.Show("Erro de Sistema. Informe o suporte");

            }
            finally
            {

                user.Clear(); senha.Clear(); textBoxemail.Clear(); textBoxemail.Clear(); textBoxcelular.Clear(); textBoxemail.Clear(); textBoxcpf.Clear(); textBoxendereco.Clear();
                conexao.Close();

            }
            atualiza_lista();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxpesquisar.Text == "")
                {
                    atualiza_lista();
                }
                else
                {
                    conexao.Open();

                    comando.CommandText = "SELECT * FROM tbl_avaliativaa WHERE usuario LIKE '%" + textBoxpesquisar.Text + "%';";
                    MySqlDataAdapter adaptadorusers = new MySqlDataAdapter(comando);
                    DataTable tabelausers = new DataTable();
                    adaptadorusers.Fill(tabelausers);

                    dataGridViewusers.DataSource = tabelausers;

                }
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show(erro_mysql.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void comboBoxnível_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewusers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridViewusers.CurrentRow.Cells[0].Value.ToString();
            user.Text = dataGridViewusers.CurrentRow.Cells[1].Value.ToString();
            senha.Text = dataGridViewusers.CurrentRow.Cells[2].Value.ToString();
            comboBoxnível.Text = dataGridViewusers.CurrentRow.Cells[3].Value.ToString();
            textBoxemail.Text = dataGridViewusers.CurrentRow.Cells[4].Value.ToString();
            textBoxcelular.Text = dataGridViewusers.CurrentRow.Cells[5].Value.ToString();
            textBoxcpf.Text = dataGridViewusers.CurrentRow.Cells[6].Value.ToString();
            textBoxendereco.Text = dataGridViewusers.CurrentRow.Cells[7].Value.ToString();
        }
    }
    }
